using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Asn2_GoodSam.Models.TempPwd
{
    public class TempPwdContext : DbContext 
    {
        public TempPwdContext() : base("DefaultConnection") { }
        public DbSet<TempPwd> TempPwd { get; set; }
    }
}