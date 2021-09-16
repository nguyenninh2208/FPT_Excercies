using Microsoft.AspNetCore.Mvc;
using QuanLyHocSinh.DTO.Subjects;
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
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectsRepository _subjectsRepos;

        public SubjectsController(ISubjectsRepository subjects)
        {
            _subjectsRepos = subjects;
        }

        [HttpGet("getsubjectsbyid")]
        public IActionResult GetSubjectsById(int id)
        {
            var result = _subjectsRepos.GetSubjectsById(id);
            return Ok(result);
        }
        [HttpGet("getallsubjects")]
        public IActionResult GetAllSubjects(int pageIndex, int pageSize)
        {
            var result = _subjectsRepos.GetAllSubjects(pageIndex, pageSize);
            return Ok(result);
        }
        [HttpPost("insertsubjects")]
        public IActionResult InsertSubjects([FromBody] SubjectsModel subjects)
        {
            var result = _subjectsRepos.InsertSubjects(subjects);
            return Ok(new { IsSuccessfull = true, RowEffect = result });
        }
        [HttpPost("updatesubjects")]
        public IActionResult UpdateSubjects([FromBody] SubjectsModel subjects)
        {
            var result = _subjectsRepos.UpdateSubjects(subjects);
            return Ok(new { IsSuccessfull = true, RowEffect = result });
        }
        [HttpPost("deletesubjects")]
        public IActionResult UpdateSubjects(int id)
        {
            var result = _subjectsRepos.DeleteSubject(id);
            return Ok(new { IsSuccessfull = true, RowEffect = result });
        }
    }
}
