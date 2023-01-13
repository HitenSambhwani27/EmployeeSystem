//using EmployeeSystem.DBContext;
using EmployeeSystem.Business;
using EmployeeSystem.DBContext;
using EmployeeSystem.MiddleWare;
using EmployeeSystem.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OKR.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});// dbcontext use karna hai

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDBContext>();
builder.Services.AddScoped<IStudentRep, StudentRep>();
builder.Services.AddScoped<IStudent, Student>();
builder.Services.AddScoped<IGuardRep, GuardRep>();
builder.Services.AddScoped<IGuard, Guard>();
builder.Services.AddScoped<IRegist, Regist>();
var app = builder.Build();
//app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Start}/{id?}");

app.Run();
