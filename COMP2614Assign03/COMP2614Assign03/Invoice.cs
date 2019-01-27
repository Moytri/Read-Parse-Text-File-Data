using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2614Assign03
{
    class Invoice
    {
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int Term { get; set; }

        public int[] ParseTerm()
        {
            int[] intArr = Term.ToString().Select(n => Convert.ToInt32(n)).ToArray();
            int[] results = new int[2];

            for (int i = 0; i < intArr.Length; i++)
            {
                results[0] = intArr[0];
                results[1] = int.Parse(intArr[1].ToString() + intArr[2].ToString());
            }

            return results;
        }
    }
}
