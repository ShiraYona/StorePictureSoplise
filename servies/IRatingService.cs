using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servies
{
    public interface IRatingService
    {
        Task CreateNewRating(Rating rating);

    }
}
