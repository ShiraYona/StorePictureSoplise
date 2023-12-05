
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDataBase1Context _myStoreContext;

        public CategoryRepository(StoreDataBase1Context myStoreContext)
        {
            _myStoreContext = myStoreContext;
        }
        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await _myStoreContext.Categories.ToListAsync();
        }
    }
}
