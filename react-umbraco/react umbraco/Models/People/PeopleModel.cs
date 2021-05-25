using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Models;

namespace react_test.Models.People
{
   
   



    public class People
    {

        public PersonalDetails personalDetails { get; set; }

       

        public PersonalContact personalContact { get; set; }


    }

    public class PersonalDetails
    {

        public string Name { get; set; }
        public string Photo { get; set; }

        public string[] Department { get; set; }

        public string Email { get; set; }

        


    }

    public class PersonalContact
    {

        public string twitterId { get; set; }
        
        public string facebookId { get; set; }

        public string linkedInId { get; set; }

        public string InstagramId { get; set; }

    }



  
    

    public class PeopleListingModel
    {

        public PeopleListing PeopleListing { get; set; }
    }


    public class PeopleListing
    {

        public string pageTitle { get; set; }



        public List<People> People { get; set; }


    }

   
}