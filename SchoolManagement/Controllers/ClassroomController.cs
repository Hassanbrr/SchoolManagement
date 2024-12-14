using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace SchoolManagament.Controllers
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

           var objClassroomsList =  _unitOfWork.Classroom.GetAll().ToList();
           
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
            return  RedirectToAction("index");
            }
            else
            {
                return NotFound();
            }
          
        } 
        public IActionResult Edit()
        {
            return View();
        }
    }
}
