using System;
using System.Collections.Generic;
using System.Text;
using Digikala.DataLayer.Entities;

namespace Digikala.Core.Interfaces
{
    public interface ISliderService
    {
        List<Slider> GetSliderForMain();
        List<Slider> GetSliderForAdmin();
        Slider FindSliderById(int id);
        bool DeleteSlider(Slider slider);
        bool AddSlider(Slider slider);
        bool UpdateSlider(Slider slider);
    }
}
