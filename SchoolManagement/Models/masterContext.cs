using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SchoolManagement.ViewModel;

#nullable disable

namespace SchoolManagement.Models
{
    public partial class masterContext : IdentityDbContext<LoginViewModel>
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<LeaveDetail> LeaveDetails { get; set; }
        public virtual DbSet<LoginDetail> LoginDetails { get; set; }
        public virtual DbSet<Notice> Notices { get; set; }
        public virtual DbSet<StudentAttendanceDetail> StudentAttendanceDetails { get; set; }
        public virtual DbSet<StudentDetail> StudentDetails { get; set; }
        public virtual DbSet<StudentLogin> StudentLogins { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectClassTeacherRelationship> SubjectClassTeacherRelationships { get; set; }
        public virtual DbSet<TeachersDetail> TeachersDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server= PRATEEK;  database=master;  trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("CLASS");

                entity.Property(e => e.ClassId)
                    .ValueGeneratedNever()
                    .HasColumnName("class_id");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("class_name")
                    .IsFixedLength(true);

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__CLASS__teacher_i__3118447E");
            });

            modelBuilder.Entity<LeaveDetail>(entity =>
            {
                entity.HasKey(e => e.LeaveId)
                    .HasName("PK__leave_de__743350BC6525B4B5");

                entity.ToTable("leave_details");

                entity.Property(e => e.LeaveId)
                    .ValueGeneratedNever()
                    .HasColumnName("leave_id");

                entity.Property(e => e.AppliedBy).HasColumnName("applied_by");

                entity.Property(e => e.IsApproved).HasColumnName("is_approved");

                entity.Property(e => e.Reason)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("reason")
                    .IsFixedLength(true);

                entity.HasOne(d => d.AppliedByNavigation)
                    .WithMany(p => p.LeaveDetails)
                    .HasForeignKey(d => d.AppliedBy)
                    .HasConstraintName("FK__leave_det__appli__35DCF99B");
            });

            modelBuilder.Entity<LoginDetail>(entity =>
            {
                entity.HasKey(e => e.LoginId)
                    .HasName("PK__login_de__C2CA7DB37ED0533D");

                entity.ToTable("login_details");

                entity.Property(e => e.LoginId).HasColumnName("login_ID");

                entity.Property(e => e.IsApproved).HasColumnName("is_approved");

                entity.Property(e => e.Password)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Token).HasColumnName("token");

                entity.Property(e => e.TokenExpired).HasColumnName("token_expired");

                entity.Property(e => e.UserRole).HasColumnName("user_role");

                entity.Property(e => e.Username)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Notice>(entity =>
            {
                entity.ToTable("NOTICE");

                entity.Property(e => e.NoticeId)
                    .ValueGeneratedNever()
                    .HasColumnName("notice_id");

                entity.Property(e => e.IssuedBy).HasColumnName("issued_by");

                entity.Property(e => e.IssuedOn)
                    .HasColumnType("date")
                    .HasColumnName("issued_on");

                entity.Property(e => e.NoticeDetails)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("notice_details");

                entity.HasOne(d => d.IssuedByNavigation)
                    .WithMany(p => p.Notices)
                    .HasForeignKey(d => d.IssuedBy)
                    .HasConstraintName("FK__NOTICE__issued_b__405A880E");
            });

            modelBuilder.Entity<StudentAttendanceDetail>(entity =>
            {
                entity.HasKey(e => e.AttendanceId)
                    .HasName("PK__student___20D6A9688E2FA550");

                entity.ToTable("student_attendance_detail");

                entity.Property(e => e.AttendanceId)
                    .ValueGeneratedNever()
                    .HasColumnName("attendance_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("remarks");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentAttendanceDetails)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__student_a__stude__38B96646");
            });

            modelBuilder.Entity<StudentDetail>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__student___A2F7EDF46D99C5B7");

                entity.ToTable("student_detail");

                entity.Property(e => e.StudentId)
                    .ValueGeneratedNever()
                    .HasColumnName("Student_id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("email")
                    .IsFixedLength(true);

                entity.Property(e => e.JoiningDate)
                    .HasColumnType("date")
                    .HasColumnName("Joining_date");

                entity.Property(e => e.LoginId).HasColumnName("login_id");

                entity.Property(e => e.Password)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNo).HasColumnName("Phone_no");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.StudentDetails)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK__student_d__login__4CC05EF3");
            });

            modelBuilder.Entity<StudentLogin>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__Student___A2F7EDF468707396");

                entity.ToTable("Student_login");

                entity.Property(e => e.StudentId)
                    .ValueGeneratedNever()
                    .HasColumnName("Student_id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.DateOfJoining)
                    .HasColumnType("date")
                    .HasColumnName("date_of_joining");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.LoginId).HasColumnName("login_id");

                entity.Property(e => e.Password)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNo).HasColumnName("phone_no");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.StudentLogins)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK__Student_l__login__278EDA44");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("subject");

                entity.Property(e => e.SubjectId)
                    .ValueGeneratedNever()
                    .HasColumnName("subject_id");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("subject_name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<SubjectClassTeacherRelationship>(entity =>
            {
                entity.HasKey(e => e.SctId)
                    .HasName("PK__Subject___68F019F421175BDB");

                entity.ToTable("Subject_class_teacher_relationship");

                entity.Property(e => e.SctId)
                    .ValueGeneratedNever()
                    .HasColumnName("SCT_ID");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.SubjectClassTeacherRelationships)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__Subject_c__class__3D7E1B63");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.SubjectClassTeacherRelationships)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Subject_c__stude__3C89F72A");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.SubjectClassTeacherRelationships)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__Subject_c__teach__3B95D2F1");
            });

            modelBuilder.Entity<TeachersDetail>(entity =>
            {
                entity.HasKey(e => e.TeacherId)
                    .HasName("PK__teachers__03AE777EF94FF665");

                entity.ToTable("teachers_detail");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.LoginId).HasColumnName("login_id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.Property(e => e.SubjectTaught).HasColumnName("subject_taught");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.TeachersDetails)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK__teachers___login__2E3BD7D3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
