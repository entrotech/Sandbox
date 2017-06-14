using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sandbox.Web.Data
{
    public class Pog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? WhenInstant { get; set; }
        public DateTime? WhenLocalDateTime { get; set; }
        public DateTimeOffset? WhenDateTimeOffset { get; set; }

        public virtual ICollection<PogFile> PogFiles { get; set; }
    }
}