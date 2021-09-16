using Microsoft.AspNetCore.Mvc;
using QuanLyHocSinh.ApiServices;
using QuanLyHocSinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyHocSinh.App.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly SubjectsSV _subjectsSV;
        public SubjectsController(SubjectsSV subjectSV)
        {
            _subjectsSV = subjectSV;
        }
        public IActionResult IndexSubjects()
        {
            var ds = _subjectsSV.GetListSubjects(1, 100);
            return View(ds);
        }

        public IActionResult _GetListSubjects()
        {
            var ds = _subjectsSV.GetListSubjects(1, 100);
            return PartialView(ds);
        }


        public IActionResult _InsertSubjects()
        {
            return PartialView();
        }
        public IActionResult _UpdateSubjects(int id)
        {
            var Subjects = _subjectsSV.GetSubjectsById(id);
            return PartialView(Subjects);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertSubjects(SubjectsModel Subjects)
        {
            var rs = _subjectsSV.InsertSubjects(Subjects);
            return Ok();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSubjects(SubjectsModel Subjects)
        {
            var rs = _subjectsSV.UpdateSubjects(Subjects);
            return Ok();
        }
        [HttpPost]
        public IActionResult DelSubjects(int id)
        {
            var rs = _subjectsSV.DeleteSubjects(id);
            return Ok();
        }
    }
}
