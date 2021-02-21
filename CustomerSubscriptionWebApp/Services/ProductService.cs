using CustomerSubscriptionAPIClient.Interface;
using CustomerSubscriptionAPIClient.Models;
using CustomerSubscriptionWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSubscriptionWebApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IApiClient _apiClient;

        public ProductService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var products = new List<ProductViewModel>();

            var response = await _apiClient.Product.GetAll();

            if (response.Any())
            {
                foreach (var item in response)
                {
                    products.Add(MapFromCustomerToViewModel(item));
                }
            }

            return products;
        }

        public async Task<ProductViewModel> GetById(Guid id)
        {
            var response = await _apiClient.Product.GetById(id);

            return MapFromCustomerToViewModel(response);
        }

        public async Task Create(ProductViewModel productViewModel)
        {
            await _apiClient.Product.Create(MapFromViewModelToCustomer(productViewModel));
        }

        public async Task Update(ProductViewModel productViewModel)
        {
            await _apiClient.Product.Update(MapFromViewModelToCustomer(productViewModel));
        }

        public async Task Delete(Guid id)
        {
            await _apiClient.Product.Delete(id);
        }

        private Product MapFromViewModelToCustomer(ProductViewModel productViewModel)
        {
            return new Product() { Id = productViewModel.Id, Name = productViewModel.Name, Price = productViewModel.Price };
        }

        private ProductViewModel MapFromCustomerToViewModel(Product product)
        {
            return new ProductViewModel() { Id = product.Id, Name = product.Name, Price = product.Price };
        }
    }
}
