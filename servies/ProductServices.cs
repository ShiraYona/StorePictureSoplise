
using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servies
{
    public class ProductServices: IProductServices
    {
        private readonly IProductRepository _product;

        public ProductServices(IProductRepository product)
        {
            _product = product;
        }


      public async  Task<IEnumerable<Product>> getAllProducts(string? desc, int? minPrice, int? maxPrice,
          int?[] categoryIds)
        {
            return await _product.getAllProducts(desc, minPrice, maxPrice,categoryIds);
        }
       

    }
}

