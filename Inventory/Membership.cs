using InventoryService.Contracts;
using InventoryService.Models;

namespace InventoryService
{
    public class Membership : IMembership<UserInfo>
    {
        bool IMembership<UserInfo>.CreateUpgardeMembership(UserInfo UserInformation)
        {
            try
            {
                //Create-Update Membership
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
