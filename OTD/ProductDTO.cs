using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {
   
  
            public int ProductId { get; set; }

        public string CategoryName { get; set; } = null!;
            public int CategoryId { get; set; }
        public string? Img { get; set; }

        public int? Price { get; set; }

            public string? Name { get; set; }

            public string? Description { get; set; }

            public string? Image { get; set; }



}
}
