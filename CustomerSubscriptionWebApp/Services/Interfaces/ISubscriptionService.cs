using CustomerSubscriptionWebApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerSubscriptionWebApp.Services
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<SubscriptionViewModel>> GetAll();

        Task<SubscriptionViewModel> GetById(Guid id);

        Task Create(SubscriptionViewModel saleViewModel);

        Task Update(SubscriptionViewModel saleViewModel);

        Task Delete(Guid id);
    }
}
