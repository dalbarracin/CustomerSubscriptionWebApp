using CustomerSubscriptionWebApp.Models;
using CustomerSubscriptionWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace CustomerSubscriptionWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        [BindProperty]
        public IEnumerable<ProductViewModel> Products { get; set; }

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            Products = await _productService.GetAll();
            return View(Products);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var viewModel = new ProductViewModel();
            return View(viewModel);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductViewModel viewModel, IFormCollection collection)
        {
            try
            {
                await _productService.Create(viewModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var response = await _productService.GetById(id);
            return View(response);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductViewModel newProduct, IFormCollection collection)
        {
            try
            {
                await _productService.Update(newProduct);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var product = await _productService.GetById(id);
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, IFormCollection collection)
        {
            try
            {
                await _productService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
