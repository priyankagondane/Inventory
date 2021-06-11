using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.Contracts;
using InventoryService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagingController : ControllerBase
    {
        IPackagingSlip<PackageSlip> _packagingSlip = null;

        public PackagingController(IPackagingSlip<PackageSlip> reference)
        {
            _packagingSlip = reference;
        }

        // POST: api/Products
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public bool GenerateSlip(PackageSlip packageSlip)
        {
            try
            {
                return _packagingSlip.GeneratePackagingSlip(packageSlip);
            }
            catch
            {
                throw;
            }
        }
    }
}
