  using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models
{
    public partial class StudentDetail
    {
        public int StudentId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? PhoneNo { get; set; }
        public DateTime? JoiningDate { get; set; }
        public int? ClassId { get; set; }
        public DateTime? Dob { get; set; }
        public int? LoginId { get; set; }

        public virtual LoginDetail Login { get; set; }
    }
}
