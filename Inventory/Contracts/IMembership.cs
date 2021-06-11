using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Contracts
{
    public interface IMembership<T>
    {
        bool CreateUpgardeMembership(T UserInformation);
    }
}
