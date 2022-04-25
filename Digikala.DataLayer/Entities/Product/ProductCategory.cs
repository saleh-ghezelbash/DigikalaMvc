using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Digikala.DataLayer.Entities.Product
{
   public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public Product Product { get; set; }
        public Category.Category Category { get; set; }
    }
}
