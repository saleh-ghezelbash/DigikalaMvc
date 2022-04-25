using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Digikala.DataLayer.Entities.Product
{
    public class ProductReviewRating
    {
        [Key]
        public int ProductReviewRatingId { get; set; }
        public int ProductId { get; set; }
        public int RatingAttributeId { get; set; }
        public byte Value { get; set; }

        public Product Product { get; set; }
        public RatingAttribute RatingAttribute { get; set; }
    }
}
