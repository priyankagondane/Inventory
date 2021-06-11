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
    public class MembershipController : ControllerBase
    {
        IMembership<UserInfo> _membership = null;

        public MembershipController(IMembership<UserInfo> reference)
        {
            _membership = reference;
        }

        // POST: api/Products
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public bool GenerateSlip(UserInfo userInfo)
        {
            try
            {
                //TODO:Implementation
                return _membership.CreateUpgardeMembership(userInfo);
            }
            catch
            {
                throw;
            }
        }
    }
}
