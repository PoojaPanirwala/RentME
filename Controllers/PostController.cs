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
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("imageURL,title,description")] Post post)
        {
            try
            {
                post.postType = "1";
                post.imageURL = "img/" + Path.GetFileName(post.imageURL);
                post.addedDate = DateTime.Now;
                post.addedBy = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));
                //changes
                _context.posts.Add(post);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Congratulations! You have added your add on RentME";

                //code here for success
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var post = await _context.posts.FindAsync(id);
                if (post != null)
                {
                    _context.posts.Remove(post);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View("Index", "Home");
            }
        }
    }
}
