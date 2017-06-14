using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sandbox.Web.Data
{
    public class SandboxContext : DbContext
    {
        public DbSet<Pog> Pogs { get; set; }
        public DbSet<PogFile> PogFiles { get; set; }
        public DbSet<PogDetail> PogDetails { get; set; }


        public SandboxContext() : base("DefaultConnection")
        {
           

        }
    }
}