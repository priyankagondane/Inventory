using InventoryService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Models
{
    public class MembershipService : IMembership<UserInfo>
    {
        bool IMembership<UserInfo>.CreateUpgardeMembership(UserInfo UserInformation)
        {
            try
            {
                //Create or upgrade user membership
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
