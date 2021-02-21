using CustomerSubscriptionWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSubscriptionWebApp.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerViewModel>> GetAll();

        Task<CustomerViewModel> GetById(Guid id);

        Task Create(CustomerViewModel customerViewModel);

        Task Update(CustomerViewModel customerViewModel);

        Task Delete(Guid id);
    }
}
