using December_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OKRProject.ViewModels;

namespace OKR.Services
{
    public interface IReg
    {
        public  Task<IdentityResult> Register(User model);
        public Task LoginData(LoginViewModel model);
        public Task Logout();
    }
}
