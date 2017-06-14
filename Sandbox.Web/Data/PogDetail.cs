using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sandbox.Web.Data
{
    public class PogDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price {  get; set;}
        public int? Quantity { get; set; }

        public int PogId { get; set; }
        public Pog Pog { get; set; }
    }
}