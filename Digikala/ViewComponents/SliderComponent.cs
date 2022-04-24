using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digikala.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Digikala.ViewComponents
{
    public class SliderComponent: ViewComponent
    {
        private readonly ISliderService _sliderService;

        public SliderComponent(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync(){
            return await Task.FromResult(View("MainSlider",_sliderService.GetSliderForMain()));
        }
    }
}