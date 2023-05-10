using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models
{
    public partial class LeaveDetail
    {
        public int LeaveId { get; set; }
        public string Reason { get; set; }
        public int? AppliedBy { get; set; }
        public int? IsApproved { get; set; }

        public virtual LoginDetail AppliedByNavigation { get; set; }
    }
}
