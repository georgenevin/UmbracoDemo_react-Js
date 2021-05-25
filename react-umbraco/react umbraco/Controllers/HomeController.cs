using Newtonsoft.Json;
using react_test.Interface;
using react_test.Models.Home;
using react_test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Umbraco.Core.Logging;
using Umbraco.Web.WebApi;

namespace react_test.Controllers
{
    public class HomeController : UmbracoApiController
    {

        private readonly IHomeFactory _HomeFactory;
        private readonly ILogger _logger;
        private readonly IProductsFactory _productsFactory;
        private readonly IPeopleFactory _peopleFactory;
        private readonly IBlogsFactory _blogsFactory;


        public HomeController(IHomeFactory homeFactory, ILogger logger, IProductsFactory productsFactory, IPeopleFactory peopleFactory, IBlogsFactory blogsFactory)
        {
            _HomeFactory = homeFactory;
            _logger = logger;
            _productsFactory = productsFactory;
            _peopleFactory = peopleFactory;
            _blogsFactory = blogsFactory;

        }



        [HttpGet]
        public HttpResponseMessage GetJson(string page)
        {

            try
            {

                switch (page)
                {
                    case "Home":
                        var homePage = _HomeFactory.HomeContentFactory();
                        return Request.CreateResponse(HttpStatusCode.OK, homePage, Configuration.Formatters.JsonFormatter);

                    case "products":
                        var productPage = _productsFactory.GetProductList();
                        return Request.CreateResponse(HttpStatusCode.OK, productPage, Configuration.Formatters.JsonFormatter);

                    case "people":
                        var peoplePage = _peopleFactory.GetPeople();
                        return Request.CreateResponse(HttpStatusCode.OK, peoplePage, Configuration.Formatters.JsonFormatter);

                    case "blog":
                        var blogPage = _blogsFactory.GetBlogs();
                        return Request.CreateResponse(HttpStatusCode.OK, blogPage, Configuration.Formatters.JsonFormatter);


                    default:
                        break;


                }



            }
            catch (Exception ex)
            {

                _logger.Error<HomeController>(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Configuration.Formatters.JsonFormatter);


            }
            return null;



        }

      



    }
}