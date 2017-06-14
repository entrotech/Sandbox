using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sandbox.Web.Models.Requests
{
    public class PogFileAddRequest
    {
        public int PogId { get; set; }
        public string Caption { get; set; }

        [Required]
        public string FileKey { get; set; }
    }
}