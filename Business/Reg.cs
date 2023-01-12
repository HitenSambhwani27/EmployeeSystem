using December_Project.DBContext;
using December_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OKRProject.ViewModels;

namespace OKR.Services
{
    public class Reg : IReg
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly AppDBContext appDB;
        public Reg(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public  Task LoginData(LoginViewModel model)
        {
            
           var result =  signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, false);
 
            return result ;
        }
       
        public Task Logout()
        {
           return signInManager.SignOutAsync();
        
        }

        public async Task<IdentityResult> Register(User model)
        {
           
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);

                }
            
            return result; 
                
        }

    }

    }