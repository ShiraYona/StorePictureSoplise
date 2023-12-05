
using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servies
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _category;

        public CategoryServices(ICategoryRepository category)
        {
            _category = category;
        }
        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await _category.GetAllCategory();
        }
    }
}
