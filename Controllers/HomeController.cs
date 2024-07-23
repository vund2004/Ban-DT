using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NET104_ASM.Models;
using NET104_ASM.Models.Authentication;
using System.Diagnostics;

namespace NET104_ASM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Net104Ps33862Context db = new Net104Ps33862Context();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
     /*   [Authentication]*/
        public IActionResult Index()
        {
            var listsp = db.SanPhams.ToList();
            return View(listsp);
            
        }
    }
}
