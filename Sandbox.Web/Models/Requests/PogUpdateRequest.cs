using System;
using System.ComponentModel.DataAnnotations;

namespace Sandbox.Web.Models.Requests
{
    public class PogPutRequest : PogPostRequest
    {
        [Required][Range(1, Int32.MaxValue)]
        public int Id { get; set; }
    }
}