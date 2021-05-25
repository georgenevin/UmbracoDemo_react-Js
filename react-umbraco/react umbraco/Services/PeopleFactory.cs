
using react_test.Interface;
using react_test.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Core.Logging;


namespace react_test.Services
{

    public class PeopleFactory : IPeopleFactory
    {
        private readonly IUmbracoContextFactory _umbracoContextFactory;
        private readonly IContentService _contentService;
        private readonly ILogger _logger;
        public PeopleFactory(IUmbracoContextFactory umbracoContextFactory, IContentService contentService, ILogger logger)
        {

            _contentService = contentService;
            _umbracoContextFactory = umbracoContextFactory;
            _logger = logger;

        }
        public List<People> GetSinglePerson()
        {


            using (var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var content = umbracoContextReference.UmbracoContext.Content ;
                var peoplePage = content.GetAtRoot()?.DescendantsOrSelfOfType("people")?.FirstOrDefault();
                var people = peoplePage?.DescendantsOfType("person");
                var mappedContent = contentMapper(people);
                return mappedContent;
            }



        }

        public PeopleListingModel GetPeople()
        {
            using (var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var peopleListing = new PeopleListing();
                var peopleListings = new PeopleListingModel();
                var featuredPeople = new List<People>();


                var content = umbracoContextReference.UmbracoContext.Content;
                var productPage = content.GetAtRoot()?.DescendantsOrSelfOfType("people")?.FirstOrDefault();
                var featuredPeopleItem = productPage.Value<IEnumerable<IPublishedContent>>("featuredPeople", null);
                  
                if(featuredPeopleItem == null)
                {
                    featuredPeople = GetSinglePerson();
                }
                else
                {
                    featuredPeople = contentMapper(featuredPeopleItem);
                }
                
                var pageTitle = GetProductListDetails(productPage);
                peopleListing.pageTitle = pageTitle;

                peopleListing.People = featuredPeople;

                peopleListings.PeopleListing = peopleListing;
                return peopleListings;

            }



        }

        private string GetProductListDetails(IPublishedContent node)
        {

            var pageTitle = node.Value<string>("pageTitle", string.Empty);

            return pageTitle;



        }

        private List<People> contentMapper(IEnumerable<IPublishedContent> productNode)
        {


            var peopleList = new List<People>();
        


            if(productNode !=null)
            {
                foreach (var productItem in productNode)
                {
                    var people = new People();
                    var peopleDetails = new PersonalDetails();
                    var peopleContact = new PersonalContact();

                    peopleDetails.Name = productItem?.Name;
                    peopleDetails.Photo = productItem?.Value<IPublishedContent>("photo", null)?.Url();
                    peopleDetails.Department = productItem?.Value<IEnumerable<string>>("department", string.Empty)?.ToArray();
                    peopleDetails.Email = productItem?.Value<string>("email", string.Empty);
                    people.personalDetails = peopleDetails;


                    peopleContact.twitterId = productItem?.Value<string>("twitterUsername", string.Empty);
                    peopleContact.facebookId = productItem?.Value<string>("facebookUsername", string.Empty);
                    peopleContact.linkedInId = productItem?.Value<string>("linkedInUsername", string.Empty);
                    peopleContact.InstagramId = productItem?.Value<string>("instagramUsername", string.Empty);
                    people.personalContact = peopleContact;


                    peopleList.Add(people);

                }

         
                return peopleList;


            }
            else
            {
                return null;
            }
          
        }


    }
}