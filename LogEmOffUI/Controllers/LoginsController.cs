using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LogEmOff;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Authorization;

namespace LogEmOffUI.Controllers
{
    [Authorize]
    public class LoginsController : Controller
    {
        private readonly NetworkModel _context;

        public LoginsController(NetworkModel context)
        {
            _context = context;
        }

        // GET: Logins
        public IActionResult Index()
        {
            //var networkModel = _context.Logins.Include(l => l.Computer).Include(l => l.User);
            var logins = Network.GetLogins();

            if (logins.Count() == 0)
            {
                return NotFound();
            }

            ViewData.Add("ComputerTitle", "ComputerName");
            
            foreach(var login in logins)
            {
                ViewData.Add(new KeyValuePair<string,object>("comp" + login.LoginID.ToString() , Network.GetComputerByID(login.LoginID).ComputerName));                
            }

            return View(logins);
            //return View(await networkModel.ToListAsync());
        }

        // GET: Logins/Details/5
        public IActionResult Details(int? id)
        {
             
            if (id == null)
            {
                return NotFound();
            }

            var login = Network.GetLoginById(id);

            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // GET: Logins/Create
        public IActionResult Create()
        {
            ViewData["ComputerID"] = new SelectList(_context.Computers, "ComputerID", "ComputerIP");
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "FirstName");
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,ComputerID,LoginName,Enabled,LoginID")] Login login)
        {
            if (ModelState.IsValid)
            {
                _context.Add(login);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComputerID"] = new SelectList(_context.Computers, "ComputerID", "ComputerIP", login.ComputerID);
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "FirstName", login.UserID);
            return View(login);
        }

        // GET: Logins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Logins.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }
            ViewData["ComputerID"] = new SelectList(_context.Computers, "ComputerID", "ComputerIP", login.ComputerID);
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "FirstName", login.UserID);
            return View(login);
        }

        // POST: Logins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,ComputerID,LoginName,Enabled,LoginID")] Login login)
        {
            if (id != login.LoginID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(login);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginExists(login.LoginID))
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
            ViewData["ComputerID"] = new SelectList(_context.Computers, "ComputerID", "ComputerIP", login.ComputerID);
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "FirstName", login.UserID);
            return View(login);
        }

        // GET: Logins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Logins
                .Include(l => l.Computer)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.LoginID == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // POST: Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var login = await _context.Logins.FindAsync(id);
            _context.Logins.Remove(login);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginExists(int id)
        {
            return _context.Logins.Any(e => e.LoginID == id);
        }
    }
}
