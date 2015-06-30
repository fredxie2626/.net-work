using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Asn2_GoodSam.Models.Client
{
    [DisplayName("Fiscal Year")]
    public class FiscalYear
    {
        [DisplayName("Fiscal Year")]
        public int FiscalYearId { get; set; }
        [DisplayName("Fiscal Year")]
        [Required(ErrorMessage = "The field cannot be empty!")]
        [StringLength(40, ErrorMessage = "The {0} must be between {2} characters long and {1} characters long", MinimumLength = 1)]
        public string FiscalYearName { get; set; }
    }
}