using System;
using System.ComponentModel.DataAnnotations;

namespace Sandbox.Web.Models.Requests
{
    public class PogTypeAddRequest
    {
        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool Inactive { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int DisplayOrder { get; set; }
    }
}