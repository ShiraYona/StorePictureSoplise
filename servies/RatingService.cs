using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servies
{
    public class RatingService:IRatingService    
    {
        private readonly IRatingRepository _ratingRepository;
        public RatingService(IRatingRepository ratingRepository)
        {
             _ratingRepository=ratingRepository;
        }
        public async Task CreateNewRating(Rating rating)
        {
             await _ratingRepository.CreateNewRating(rating);
        }

    }
}
