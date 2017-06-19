using System;
using System.ComponentModel.DataAnnotations;

namespace Sandbox.Web.Models.Requests
{
    public class EmailPostRequest
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        
        [Required]
        [StringLength(100)]
        public string Website { get; set; }

        [StringLength(4000)]
        public string Message { get; set; }

    }
}