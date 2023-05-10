using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models
{
    public partial class StudentAttendanceDetail
    {
        public int AttendanceId { get; set; }
        public int? StudentId { get; set; }
        public DateTime? Date { get; set; }
        public int? Status { get; set; }
        public string Remarks { get; set; }

        public virtual StudentLogin Student { get; set; }
    }
}
