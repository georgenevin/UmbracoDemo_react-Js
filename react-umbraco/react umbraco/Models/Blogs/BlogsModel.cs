using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace react_test.Models.Blogs
{
    public class BlogsModel
    {

        public string  PageTitle { get; set; }

        public string NumberOfBlogs { get; set; }


    }

    public class Blogs
    {
        public BlogsModel Blog { get; set; }

        public List<BlogPost> BlogPosts { get; set; }

    }

    public class BlogPost
    {

        public string PageTitle { get; set; }

        public string[] Caterories { get; set; }

        public string BlogIntro { get; set; }



    }


    public class BlogPostModel
    {

        public List<BlogPost> BlogPosts { get; set; }
    }
}