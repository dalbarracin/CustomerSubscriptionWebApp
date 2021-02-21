using CustomerSubscriptionAPIClient.Interface;
using CustomerSubscriptionAPIClient.Models;
using CustomerSubscriptionWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSubscriptionWebApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IApiClient _apiClient;

        public CustomerService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAll()
        {
            var customers = new List<CustomerViewModel>();

            var response = await _apiClient.Customer.GetAll();

            if (response.Any())
            {
                foreach (var item in response)
                {
                    customers.Add(MapFromCustomerToViewModel(item));
                }
            }

            return customers;
        }

        public async Task<CustomerViewModel> GetById(Guid id)
        {
            var response = await _apiClient.Customer.GetById(id);

            return MapFromCustomerToViewModel(response);
        }

        public async Task Create(CustomerViewModel customerViewModel)
        {
            await _apiClient.Customer.Create(MapFromViewModelToCustomer(customerViewModel));
        }

        public async Task Update(CustomerViewModel customerViewModel)
        {
            await _apiClient.Customer.Update(MapFromViewModelToCustomer(customerViewModel));
        }

        public async Task Delete(Guid id)
        {
            await _apiClient.Customer.Delete(id);
        }

        private Customer MapFromViewModelToCustomer(CustomerViewModel customerViewModel)
        {
            return new Customer() { Id = customerViewModel.Id, Name = customerViewModel.Name, Address = customerViewModel.Address };
        }

        private CustomerViewModel MapFromCustomerToViewModel(Customer customer)
        {
            return new CustomerViewModel() { Id = customer.Id, Name = customer.Name, Address = customer.Address };
        }
    }
}
