using Newtonsoft.Json.Linq;
using react_test.Interface;
using react_test.Models.Common;
using react_test.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace react_test.Services
{
    public class HomeFactory : IHomeFactory
    {
      
        private readonly IUmbracoContextFactory _umbracoContextFactory;
        private readonly IContentService _contentService; 
        public HomeFactory(IUmbracoContextFactory umbracoContextFactory, IContentService contentService)
        {
            _umbracoContextFactory = umbracoContextFactory;
            _contentService = contentService;
        }

        public HomeContents HomeContentFactory() {

            using (var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var content = umbracoContextReference.UmbracoContext.Content;
                var homePage = content.GetAtRoot()?.DescendantsOrSelfOfType("home")?.FirstOrDefault();
                var mappedContent =contentMapper(homePage);
                return mappedContent;
            }

      
        }


        private HomeContents contentMapper(IPublishedContent homeNode)
        {
            var homePageModel = new HomeModel();
            var homeHeroSection = new HomeHero();
            var homeContent = new HomeContent();
            var homeDesign = new HomeDesign();
            var homePage = new HomeContents();
            var homeFooter = new Footer();
            homeHeroSection.header = homeNode?.Value<string>("heroHeader", string.Empty);
            homeHeroSection.description= homeNode?.Value<string>("heroDescription", string.Empty);
            homeHeroSection.ctaCaption = homeNode?.Value<string>("heroCTACaption", string.Empty);
            homeHeroSection.backgroundImage = homeNode?.Value<IPublishedContent>("HeroBackgroundImage")?.Url();
            homeHeroSection.ctaLink = homeNode?.Value<IPublishedContent>("HeroCtalink")?.Url();
            homePageModel.HeroSection = homeHeroSection;
            homeHeroSection.siteName= homeNode?.Value<string>("sitename", string.Empty);
            homeHeroSection.siteLink = homeNode?.Url();

            homeContent.fullWidthContent = homeNode?.Value<string>("bodyText", string.Empty)?.StripHtml();
          
            homePageModel.ContentSection = homeContent;
         
            homeDesign.font = homeNode?.Value<string>("font",string.Empty);
            homeDesign.colorTheme = homeNode?.Value<string>("colorTheme",string.Empty);
            homeDesign.siteName = homeNode?.Value<string>("sitename",string.Empty);
            homeDesign.logo = homeNode?.Value<string>("SiteLogo", string.Empty);
            homePageModel.DesignSection = homeDesign;

            homeFooter.Header= homeNode?.Value<string>("footerHeader", string.Empty);
            homeFooter.Description = homeNode?.Value<string>("footerDescription", string.Empty);
            homeFooter.CtaCaption = homeNode?.Value<string>("footerCTACaption", string.Empty);
            homeFooter.CtaLink= homeNode?.Value<IPublishedContent>("FooterCtalink").Url();
          
            homeFooter.Address = homeNode?.Value<string>("footerAddress", string.Empty);
            homePageModel.Footer = homeFooter;


            homePage.HomePage = homePageModel;
            return homePage;

           


        } 

        


    }


   
}