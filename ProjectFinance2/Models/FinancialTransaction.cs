using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinance2.Models
{
    public class FinancialTransaction
    {
        public int TransactionId { get; set; }

        public int DestinationAccount { get; set; }

        //Will be an optional field on screen
        public string? Description { get; set; }

        public float Value { get; set; }

        //Will use 1 and 2 to tell if there is a credit or a debit in that account
        public int Nature { get; set; }
    }
}
