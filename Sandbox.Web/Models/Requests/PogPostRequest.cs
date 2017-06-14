using System;
using System.ComponentModel.DataAnnotations;

namespace Sandbox.Web.Models.Requests
{
    public class PogPostRequest
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public DateTime? WhenInstant { get; set; }

        public DateTime? WhenLocalDateTime { get; set; }

        public DateTime? WhenDateTimeOffset { get; set; }
    }
}