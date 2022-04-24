using System;
using System.Collections.Generic;
using System.Text;

namespace Digikala.Core.ViewModels.Category
{
    public class ShowCategoriesForUserViewModel
    {
        public string FaTitle { get; set; }
        public List<Digikala.DataLayer.Entities.Category.Category> categories { get; set; }
    }
}
