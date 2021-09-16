using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using QuanLyHocSinh.DTO;
using QuanLyHocSinh.DTO.Students;
using QuanLyHocSinh.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyHocSinh.App.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [ApiAuthorize.ApiAuthorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepos;

        public StudentController(IStudentRepository studentRepos, IOptions<WebApiConfig> config)
        {
            _studentRepos = studentRepos;
        }

        [HttpGet("getallstudent")]
        public IActionResult GetAllStudent(int pageIndex, int pageSize)
        {
            var result = _studentRepos.GetAllStudent(pageIndex, pageSize);
            return Ok(result);
        }
        [HttpPost("insertstudent")]
        public IActionResult InsertStudent([FromBody] StudentModel student)
        {
            var result = _studentRepos.InsertStudent(student);
            return Ok(new { IsSuccessfull = true, RowEffect = result });
        }
        [HttpPost("updatestudent")]
        public IActionResult UpdateStudent([FromBody] StudentModel student)
        {
            var result = _studentRepos.UpdateStudent(student);
            return Ok(new { IsSuccessfull = true, RowEffect = result });
        }
        [HttpPost("deletestudent")]
        public IActionResult DeleteStudent(int id)
        {
            var result = _studentRepos.DeleteStudent(id);
            return Ok(new { IsSuccessfull  = true, RowEffect = result});
        }
        [HttpGet("getstudentbyid")]
        public IActionResult GetStudentById(int id)
        {
            var result = _studentRepos.GetStudentById(id);
            return Ok(result);
        }
    }
}
