using react_test.Interface;
using react_test.Models.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace react_test.Services
{
    public class BlogFactory : IBlogsFactory
    {

        private readonly IUmbracoContextFactory _umbracoContextFactory;

        public BlogFactory(IUmbracoContextFactory umbracoContextFactory)
        {
            _umbracoContextFactory = umbracoContextFactory;

        }

        public Blogs GetBlogs()
        {

            using (var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var blogs = new Blogs();
                var content = umbracoContextReference.UmbracoContext.Content;
                var blogPage = content.GetAtRoot()?.DescendantsOrSelfOfType("blog")?.FirstOrDefault();
                var blogPostPage = blogPage?.DescendantsOrSelfOfType("blogpost");
                var blogPostContent = BlogContentMapper(blogPostPage);
                var mappedContent = ContentMapper(blogPage);
                blogs.Blog = mappedContent;
                blogs.BlogPosts = blogPostContent;
                return blogs;
            }



        }

        private BlogsModel ContentMapper(IPublishedContent blogPage)
        {

         
            var blogModel = new BlogsModel();
            blogModel.PageTitle = blogPage.Value<string>("pageTitle");
            blogModel.NumberOfBlogs = blogPage.Value<string>("howManyPostsShouldBeShown");
            return blogModel;
          

        }

        public List<BlogPost> GetBlogPost() {

            using (var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
            {

                var content = umbracoContextReference.UmbracoContext.Content;
                var mappedContent = new List<BlogPost>();
                var blogPage = content.GetAtRoot()?.DescendantsOrSelfOfType("blog")?.FirstOrDefault();
                if(blogPage !=null)
                {
                    var blogPost = blogPage.DescendantsOrSelfOfType("blogpost");
                     mappedContent = BlogContentMapper(blogPost);
                }
              

                return mappedContent;
            }


        }

        public List<BlogPost> BlogContentMapper(IEnumerable<IPublishedContent> blogPost)
        {

  
           
            var blogPosts = new List<BlogPost>();

            foreach (var blogs in blogPost)
            {
                var blogpost = new BlogPost();
                blogpost.PageTitle = blogs.Value<string>("pageTitle");
                blogpost.Caterories = blogs.Value<IEnumerable<string>>("categories")?.ToArray();
                blogpost.BlogIntro = blogs.Value<string>("excerpt");
                blogPosts.Add(blogpost);

            }
       
            return blogPosts;


        }
       
    }
}