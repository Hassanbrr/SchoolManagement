using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

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
            List<Classroom> objClassroomsList = _unitOfWork.Classroom.GetAll().ToList();
           
            return View(objClassroomsList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Classroom obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Classroom.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Classroom Created Successfully";
            return  RedirectToAction("index");
            }

            return View();
        } 
        public IActionResult Edit()
        {
            return View();
        }
    }
}
