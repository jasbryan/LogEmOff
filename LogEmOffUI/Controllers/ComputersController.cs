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
    public class ComputersController : Controller
    {
        //private readonly NetworkModel _context;

        public ComputersController(NetworkModel context)
        {
            //_context = context;
        }

        // GET: Computers
        public IActionResult Index()
        {
            //return View(await _context.Computers.ToListAsync());
            return View(Network.GetComputers());
        }

        // GET: Computers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var computer = await _context.Computers.FirstOrDefaultAsync(m => m.ComputerID == id);
            var computer = Network.GetComputerByID(id.Value);
            if (computer == null)
            {
                return NotFound();
            }

            if (Network.GetLogins().Any(c => c.ComputerID == id.Value))
            {
                ViewData["HasLogins"] = true;
                ViewData["Logins"] = Network.GetLogins().Where(c => c.ComputerID == id.Value);
            }else { ViewData["HasLogins"] = false;  }

            return View(computer);
        }

        // GET: Computers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Computers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("AdminLogin,AdminPassword,ComputerName,ComputerIP")] Computer computer)
        {
            if (ModelState.IsValid)
            {
                var tempComp = Network.AddComputer(computer.ComputerName, computer.ComputerIP, computer.AdminLogin, computer.AdminPassword);
                //_context.Add(computer);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(computer);
        }

        // GET: Computers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var computer = await _context.Computers.FindAsync(id);
            var computer = Network.GetComputerByID(id.Value);

            if (computer == null)
            {
                return NotFound();
            }

            return View(computer);
        }

        // POST: Computers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("AdminLogin,AdminPassword,ComputerName,ComputerIP,ComputerMAC,ComputerID")] Computer computer)
        {
            if (id != computer.ComputerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(computer);
                    //await _context.SaveChangesAsync();
                    Network.EditComputer(computer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComputerExists(computer.ComputerID))
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
            return View(computer);
        }

        // GET: Computers/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computer = Network.GetComputerByID(id.Value);
                       
            //var computer = await _context.Computers.FirstOrDefaultAsync(m => m.ComputerID == id);

            if (computer == null)
            {
                return NotFound();
            }

            
            if (Network.GetLogins().Any(c => c.ComputerID == id))
            {
                ViewData["ErrorMessage"] = "This Computer is still associatted with logins, you must delete those or associate them with another computer first.";
            }

            return View(computer);
        }

        // POST: Computers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            Network.DeleteComputer(id.Value);

            //var computer = await _context.Computers.FindAsync(id);
            //_context.Computers.Remove(computer);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComputerExists(int id)
        {
            //return _context.Computers.Any(e => e.ComputerID == id);
            return Network.GetComputers().Any(a => a.ComputerID == id);
        }
    }
}
