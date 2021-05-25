using react_test.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace react_test.Interface
{
   public interface IPeopleFactory
    {

        PeopleListingModel GetPeople();

        List<People> GetSinglePerson();
    }
}
