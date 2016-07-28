using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            StudentRepository.Add(studentVM.Student);

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var student = StudentRepository.Get(id);
            var viewModel = new StudentVM();
            viewModel.Student = student;
            viewModel.SetCourseItems(CourseRepository.GetAll());
            if (student.Courses != null)
            {
                foreach (var course in student.Courses)
                {
                    viewModel.SelectedCourseIds.Add(course.CourseId);
                }
            }
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(StudentVM studentVm)
        {
            studentVm.Student.Courses = new List<Course>();
            
            foreach (var id in studentVm.SelectedCourseIds)
                studentVm.Student.Courses.Add(CourseRepository.Get(id));

            studentVm.Student.Major = MajorRepository.Get(studentVm.Student.Major.MajorId);

            StudentRepository.Edit(studentVm.Student);

            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            var student = StudentRepository.Get(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("List");
        }

        public ActionResult EditAddress(int id)
        {
            var student = StudentRepository.Get(id);
            var viewmodel = new StudentVM();
            viewmodel.Student.Address = student.Address;
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult EditAddress(StudentVM studentVM)
        {
            StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);
            return RedirectToAction("List",StudentRepository.GetAll());
        }
      
        public ActionResult BindAddress()
        {
            return View(new Student() {Address = new Address()});
        }
    }
}