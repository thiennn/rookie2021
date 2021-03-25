using SharedVm;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerSite.Services
{
    public interface IBrandApiClient
    {
        Task<IList<BrandVm>> GetBrands();
    }
}