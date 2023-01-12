using December_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using OKR.Services;
using OKRProject.ViewModels;

namespace December_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly IReg reg;
        public AccountController(IReg reg)
        {
            this.reg = reg;
        }
     
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User model)
        { 
            if (ModelState.IsValid)
            {
                IdentityResult identityResult = (IdentityResult)await reg.Register(model);
                if(identityResult.Succeeded)
                {
                   
                    return RedirectToAction("Index", "Home");
                }
            }
            
            //return RedirectToAction("List", "Home");
            return View(model);


        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
           var a =  reg.LoginData(model);
            if(a.IsCompletedSuccessfully){
                return RedirectToAction("SignIn", "Home");
            }
            return View(model);
        }
        [HttpPost]
        public  IActionResult LogOut()
        {
              reg.Logout();  
            return RedirectToAction("Index", "Home");   
            
        }
    }
}
