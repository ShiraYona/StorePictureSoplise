
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servies
{
    public interface IProductServices
    {


        Task<IEnumerable<Product>> getAllProducts(string? desc, int? minPrice, int? maxPrice,
          int?[] categoryIds);
    }
}
