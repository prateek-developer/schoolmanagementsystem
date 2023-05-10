using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models
{
    public partial class StudentLogin
    {
        public StudentLogin()
        {
            StudentAttendanceDetails = new HashSet<StudentAttendanceDetail>();
            SubjectClassTeacherRelationships = new HashSet<SubjectClassTeacherRelationship>();
        }

        public int StudentId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? Dob { get; set; }
        public int? PhoneNo { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public int? Status { get; set; }
        public int? ClassId { get; set; }
        public int? LoginId { get; set; }

        public virtual LoginDetail Login { get; set; }
        public virtual ICollection<StudentAttendanceDetail> StudentAttendanceDetails { get; set; }
        public virtual ICollection<SubjectClassTeacherRelationship> SubjectClassTeacherRelationships { get; set; }
    }
}
