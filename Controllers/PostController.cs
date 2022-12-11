using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentME.Data;
using RentME.Models;

namespace RentME.Controllers
{
    public class PostController : Controller
    {
        private readonly UserContext _context;

        public PostController(UserContext context)
        {
            _context = context;
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("EnrollmentDate,FirstMidName,LastName")] Post post)
        {
            try
            {

                //code here for success
                return View("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
