using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SchoolManagement.Models;
using SchoolManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace smsAPI.Repository
{
    public class userRepository : IuserRepository
    {
        private readonly masterContext db;
        private readonly IMapper _mapper;

        public userRepository(masterContext _dbContext, IMapper mapper)
        {
            db = _dbContext;
            _mapper = mapper;

        }


        // TEACHERS 
        public async Task<List<TeachersDetail>> GetAllTeacherAsync()
        {
            if (db != null)
            {
                var records = await db.TeachersDetails.Select(x => new TeachersDetail()
                {
                    TeacherId = x.TeacherId,
                    Name = x.Name,
                    SubjectTaught = x.SubjectTaught,
                    Salary = x.Salary,
                    Dob = x.Dob,


                }).ToListAsync();
                return records;
            }
            return null;
        }

        public async Task<TeachersDetail> GetTeacherByIdAsync(int teacherID)
        {

            var records = await db.TeachersDetails.Where(x => x.TeacherId == teacherID).Select(x => new TeachersDetail()
            {
                TeacherId = x.TeacherId,
                Name = x.Name,
                SubjectTaught = x.SubjectTaught,
                Salary = x.Salary,
                Dob = x.Dob,


            }).FirstOrDefaultAsync();
            return records;


        }


        public async Task<int> AddTeacherAsync(LoginDetail teacher)
        {
            var teachers = new LoginDetail();
            {

            };

            db.LoginDetails.Add(teachers);
            await db.SaveChangesAsync();

            return teachers.LoginId;


        }

        public Task GetTeacherByIdAsync()
        {
            throw new System.NotImplementedException();
        }


        public async Task DeleteTeacherAsync(int TeacherID)
        {

            var teacher = new TeachersDetail() { TeacherId = TeacherID };

            {
                db.TeachersDetails.Remove(teacher);
                await db.SaveChangesAsync();


            }
            ;
        }

        public async Task UpdateTeacherAsync(int TeacherId, TeachersDetail teachersDetail)
        {
            var teacher = new TeachersDetail()
            {
                TeacherId = TeacherId,
                Name = teachersDetail.Name,
                SubjectTaught = teachersDetail.SubjectTaught,
                Salary = teachersDetail.Salary,
                Dob = teachersDetail.Dob
            };

            db.TeachersDetails.Update(teacher);
            await db.SaveChangesAsync();
        }


        // STUDENTS

        public async Task<List<StudentDetail>> GetAllStudentsAsync()
        {
            if (db != null)
            {
                var records = await db.StudentDetails.Select( x => new StudentDetail()
                {
                    StudentId=x.StudentId,
                    Email=x.Email,
                    Password=x.Password,
                    PhoneNo=x.PhoneNo,
                    Dob=x.Dob,
                    ClassId=x.ClassId,
                    JoiningDate=x.JoiningDate,

                }).ToListAsync();
                return records;
            }
            return null;
        }


        public async Task<StudentDetail> GetStudentByIdAsync(int studentID)
        {

            var records = await db.StudentDetails.Where(x => x.StudentId == studentID).Select(x => new StudentDetail()
            {

                StudentId = x.StudentId,
                Email = x.Email,
                Password = x.Password,
                PhoneNo = x.PhoneNo,
                Dob = x.Dob,
                ClassId = x.ClassId,
                JoiningDate = x.JoiningDate,

            }).FirstOrDefaultAsync();
            return records;


        }

        public async Task DeleteStudentAsync(int StudentId)
        {

            var Student = new StudentDetail() { StudentId = StudentId };

            {
                db.StudentDetails.Remove( Student);
                await db.SaveChangesAsync();


            }
          ;
        }

        //Notice
        public async Task<List<Notice>> GetAllNoticeAsync()
        {
            if (db != null)
            {
                var records = await db.Notices.Select(x => new Notice()
                {
                    NoticeDetails = x.NoticeDetails,
                    IssuedBy = x.IssuedBy,
                    IssuedOn = x.IssuedOn,

                }).ToListAsync();
                return records;
            }
            return null;
        }

        public async Task<int> AddNoticeAsync(Notice notice)
        {
            var Notice = new Notice()
            {

            };

            db.Notices.Add(Notice);
            await db.SaveChangesAsync();

            return Notice.NoticeId;


        }

        public async Task DeleteNoticeAsync(int NoticeId)
        {

            var notice = new Notice() { NoticeId = NoticeId };

            {
                db.Notices.Remove(notice);
                await db.SaveChangesAsync();


            }
         ;
        }


        }

        


    }







