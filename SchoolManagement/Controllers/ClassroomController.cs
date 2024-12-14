using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace SchoolManagement.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClassroomController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            var objClassroomsList = _unitOfWork.Classroom.GetAll().ToList();

            return View(objClassroomsList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Classroom obj)
        {

            obj.CreateDate = DateTime.Now;
            obj.UpdateDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _unitOfWork.Classroom.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Classroom Created Successfully";
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

            var ClassroomFromDb = _unitOfWork.Classroom.GetById(u => u.Id == id);
            if (ClassroomFromDb == null)
            {
                return NotFound();
            }
            return View(ClassroomFromDb);
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
