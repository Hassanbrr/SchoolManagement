using Microsoft.AspNetCore.Mvc;
using Domain.Models;

namespace SchoolManagament.Controllers
{
    public class ClassroomController : Controller
    {
        public IActionResult Index()
        {
           
            return View();
        } 
        public IActionResult Create(Classroom obj)
        {
            return View();

        }  public IActionResult Edit()
        {
            return View();
        }
    }
}
