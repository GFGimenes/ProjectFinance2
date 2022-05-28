using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinance.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        public string Name { get; set; }

        public int AccountNumber { get; set; }

        public float CurrentBalance { get; set; }

    }
}
