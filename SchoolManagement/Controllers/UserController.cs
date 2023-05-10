using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;

using smsAPI.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace smsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IuserRepository _userRepository;

        public UserController(IuserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("teachers")]

        public async Task<IActionResult> GetAllTeacher()
        {
            var teachers = await _userRepository.GetAllTeacherAsync();
            if (teachers == null)
            {
                return NotFound();
            }
            return Ok(teachers);
        }

        [HttpGet("teacher/{id}")]

        public async Task<IActionResult> GetTeacherByID([FromRoute] int id)
        {
            var teachers = await _userRepository.GetTeacherByIdAsync(id);
            if (teachers == null)
            {
                return NotFound();
            }
            return Ok(teachers);
        }





        [HttpPost("")]


        public async Task<IActionResult> AddTeacher([FromBody] LoginDetail teachersDetail)
        {
            var id = await _userRepository.AddTeacherAsync(teachersDetail);
            return CreatedAtAction(nameof(GetTeacherByID), new { id = id, Controller = "User" }, id);
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteTeacher([FromRoute] int id)
        {
            await _userRepository.DeleteTeacherAsync(id);
            return Ok();
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateTeacher([FromBody] TeachersDetail teachersDetail, [FromRoute] int id)
        {
            await _userRepository.UpdateTeacherAsync(id, teachersDetail);
            return Ok();
        }

        


        //students

        [HttpGet("students")]

        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _userRepository.GetAllStudentsAsync();
            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }


        [HttpGet("Student/{id}")]

        public async Task<IActionResult> GetStudentByID([FromRoute] int id)
        {
            var Student = await _userRepository.GetStudentByIdAsync(id);
            if (Student == null)
            {
                return NotFound();
            }
            return Ok(Student);
        }



        [HttpDelete("deletestudent/{id}")]

        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            await _userRepository.DeleteStudentAsync(id);
            return Ok();
        }

        [HttpGet("Notices")]

        public async Task<IActionResult> GetAllNotice()
        {
            var Notice = await _userRepository.GetAllNoticeAsync();
            if (Notice == null)
            {
                return NotFound();
            }
            return Ok(Notice);
        }


        [HttpPost("newnotice")]


        public async Task<IActionResult> AddNotice([FromBody] Notice notice)
        {
            var id = await _userRepository.AddNoticeAsync(notice);
            return CreatedAtAction(nameof(GetAllNotice), new { id = id, Controller = "User" }, id);
        }


        [HttpDelete("deleteNotice/{id}")]

        public async Task<IActionResult> DeleteNotice([FromRoute] int id)
        {
            await _userRepository.DeleteNoticeAsync(id);
            return Ok();
        }


    }
}
