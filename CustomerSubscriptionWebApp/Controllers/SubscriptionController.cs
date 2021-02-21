using CustomerSubscriptionWebApp.Models;
using CustomerSubscriptionWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerSubscriptionWebApp.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;

        [BindProperty]
        public IEnumerable<SubscriptionViewModel> Subscriptions { get; set; }

        public SubscriptionController(
            ISubscriptionService subscriptionService,
            ICustomerService customerService,
            IProductService productService)
        {
            _subscriptionService = subscriptionService;
            _customerService = customerService;
            _productService = productService;
        }

        // GET: SubscriptionController
        public async Task<ActionResult> Index()
        {
            Subscriptions = await _subscriptionService.GetAll();
            return View(Subscriptions);
        }

        // GET: SubscriptionController/Create
        public async Task<ActionResult> Create()
        {
            var viewModel = new CustomerSubscriptionViewModel();

            Subscriptions = await _subscriptionService.GetAll();
            var customers = await _customerService.GetAll();
            var products = await _productService.GetAll();

            var customersList = new List<SelectListItem>() { new SelectListItem { Text = "Please Select...", Value = string.Empty } };

            foreach (var customer in customers)
            {
                customersList.Add(new SelectListItem(customer.Name, customer.Id.ToString()));
            }

            viewModel.Customers = customersList;

            var productsList = new List<SelectListItem>() { new SelectListItem { Text = "Please Select...", Value = string.Empty } };

            foreach (var product in products)
            {
                productsList.Add(new SelectListItem(product.Name, product.Id.ToString()));
            }

            viewModel.Products = productsList;
            viewModel.Subscription = new SubscriptionViewModel();


            return View(viewModel);
        }

        // POST: SubscriptionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomerSubscriptionViewModel viewModel, IFormCollection collection)
        {
            try
            {
                var newSubscription = viewModel.Subscription;
                newSubscription.CustomerId = Guid.Parse(viewModel.CustomerSelected);
                newSubscription.ProductId = Guid.Parse(viewModel.ProductSelected);

                await _subscriptionService.Create(newSubscription);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubscriptionController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var viewModel = new CustomerSubscriptionViewModel();
            var customers = await _customerService.GetAll();
            var products = await _productService.GetAll();
            viewModel.Subscription = await _subscriptionService.GetById(id);

            var customersList = new List<SelectListItem>() { new SelectListItem { Text = "Please Select...", Value = string.Empty } };

            foreach (var customer in customers)
            {
                customersList.Add(new SelectListItem(customer.Name, customer.Id.ToString()));
            }

            viewModel.Customers = customersList;
            viewModel.CustomerSelected = viewModel.Subscription.CustomerId.ToString();

            var productsList = new List<SelectListItem>() { new SelectListItem { Text = "Please Select...", Value = string.Empty } };

            foreach (var product in products)
            {
                productsList.Add(new SelectListItem(product.Name, product.Id.ToString()));
            }

            viewModel.Products = productsList;
            viewModel.ProductSelected = viewModel.Subscription.ProductId.ToString();

            return View(viewModel);
        }

        // POST: SubscriptionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CustomerSubscriptionViewModel viewModel, IFormCollection collection)
        {
            try
            {
                viewModel.Subscription.CustomerId = Guid.Parse(viewModel.CustomerSelected);
                viewModel.Subscription.ProductId = Guid.Parse(viewModel.ProductSelected);

                await _subscriptionService.Update(viewModel.Subscription);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubscriptionController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var subscription = await _subscriptionService.GetById(id);
            return View(subscription);
        }

        // POST: SubscriptionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, IFormCollection collection)
        {
            try
            {
                await _subscriptionService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
