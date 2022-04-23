using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Digikala.Core.Interfaces;
using Digikala.DataLayer.Context;
using Digikala.DataLayer.Entities;

namespace Digikala.Core.Services
{
    public class SliderService : ISliderService
    {
        DigikalaContext _context;
        public SliderService(DigikalaContext context)
        {
            _context = context;
        }
        public List<Slider> GetSliderForMain()
        {
            return _context.Sliders.OrderBy(s => s.sort).Take(6).ToList();
        }

        public List<Slider> GetSliderForAdmin()
        {
            return _context.Sliders.ToList();
        }

        public Slider FindSliderById(int id)
        {
            return _context.Find<Slider>(id);
        }

        public bool DeleteSlider(Slider slider)
        {
            _context.Sliders.Remove(slider);
            int res = _context.SaveChanges();
            if (res > 0)
                return true;
            return false;
        }

        public bool AddSlider(Slider slider)
        {
            _context.Add(slider);
            int res = _context.SaveChanges();
            if (res > 0)
                return true;
            return false;
        }

        public bool UpdateSlider(Slider slider)
        {
            _context.Update(slider);
            int res = _context.SaveChanges();
            if (res > 0)
                return true;
            return false;
        }
    }
}
