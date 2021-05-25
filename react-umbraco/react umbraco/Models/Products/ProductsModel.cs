using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace react_test.Models.Products
{


    public class ProductsModel
    {

        public List<Product>Products { get; set; }
    }


  
    public class Product
    {

        public ProductDetails productDetails { get; set; }

        public Features productFeatures { get; set; }

        public ProductDescription productDescription { get; set; }


    }

    public class ProductDetails
    {

        public string ProductName { get; set; }

        public string Price { get; set; }

        public string[] Category { get; set; }

        public string Description { get; set; }

        public string SKU { get; set; }

        public string Photos { get; set; }

        public string ProductLink { get; set; }


    }

    public class ProductDescription
    {

        public string description { get; set; }

    }

  

    public class Features
    {

        public string Name { get; set; }

        public string Details { get; set; }


    }

    public class ProductListingModel
    {

        public ProductListing ProductListing { get; set; }
    }


    public class ProductListing
    {

        public string pageTitle { get; set; }

        public string DefaultCurrency { get; set; }

        public ProductsModel FeaturedProducts { get; set; }


    }


}