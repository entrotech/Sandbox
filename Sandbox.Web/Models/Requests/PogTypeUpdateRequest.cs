using System.ComponentModel.DataAnnotations;

namespace Sandbox.Web.Models.Requests
{
    public class PogTypeUpdateRequest : PogTypeAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}