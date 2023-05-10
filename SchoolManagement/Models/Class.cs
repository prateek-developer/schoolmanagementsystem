using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models
{
    public partial class Class
    {
        public Class()
        {
            SubjectClassTeacherRelationships = new HashSet<SubjectClassTeacherRelationship>();
        }

        public int ClassId { get; set; }
        public int? TeacherId { get; set; }
        public string ClassName { get; set; }

        public virtual TeachersDetail Teacher { get; set; }
        public virtual ICollection<SubjectClassTeacherRelationship> SubjectClassTeacherRelationships { get; set; }
    }
}
