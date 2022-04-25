using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Digikala.DataLayer.Entities.Product
{
    public class ProductReview
    {
        [Key]
        public int ProductReviewId { get; set; }

        [Display(Name = "خلاضه")]
        [MaxLength(2000, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public string Summary { get; set; }

        [Display(Name = "نقد و بررسی کوتاه")]
        [MaxLength(2000, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public string ShortReview { get; set; }

        [Display(Name = "نقد و بررسی تخصصی")]
        public string Review { get; set; }

        [Display(Name = "نقاط قوت")]
        [MaxLength(500, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public string Positive { get; set; }

        [Display(Name = "نقاط ضعف")]
        [MaxLength(500, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public string Negative { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
