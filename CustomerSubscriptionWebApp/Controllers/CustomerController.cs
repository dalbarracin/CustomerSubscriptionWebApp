using CustomerSubscriptionWebApp.Models;
using CustomerSubscriptionWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerSubscriptionWebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        [BindProperty]
        public IEnumerable<CustomerViewModel> Customers { get; set; }

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: CustomerController
        public async Task<ActionResult> Index()
        {
            Customers = await _customerService.GetAll();
            return View(Customers);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                var newCustomer = new CustomerViewModel();
                newCustomer.Id = Guid.NewGuid();
                newCustomer.Name = collection["Name"];
                newCustomer.Address = collection["Address"];

                await _customerService.Create(newCustomer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var response = await _customerService.GetById(id);
            return View(response);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CustomerViewModel newCustomer, IFormCollection collection)
        {
            try
            {
                await _customerService.Update(newCustomer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var customer = await _customerService.GetById(id);
            return View(customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, IFormCollection collection)
        {
            try
            {
                await _customerService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
