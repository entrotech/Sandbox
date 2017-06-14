using System;
using System.ComponentModel.DataAnnotations;

namespace Sandbox.Web.Models.Requests
{
    public class SmsPostRequest
    {
        [Required]
        [StringLength(20)]
        public string ToNumber { get; set; }

        [StringLength(400)]
        public string Message { get; set; }

    }
}