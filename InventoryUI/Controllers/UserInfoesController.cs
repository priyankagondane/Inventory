using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ShopBridgeUI.Factory;
using ShopBridgeUI.Models;
using ShopBridgeUI.Utility;

namespace ShopBridgeUI.Controllers
{
    public class UserInfoesController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;

        public UserInfoesController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ApplicationSettings.WebApiUrl = "https://localhost:44351/api/"; // appSettings.Value.WebApiBaseUrl;
        }

        // GET: UserInfoes
        public async Task<IActionResult> Index()
        {
            var _user = await ApiClientFactory.Instance.GetUsers();
            return View(JsonConvert.DeserializeObject<IList<UserInfo>>(_user));
        }

        
        // GET: UserInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _user = await ApiClientFactory.Instance.GetUserDetails(id);
            if (_user == null)
            {
                return NotFound();
            }

            return View(nameof(Details), JsonConvert.DeserializeObject<Products>(_user));
        }

        // GET: UserInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("UserId,FirstName,LastName,UserName,Email,Password,CreatedDate")] UserInfo userInfo)
        {
            //TODO save code
            //await SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: UserInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _user = await ApiClientFactory.Instance.GetUserDetails(id);
            if (_user == null)
            {
                return NotFound();
            }

            return View(nameof(Edit), JsonConvert.DeserializeObject<Products>(_user));
        }

        // POST: UserInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("UserId,FirstName,LastName,UserName,Email,Password,CreatedDate")] UserInfo userInfo)
        {
            if (id != userInfo.UserId)
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
                    if (!UserInfoExists(userInfo.UserId))
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
            return View(userInfo);
        }

        // GET: UserInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _user = await ApiClientFactory.Instance.GetUserDetails(id);
            if (_user == null)
            {
                return NotFound();
            }

            return View(nameof(Delete), JsonConvert.DeserializeObject<Products>(_user));
        }

        // POST: UserInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            //TODO remove code
            //var products = await Products.FindAsync(id);
            //await SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserInfoExists(int id)
        {
            return true;
        }
    }
}
