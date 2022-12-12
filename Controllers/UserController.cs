using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using RentME.Data;
using RentME.Models;

namespace RentME.Controllers
{
    public class UserController : Controller
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<JsonResult> Login([Bind("userName,password")] User userdata)
        {
            try
            {
                if (userdata.userName != null && userdata.password != null)
                {
                    User user = null;
                    var temp = _context.users.Where(x => x.userName == userdata.userName).First();
                    user = temp;
                    if (user != null)
                    {
                        HttpContext.Session.SetInt32("userID", user.userId);
                        HttpContext.Session.SetString("username", user.userName);
                        HttpContext.Session.SetString("firstname", user.firstName);
                        TempData["isError"] = null;
                        TempData["firstname"] = HttpContext.Session.GetString("firstname");
                        return Json("success");
                    }
                    else
                    {
                        TempData["isError"] = "Something went wrong!";
                        return Json("User not found! Try again!");
                    }
                }
                else
                {
                    TempData["isError"] = "Something went wrong!";
                    return Json("Check your details once again!");
                }

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.users == null)
            {
                return NotFound();
            }

            var user = await _context.users
                .FirstOrDefaultAsync(m => m.userId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        [HttpPost]
        public async Task<JsonResult> Register([Bind("userId,firstName,lastName,userName,password,mobileNo,city,country,accessMode")] User user)
        {
            try
            {
                // Generate a 128 - bit salt using a sequence of
                // cryptographically strong random bytes.
                byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
                                                                       // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: user.password!,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));

                user.password = hashed;
                user.accessMode = "user";
                user.country = "Canada";
                user.city = "Tornoto";
                _context.users.Add(user);
                await _context.SaveChangesAsync();

                HttpContext.Session.SetString("username", user.userName);
                HttpContext.Session.SetString("firstname", user.firstName);
                TempData["firstname"] = HttpContext.Session.GetString("firstname");

                return Json("success");

            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.users == null)
            {
                return NotFound();
            }

            var user = await _context.users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("userId,firstName,lastName,userName,password,mobileNo,city,country,accessMode")] User user)
        {
            if (id != user.userId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.userId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.users == null)
            {
                return NotFound();
            }

            var user = await _context.users
                .FirstOrDefaultAsync(m => m.userId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.users == null)
            {
                return Problem("Entity set 'UserContext.users'  is null.");
            }
            var user = await _context.users.FindAsync(id);
            if (user != null)
            {
                _context.users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.users.Any(e => e.userId == id);
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            TempData["firstname"] = null;
            TempData["isError"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
