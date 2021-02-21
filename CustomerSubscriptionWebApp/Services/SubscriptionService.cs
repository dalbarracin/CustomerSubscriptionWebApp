using CustomerSubscriptionAPIClient.Interface;
using CustomerSubscriptionAPIClient.Models;
using CustomerSubscriptionWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSubscriptionWebApp.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IApiClient _apiClient;

        public SubscriptionService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IEnumerable<SubscriptionViewModel>> GetAll()
        {
            var subscriptions = new List<SubscriptionViewModel>();

            var response = await _apiClient.Subscription.GetAll();
            var customers = await _apiClient.Customer.GetAll();
            var products = await _apiClient.Product.GetAll();

            if (response.Any())
            {
                foreach (var item in response)
                {
                    var viewModel = MapFromCustomerToViewModel(item);
                    viewModel.CustomerName = customers.Any(r => r.Id == viewModel.CustomerId) ? customers.Single(r => r.Id == viewModel.CustomerId).Name : string.Empty;
                    viewModel.ProductName = products.Any(r => r.Id == viewModel.ProductId) ? products.Single(r => r.Id == viewModel.ProductId).Name : string.Empty;
                    subscriptions.Add(viewModel);
                }
            }

            return subscriptions;
        }

        public async Task<SubscriptionViewModel> GetById(Guid id)
        {
            var subscription = await _apiClient.Subscription.GetById(id);
            var customer = await _apiClient.Customer.GetById(subscription.CustomerId);
            var product = await _apiClient.Product.GetById(subscription.ProductId);
            var viewModel = MapFromCustomerToViewModel(subscription);

            viewModel.CustomerName = customer.Name;
            viewModel.ProductName = product.Name;

            return viewModel;
        }

        public async Task Create(SubscriptionViewModel subscriptionViewModel)
        {
            await _apiClient.Subscription.Create(MapFromViewModelToCustomer(subscriptionViewModel));
        }

        public async Task Update(SubscriptionViewModel subscriptionViewModel)
        {
            await _apiClient.Subscription.Update(MapFromViewModelToCustomer(subscriptionViewModel));
        }

        public async Task Delete(Guid id)
        {
            await _apiClient.Subscription.Delete(id);
        }

        private Subscription MapFromViewModelToCustomer(SubscriptionViewModel entity)
        {
            return new Subscription() 
            { 
                Id = entity.Id, 
                CustomerId = entity.CustomerId, 
                ProductId = entity.ProductId, 
                Created = entity.Created
            };
        }

        private SubscriptionViewModel MapFromCustomerToViewModel(Subscription entity)
        {
            return new SubscriptionViewModel() 
            { 
                Id = entity.Id, 
                CustomerId = entity.CustomerId,
                ProductId = entity.ProductId,
                Created = entity.Created
            };
        }
    }
}
