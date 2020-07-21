using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KanpurTeachMVCCRUD.Context;
using KanpurTeachMVCCRUD.Models;
namespace KanpurTeachMVCCRUD.Controllers
{
    public class StudentController : Controller
    {
        private readonly DatabaseContext _context;

        public StudentController()
        {
            _context = new DatabaseContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Student
        public ViewResult Index()
        {
            var studentList = _context.Students.ToList();
            return View(studentList);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToRouteResult Save(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ViewResult Edit(int id)
        {
            var studentDetails = _context.Students.Where(s => s.Id == id).FirstOrDefault();
            return View(studentDetails);
        }

        [HttpPost]
        public RedirectToRouteResult Update(Student student)
        {
            var studentDetails = _context.Students.Where(s => s.Id == student.Id).FirstOrDefault();
            studentDetails.Name = student.Name;
            studentDetails.Age = student.Age;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}