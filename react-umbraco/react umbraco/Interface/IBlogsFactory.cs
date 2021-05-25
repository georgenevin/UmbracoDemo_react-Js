using react_test.Models.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace react_test.Interface
{
   public interface IBlogsFactory
    {

        Blogs GetBlogs();

        List<BlogPost> GetBlogPost();
    }
}
