using react_test.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace react_test.Models.Home
{

    public class HomeContents
    {

        public HomeModel HomePage{ get; set; }

    }


    public class HomeModel
    {

        public HomeHero HeroSection { get; set; }


        public HomeContent ContentSection { get; set; }


        public HomeDesign DesignSection { get; set; }

        public Footer Footer { get; set; }



    }


    public class HomeHero
    {

        public string header { get; set; }

        public string description { get; set; }

        public string ctaCaption { get; set; }

        public string ctaLink { get; set; }

        public  string siteName { get; set; }

        public string siteLink { get; set; }

        public string backgroundImage { get; set; }


    }

    public class HomeContent
    {

        public string fullWidthContent { get; set; }


    }


    public class  HomeDesign
    {

       

        public string font { get; set; }

        public string colorTheme { get; set; }

        public string siteName { get; set; }

        public string logo { get; set; }



    }


}