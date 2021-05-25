using react_test.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace react_test.Interface
{
    public interface IProductsFactory
    {

        ProductsModel GetProduct();

        ProductListingModel GetProductList();
    }
}
