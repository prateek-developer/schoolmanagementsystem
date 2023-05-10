using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models
{
    public partial class TeachersDetail
    {
        public TeachersDetail()
        {
            Classes = new HashSet<Class>();
            SubjectClassTeacherRelationships = new HashSet<SubjectClassTeacherRelationship>();
        }

        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string SubjectTaught { get; set; }
        public int? Salary { get; set; }
        public DateTime? Dob { get; set; }
        public int? LoginId { get; set; }

        public virtual LoginDetail Login { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<SubjectClassTeacherRelationship> SubjectClassTeacherRelationships { get; set; }
    }
}
