using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sandbox.Web.Models.Requests
{
    public class PogFileUpdateRequest : PogFileAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}