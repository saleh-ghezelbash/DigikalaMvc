using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digikala.Core.Interfaces;
using Digikala.DataLayer.Context;
using Digikala.DataLayer.Entities.Brand;

namespace Digikala.Core.Services
{
   public class BrandService : IBrandService
    {
        DigikalaContext _context;
        public BrandService(DigikalaContext context)
        {
            _context = context;
        }
        public Brand GetBrandByName(string brandTitle)
        {
            return _context.Brands.FirstOrDefault(b => b.EnTitle == brandTitle);
        }
       
        public Brand GetBrandById(int id)
        {
            return _context.Find<Brand>(id);
        }

   
        public List<Brand> GetBrandByCategoryId(int id)
        {
            return _context.BrandCategories.Where(c => c.CategoryId == id).Select(c=>c.Brand).ToList();
        }
    }
}