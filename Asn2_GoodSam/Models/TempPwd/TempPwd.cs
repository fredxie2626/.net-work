using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asn2_GoodSam.Models.TempPwd
{
    public class TempPwd
    {
        [Key]
        public string Id { get; set; }
        public string Password { get; set; }
    }
}