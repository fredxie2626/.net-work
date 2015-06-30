using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asn2_GoodSam.Models.Client
{
    public class ReferredToCBVS
    {
        public int ReferredToCBVSId { get; set; }
        [Required(ErrorMessage = "The field cannot be empty!")]
        [StringLength(40, ErrorMessage = "The {0} must be between {2} characters long and {1} characters long", MinimumLength = 1)]
        public string ReferredToCBVSName { get; set; }
    }
}
