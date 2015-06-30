using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Asn2_GoodSam.Models.Client
{
    public class Gender
    {
        public int GenderId { get; set; }
        [Required(ErrorMessage = "The field cannot be empty!")]
        public string GenderName { get; set; }
    }
}