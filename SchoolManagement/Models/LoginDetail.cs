using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models
{
    public partial class LoginDetail 
    {
        public LoginDetail()
        {
            LeaveDetails = new HashSet<LeaveDetail>();
            Notices = new HashSet<Notice>();
            StudentDetails = new HashSet<StudentDetail>();
            StudentLogins = new HashSet<StudentLogin>();
            TeachersDetails = new HashSet<TeachersDetail>(); 
        }

        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? IsApproved { get; set; }
        public string Token { get; set; }
        public int? TokenExpired { get; set; }
        public int? UserRole { get; set; }

        public virtual ICollection<LeaveDetail> LeaveDetails { get; set; }
        public virtual ICollection<Notice> Notices { get; set; }
        public virtual ICollection<StudentDetail> StudentDetails { get; set; }
        public virtual ICollection<StudentLogin> StudentLogins { get; set; }
        public virtual ICollection<TeachersDetail> TeachersDetails { get; set; }
    }
}
