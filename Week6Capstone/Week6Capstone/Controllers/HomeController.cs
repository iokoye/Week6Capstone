using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Week6Capstone.Data;
using Week6Capstone.Models;

namespace Week6Capstone.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        CapstoneDbContext _context;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public HomeController(CapstoneDbContext capstoneDbContext)
        {
            _context = capstoneDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            var user = _context.Users.Where(user => user.Email == loginModel.Email && user.Password == loginModel.Password).FirstOrDefault();
            if (user != null)
            {
                return RedirectToAction(nameof(AddTask));
                
            }
            else
            {
                // reroute to login or something
            }
            return RedirectToAction(nameof(Login));
        }
        public IActionResult TaskList()
        {
            return View();
        }

        public IActionResult AddTask(LoginModel loginModel)
        {
            return View(new TaskModel { UserId = loginModel });
        }
        [HttpPost]
        public async Task<IActionResult> AddTask(TaskModel taskModel, int userId, string userEmail, string userPassword)
        {
            _context.TaskList.Add(taskModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(TaskList));
        }
        [HttpPost]
        public async Task<IActionResult> Register(LoginModel loginModel)
        {
            _context.Users.Add(loginModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Privacy()
        {
            //var model = new LoginModel
            //{

            //};
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
