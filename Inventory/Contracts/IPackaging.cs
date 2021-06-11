using InventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Contracts
{
    public interface IPackagingSlip<T>
    {
        bool GeneratePackagingSlip(T packageSlip);
    }
}
