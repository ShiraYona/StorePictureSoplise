using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RatingRepository:IRatingRepository
    {
        private readonly StoreDataBase1Context _myStoreContext;
        public RatingRepository(StoreDataBase1Context myStoreContext)
        {
             _myStoreContext=myStoreContext;
        }
        public async Task CreateNewRating(Rating rating)
        {
            await _myStoreContext.Ratings.AddAsync(rating);
            await _myStoreContext.SaveChangesAsync();
        }
    }
}
