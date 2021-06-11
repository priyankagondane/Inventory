using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ShopBridgeUI.Factory;
using ShopBridgeUI.Models;
using ShopBridgeUI.Utility;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridgeUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;

        public ProductsController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ApplicationSettings.WebApiUrl = "https://localhost:44351/api/"; // appSettings.Value.WebApiBaseUrl;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            //await _context.Products.ToListAsync()
            var _product = await ApiClientFactory.Instance.GetProducts();
            return View(JsonConvert.DeserializeObject<IList<Products>>(_product));
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _product = await ApiClientFactory.Instance.GetProductDetails(id);
            if (_product == null)
            {
                return NotFound();
            }

            return View(nameof(Details), JsonConvert.DeserializeObject<Products>(_product));
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ProductId,Name,Category,Color,UnitPrice,AvailableQuantity")] Products products)
        {
            if (ModelState.IsValid)
            {
                //TODO save code
                //await SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _product = await ApiClientFactory.Instance.GetProductDetails(id);
            if (_product == null)
            {
                return NotFound();
            }

            return View(nameof(Edit), JsonConvert.DeserializeObject<Products>(_product));
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ProductId,Name,Category,Color,UnitPrice,AvailableQuantity")] Products products)
        {
            if (id != products.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //TODO save code
                    //await SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _product = await ApiClientFactory.Instance.GetProductDetails(id);
            if (_product == null)
            {
                return NotFound();
            }

            return View(nameof(Delete), JsonConvert.DeserializeObject<Products>(_product));
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            //TODO remove code
            //var products = await Products.FindAsync(id);
            //await SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {            
            return true;
        }
    }
}
