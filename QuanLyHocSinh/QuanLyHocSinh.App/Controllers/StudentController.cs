using Microsoft.AspNetCore.Mvc;
using QuanLyHocSinh.ApiServices;
using QuanLyHocSinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyHocSinh.App.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentSV _studentSV;
        public StudentController(StudentSV studentSV)
        {
            _studentSV = studentSV;
        }
        public IActionResult IndexStudent()
        {
            var ds = _studentSV.GetListStudent(1, 100);
            return View(ds);
        }
        public IActionResult _GetListStudent()
        {
            var ds = _studentSV.GetListStudent(1, 100);
            return PartialView(ds);
        }


        public IActionResult _InsertStudent()
        {
            return PartialView();
        }
        public IActionResult _UpdateStudent(int id)
        {
            var student = _studentSV.GetStudentById(id);
            return PartialView(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertStudent(StudentModel student)
        {
            var rs = _studentSV.InsertStudent(student);
            return Ok();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStudent(StudentModel student)
        {
            var rs = _studentSV.UpdateStudent(student);
            return Ok();
        }
        [HttpPost]
        public IActionResult DelStudent(int id)
        {
            var rs = _studentSV.DeleteStudent(id);
            return Ok();
        }
    }
}
