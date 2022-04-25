
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Digikala.DataLayer.Entities.Product
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Display(Name = "عنوان فارسی")]
        [MaxLength(300, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FaTitle { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        [MaxLength(300, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string EnTitle { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime CreteDate { get; set; }

        [Display(Name = "تاریخ بروزرسانی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime UpdateDate { get; set; }

        [Display(Name = "عکس اصلی")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ImgName { get; set; }
        public int Weight { get; set; }
        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        public bool IsPublished { get; set; }

        [MaxLength(500)]
        public string OtherTitleForSearch { get; set; }

        public int? MainPrice { get; set; }
        public int? PromotionPrice { get; set; }
        public DateTime? PromotionEndDate { get; set; }
        public byte DiscountType { get; set; }

        public Brand.Brand Brand { get; set; }
        public Category.Category Category { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<ProductReview> productReviews { get; set; }
        public List<ProductReviewRating> ProductReviewRatings { get; set; }
        
        public List<ProductCategory> ProductCategories { get; set; }
        

    }
}
