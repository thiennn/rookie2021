using SharedVm;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerSite.Services
{
    public interface IProductClient
    {
        Task<IList<ProductVm>> GetProduct();
    }
}