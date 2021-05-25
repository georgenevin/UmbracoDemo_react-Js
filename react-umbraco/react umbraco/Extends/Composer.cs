using react_test.Interface;
using react_test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace react_test.Extends
{
    public class Composer: IUserComposer
    {

        public void Compose(Composition composition)
        {

             composition.Register<IHomeFactory, HomeFactory>(Lifetime.Transient);
             composition.Register<IProductsFactory,ProductFactory>(Lifetime.Transient);
             composition.Register<IPeopleFactory,PeopleFactory>(Lifetime.Transient);
             composition.Register<IBlogsFactory, BlogFactory>(Lifetime.Transient);
        }
       

    }
}