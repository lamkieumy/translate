using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using translate.Models;
using translate.datafirst;
using Microsoft.AspNetCore.Cors;
using translate.dtos;

namespace translate.Controllers
{
    [EnableCors("AllowOrigin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            try
            {
                var users = user.Instance.showAllUser();
                return View(users);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }
        [HttpGet]
        public IActionResult login(){
            return View();
        }
        [HttpPost]
        public IActionResult login(login lg){
            var users = user.Instance.checklogin(lg);
            return View(users);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
