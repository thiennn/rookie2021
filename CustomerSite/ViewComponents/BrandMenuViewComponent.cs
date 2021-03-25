using CustomerSite.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.ViewComponents
{
    public class BrandMenuViewComponent : ViewComponent
    {
        private readonly IBrandApiClient _brandApiClient;

        public BrandMenuViewComponent(IBrandApiClient brandApiClient)
        {
            _brandApiClient = brandApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var brands = await _brandApiClient.GetBrands();

            return View(brands);
        }
    }
}
