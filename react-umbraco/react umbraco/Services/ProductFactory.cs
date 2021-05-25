using react_test.Interface;
using react_test.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Logging;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace react_test.Services
{
    public class ProductFactory : IProductsFactory
    {
        private readonly IUmbracoContextFactory _umbracoContextFactory;
        private readonly IContentService _contentService;
        private readonly ILogger _logger;

        public ProductFactory(IUmbracoContextFactory umbracoContextFactory, IContentService contentService, ILogger logger)
        {
            _umbracoContextFactory = umbracoContextFactory;
            _contentService = contentService;
            _logger = logger;
        }


       public ProductsModel GetProduct()
        {

            using (var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var content = umbracoContextReference.UmbracoContext.Content;
                var productPage = content.GetAtRoot()?.DescendantsOrSelfOfType("products")?.FirstOrDefault();
                var products = productPage?.DescendantsOfType("product");
                var mappedContent = contentMapper(products);
                return mappedContent;
            }


        }

        public ProductListingModel GetProductList()
        {
            using (var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var productListing = new ProductListing();
                var productListings = new ProductListingModel();
               
                var content = umbracoContextReference.UmbracoContext.Content;
                var productPage = content.GetAtRoot()?.DescendantsOrSelfOfType("products")?.FirstOrDefault();
                var featuredProduct= productPage.Value<IEnumerable<IPublishedContent>>("featuredProducts", null);
                var featuredProducts = contentMapper(featuredProduct);
                var productDetails = GetProductListDetails(productPage);
                productListing.pageTitle = productDetails.Item1;
                productListing.DefaultCurrency = productDetails.Item2;
                productListing.FeaturedProducts = featuredProducts;

                productListings.ProductListing = productListing;
                return productListings;

            }

           

        }

        private (string,string) GetProductListDetails(IPublishedContent node)
        {

            var pageTitle = node.Value<string>("pageTitle", string.Empty);
            var defaultCurrency = node.Value<string>("defaultCurrency", string.Empty);

           return (pageTitle,defaultCurrency);



        }


        private ProductsModel contentMapper(IEnumerable<IPublishedContent> productNode)
        {
           

           
            var productList = new List<Product>();
            var products = new ProductsModel();


            if(productNode !=null)
            {
                foreach (var productItem in productNode)
                {
                    var product = new Product();
                    var productDetails = new ProductDetails();
                    var productFeatures = new Features();
                    var productDescription = new ProductDescription();
                    productDetails.ProductName = productItem?.Value<string>("productName", string.Empty);
                    productDetails.Price = productItem?.Value<string>("price", string.Empty);
                    productDetails.Category = productItem?.Value<IEnumerable<string>>("category", string.Empty)?.ToArray();
                    productDetails.Description = productItem?.Value<string>("description", string.Empty);
                    productDetails.SKU = productItem?.Value<string>("sku", string.Empty);
                    productDetails.Photos = productItem?.Value<IPublishedContent>("photos", null)?.Url();
                    productDetails.ProductLink = productItem.Url();

                    var features = productItem?.Value<IEnumerable<IPublishedElement>>("features", null);
                    if (features != null)
                    {
                        foreach (var feature in features)
                        {
                            productFeatures.Name = feature?.Value<string>("featureName", string.Empty);
                            productFeatures.Details = feature?.Value<string>("featureDetails", string.Empty);
                        }

                    }

                    productDescription.description = productItem?.Value<string>("bodyText", string.Empty);

                    product.productDetails = productDetails;
                    product.productDescription = productDescription;
                    product.productFeatures = productFeatures;

                    productList.Add(product);

                }
                products.Products = new List<Product>();
                products.Products = productList;
                return products;

            }
            else

            {
                return null;
            }
           
        }

      




    }
}