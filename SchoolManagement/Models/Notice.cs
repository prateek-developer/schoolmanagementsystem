using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models
{
    public partial class Notice
    {
        public int NoticeId { get; set; }
        public string NoticeDetails { get; set; }
        public DateTime? IssuedOn { get; set; }
        public int? IssuedBy { get; set; }

        public virtual LoginDetail IssuedByNavigation { get; set; }
    }
}
