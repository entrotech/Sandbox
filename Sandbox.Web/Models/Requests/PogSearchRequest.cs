using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sandbox.Web.Models.Requests
{
    public class PogSearchRequest
    {
        public int? CurrentPage { get; set; }
        public int? ItemsPerPage { get; set; }
        public string Name { get; set; }
        public DateTime? FromInstant { get; set; }
        public DateTime? ToInstant { get; set; }
    }
}