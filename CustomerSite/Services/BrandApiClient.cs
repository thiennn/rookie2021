using SharedVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerSite.Services
{
    public class BrandApiClient : IBrandApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BrandApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IList<BrandVm>> GetBrands()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44360/brands");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<BrandVm>>();
        }
    }
}
