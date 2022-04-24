using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Digikala.DataLayer.Entities.Category
{
   public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Display(Name = "عنوان فارسی")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FaTitle { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string EnTitle { get; set; }

        [Display(Name = "عکس")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public string ImgName { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Descrption { get; set; }
        public bool IsDelete { get; set; }
        public bool IsMain { get; set; }


        public List<SubCategory> ParentCategory { get; set; }
        public List<SubCategory> SubCategory { get; set; }
  

    }
}