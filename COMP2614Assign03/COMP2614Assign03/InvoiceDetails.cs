using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2614Assign03
{
    class InvoiceDetails
    {
        public int Quantity { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsTaxable { get; set; }

        public decimal ExtendedPrice
        {
            get
            {
                return Quantity * Price;
            }
        }
    }
}
