using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digikala.DataLayer.Entities.Brand;

namespace Digikala.Core.Interfaces
{
   public interface IBrandService
    {
        Brand GetBrandByName(string brandTitle);
        Brand GetBrandById(int id);
        List<Brand> GetBrandByCategoryId(int id);
    }
}