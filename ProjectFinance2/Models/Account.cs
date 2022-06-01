using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinance2.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        [Required]
        [Display(Name = "Name ")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Account Number ")]
        public int AccountNumber { get; set; }

        [Required]
        [Display(Name = "Current Balance ")]
        public float CurrentBalance { get; set; }

    }
}
