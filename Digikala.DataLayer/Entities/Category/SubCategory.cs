using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Digikala.DataLayer.Entities.Category
{
     public class SubCategory
    {
        [Key]
        public int Id { get; set; }

        public int ParentId { get; set; }

        public int SubId { get; set; }

        [InverseProperty("ParentCategory")]
        [ForeignKey("ParentId")]
        public Category ParentCategory { get; set; }

        [InverseProperty("SubCategory")]
        [ForeignKey("SubId")]
        public Category SubCat { get; set; }
    }
}