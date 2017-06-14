using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sandbox.Web.Domain
{
    public class PogFile
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string FileKey { get; set; }
        public string Url { get; set; }
    }
}