using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Models.Models
{
    public class GlAccount
    {
        public int ID { get; set; }

        [Required(ErrorMessage = ("Account name is required")), MaxLength(40)]
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }

        // To-do: Autogenerate - start with 1: Assets, 2: Liabilities, 3: Capital, 4: Income, 5: Expenses
        [Display(Name = "Code")]
        public long CodeNumber { get; set; }

        [Display(Name = "Account Balance")]
        public decimal AccountBalance { get; set; }

        [Required(ErrorMessage = ("Please select a GL Category"))]
        [Display(Name = "Category")]
        public int GlCategoryID { get; set; }
        public virtual GlCategory GlCategory { get; set; }
    }
}
