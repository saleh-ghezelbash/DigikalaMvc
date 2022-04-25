using System;
using System.Collections.Generic;
using System.Text;

namespace Digikala.DataLayer.Entities.Brand
{
    public class BrandCategory
    {
        public int BrandCategoryId { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        public Category.Category Category { get; set; }
        public Brand Brand { get; set; }
    }
}
