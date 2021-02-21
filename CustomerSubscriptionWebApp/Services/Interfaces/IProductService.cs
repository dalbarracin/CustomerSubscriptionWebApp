using CustomerSubscriptionWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSubscriptionWebApp.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAll();

        Task<ProductViewModel> GetById(Guid id);

        Task Create(ProductViewModel productViewModel);

        Task Update(ProductViewModel productViewModel);

        Task Delete(Guid id);
    }
}
