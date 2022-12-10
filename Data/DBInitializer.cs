using RentME.Data;
using RentME.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UserContext _context)
        {
            _context.Database.EnsureCreated();

            // Look for any students.
            if (_context.users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
            new User{firstName="Carson",lastName="Alexander",userName="abc@gmail.com",password="123",mobileNo=6476564545,city="Toronto",country="Canada",accessMode="Both"},
            new User{firstName="Pooja",lastName="Panirwala",userName="xyz@gmail.com",password="456",mobileNo=6476561212,city="Toronto",country="Canada",accessMode="Admin"},
            };
            foreach (User s in users)
            {
                _context.users.Add(s);
            }
            _context.SaveChanges();
        }
    }
}