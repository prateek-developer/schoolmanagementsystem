using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models
{
    public partial class SubjectClassTeacherRelationship
    {
        public int? TeacherId { get; set; }
        public int? StudentId { get; set; }
        public int? ClassId { get; set; }
        public int SctId { get; set; }

        public virtual Class Class { get; set; }
        public virtual StudentLogin Student { get; set; }
        public virtual TeachersDetail Teacher { get; set; }
    }
}
