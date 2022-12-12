using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentME.Data;
using RentME.Models;
using System.Diagnostics;

namespace RentME.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserContext _context;

        public HomeController(UserContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("firstname") != null)
            {
                TempData["firstname"] = HttpContext.Session.GetString("firstname");
            }
            Post allposts = new Post();
            allposts.postsList = await _context.posts.ToListAsync();
            return View(allposts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}