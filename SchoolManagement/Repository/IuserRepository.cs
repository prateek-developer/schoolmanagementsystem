using SchoolManagement.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace smsAPI.Repository
{
    public interface IuserRepository
    {

        Task<List<TeachersDetail>> GetAllTeacherAsync();

        Task<TeachersDetail> GetTeacherByIdAsync(int teacherID);

        Task<int> AddTeacherAsync(LoginDetail teacher);

        Task GetTeacherByIdAsync();

        Task DeleteTeacherAsync(int TeacherID);
        Task UpdateTeacherAsync(int TeacherId, TeachersDetail teachersDetail);


        //students

        Task<List<StudentDetail>> GetAllStudentsAsync();

        Task<StudentDetail> GetStudentByIdAsync(int studentID);
        Task DeleteStudentAsync(int StudentId);


        //Notice

        Task<List<Notice>> GetAllNoticeAsync();

        Task<int> AddNoticeAsync(Notice notice);

        Task DeleteNoticeAsync(int NoticeId);
    }
}
