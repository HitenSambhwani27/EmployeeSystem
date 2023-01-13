using EmployeeSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EmployeeSystem.ViewModels;

namespace OKR.Services
{
    public interface IRegist
    {
        public  Task<IdentityResult> Register(User model);
        public Task LoginData(LoginViewModel model);
        public Task Logout();
    }
}
