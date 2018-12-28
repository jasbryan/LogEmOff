﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LogEmOff;

namespace LogEmOffUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly NetworkModel _context;

        public UsersController(NetworkModel context)
        {
            _context = context;
        }

        // GET: Users
        public IActionResult Index()
        {
            //return View(await _context.Users.ToListAsync());
            return View(Network.GetUsers());
        }

        // GET: Users/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = Network.GetUserByID(id.Value);

            if (user == null)
            {
                return NotFound();
            }

            if (Network.GetLogins().Any(c => c.ComputerID == id))
            {
                ViewData["HasLogins"] = true;
                ViewData["Logins"] = Network.GetLogins().Where(c => c.UserID == id);
            }
            else { ViewData["HasLogins"] = false; }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,UserID")] User user)
        {
            if (ModelState.IsValid)
            {
                Network.AddUser(user.FirstName, user.LastName);
                //_context.Add(user);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = Network.GetUserByID(id.Value);

            //var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("FirstName,LastName,UserID")] User user)
        {
            if (id != user.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(user);
                    //await _context.SaveChangesAsync();
                    Network.EditUser(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Network.UserExists(user.UserID))
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

        // GET: Users/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = Network.GetUserByID(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            var logins = Network.GetLoginsByUserId(user.UserID);
            if (logins != null)
            {
                ViewData["ErrorMessage"] = "This User account is still associatted with logins, you must delete those or associate them with another user first.";
            }
                       
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
