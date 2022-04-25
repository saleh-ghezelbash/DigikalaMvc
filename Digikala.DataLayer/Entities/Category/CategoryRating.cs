using Digikala.DataLayer.Entities.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Digikala.DataLayer.Entities.Category
{
    public class CategoryRating
    {
        [Key]
        public int CategoryRatingId { get; set; }
        public int CategoryId { get; set; }
        public int RatingAttributeId { get; set; }


        public Category Category { get; set; }
        public RatingAttribute RatingAttribute { get; set; }
    }
}
