using EmployeeSystem.Business;
using EmployeeSystem.Dtos;
using EmployeeSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using EmployeeSystem.Models;
using System.Diagnostics;

namespace EmployeeSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudent _std;
        private readonly IGuard _grd;
        private readonly IRegisteredServices reg;

        public HomeController(ILogger<HomeController> logger,IStudent std, IGuard grd,UserManager<IdentityUser>userManager)
        {
            _logger = logger;
            _std = std;
            _grd = grd;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Start()
        {
           var a = _std.GetList();
            return View(a);
        }
        
        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult DisplayEmployee()
        {
            return View();
        }

        public IActionResult Bdgequeue()
        {
            return View(BadgeOutP());
        }
        public IActionResult SignOut()
        {
            return View();
        }

        public IActionResult BadgeOut()
        {
            return View(BadgeOutP());
        }

        [Authorize]
        public IActionResult BadgeReport()
        {
            return View(BadgeQueue());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IEnumerable<Employee> GetStudents(string employeefirstname,string employeelastname)
        {
            return _std.GetStudents(employeefirstname,employeelastname);
        }
        [HttpPost]
        public IActionResult GetStudent(string employeefirstname, string employeelastname)
        {
           var a=GetStudents(employeefirstname, employeelastname);
            return View("DisplayEmployee",a);
        }
        public IActionResult AddValue(string PhotoUrl)
        {
           Employee emp= _std.GetStudent(PhotoUrl);

            Models.Guard guard = new Models.Guard();
            
            guard.employeefirstname = emp.employeefirstname;
            guard.employeelastname =emp.employeelastname;
            guard.TemporaryBadge=_grd.temp()+1;
            guard.SignIn = DateTime.Now;
            guard.e_id = emp.e_id;
        

            _grd.Addvalue(guard);
            return View("BadgeQueue", BadgeOutP());
        }
        public IActionResult GetTemp(string TemporaryBadge)
        {
            return Content(TemporaryBadge);
        }
        [HttpGet]
        public IEnumerable<Models.Guard> BadgeQueue()
        {
            // Employee emp = _std.GetStudent(PhotoUrl);

            return _grd.BadgeQueue();
        }
        public IActionResult BadgeQueuePage()
        {
            var b = BadgeQueue();
            return View("BadgeQueue", b);
        }
        [HttpPost]
        public IActionResult SignOut(int TemporaryBadge)
        {
            var a = _grd.SignOut(TemporaryBadge);
            if (a == 0)
            {
                return Content("Unable to signOut");
            }
            else
            {
                return RedirectToAction("Start");
            }
        }
        [HttpGet]
        public IEnumerable<Models.Guard> BadgeReportPage(string employeefirstname, string employeelastname, DateTime StartDate, DateTime EndDate)
        {
            return _grd.BadgeReportPage(employeefirstname, employeelastname,StartDate,EndDate);
        }
        [HttpPost]
            public IActionResult GetReport(string employeefirstname, string employeelastname,DateTime StartDate,DateTime EndDate)
            {
            var a = BadgeReportPage(employeefirstname, employeelastname, StartDate, EndDate);
            return View("BadgeReport", a);
            }
        [HttpGet]
        public IEnumerable<BadgeOut> BadgeOutP()
        {
            return _grd.BadgeOutPag();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            return View();
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var thing = _grd.GetServerError();
            //var thingToReturn = thing.ToString();
            //return thingToReturn;
            //     var thingToReturn = thing.ToString();
            return StatusCode(500, "Server error");
        }
        
        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult Add(Photo details)
        {
            if (details != null)
            {
                _std.Add(details);
                return RedirectToAction("Start", "Home");
            }
            //return RedirectToAction("list");
            return View(details);
        }
    }
}