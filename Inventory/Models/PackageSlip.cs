using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Models
{
    public class PackageSlip
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string SlipNumber { get; set; }
        public string SlipNote { get; set; }
        public PackageTypes PackageTypes { get; set; }
        public Int32 NumberOfCopies { get; set; }
        public string AdditionalItemsInSlip { get; set; }
    }
}
