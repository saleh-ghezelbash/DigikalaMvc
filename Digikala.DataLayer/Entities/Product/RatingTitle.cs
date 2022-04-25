using Digikala.DataLayer.Entities.Category;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Digikala.DataLayer.Entities.Product
{
    public class RatingAttribute
    {
        [Key]
        public int RatingAttributeId { get; set; }
        [Display(Name = "نام ")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        public List<CategoryRating> CategoryRatings { get; set; }
        public List<ProductReviewRating> ProductReviewRatings { get; set; }
    }
}
