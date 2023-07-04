using GtrTrainingHr.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GtrTrainingHr.web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(GtrDbContext db)
        {
            this.db=db;
        }
        private readonly ILogger<HomeController> _logger;
        private GtrDbContext db;


        public async Task<IActionResult> Index()
        {
            var companylist = await db.companies.ToListAsync();
            return View(companylist);
        }

        public IActionResult SetCompany(string Comid)
        {
            Response.Cookies.Append("CompanyID", Comid);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}