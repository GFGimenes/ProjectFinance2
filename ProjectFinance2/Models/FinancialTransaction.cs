using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinance2.Models
{
    public class FinancialTransaction
    {
        public int TransactionId { get; set; }


        [Required]
        [Display(Name = "Destination Account (Account Id) ")]
        public int DestinationAccount { get; set; }

        //Will be an optional field on screen
        [Display(Name = "Description ")]
        public string? Description { get; set; }


        [Required]
        [Display(Name = "Value ")]
        public float Value { get; set; }


        [Required]
        [Display(Name = "Nature (1 for credit and 2 for withdraw)")]
        //Will use 1 and 2 to tell if there is a credit or a debit in that account
        public int Nature { get; set; }
    }
}
