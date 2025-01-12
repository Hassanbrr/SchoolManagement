using DataAccess.Repository.IRepository;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var students = _unitOfWork.Student.GetAll().ToList();
            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Student obj)
        {

            obj.CreateDate = DateTime.Now;
            obj.UpdateDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _unitOfWork.Student.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Student Created Successfully";
                return RedirectToAction("index");
            }
            else
            {
                return NotFound();
            }

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var StudentFromDb = _unitOfWork.Student.GetById(u => u.Id == id);
            if (StudentFromDb == null)
            {
                return NotFound();
            }
            return View(StudentFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Classroom obj)
        {

            if (ModelState.IsValid && obj != null)
            {
                _unitOfWork.Classroom.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Edited Successfully";

                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ClassroomFromDb = _unitOfWork.Classroom.GetById(u => u.Id == id);
            if (ClassroomFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Classroom.Remove(ClassroomFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted Successfully";

            return RedirectToAction("Index");

        }
    }
}
