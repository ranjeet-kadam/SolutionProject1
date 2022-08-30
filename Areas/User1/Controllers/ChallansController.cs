using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EChallan1.Web.Data;
using EChallan1.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace EChallan1.Web.Areas.User1.Controllers
{
    [Area("User1")]
    [Authorize]
    public class ChallansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChallansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User1/Challans
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Challans.Include(c => c.Customer).Include(c => c.Issue);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: User1/Challans For User
        public async Task<IActionResult> Index1()
        {
            var applicationDbContext = _context.Challans.Include(c => c.Customer).Include(c => c.Issue);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: User1/Challans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var challan = await _context.Challans
                .Include(c => c.Customer)
                .Include(c => c.Issue)
                .FirstOrDefaultAsync(m => m.ChallanID == id);
            if (challan == null)
            {
                return NotFound();
            }

            return View(challan);
        }

        // GET: User1/Challans/Create
        public IActionResult Create()
        {
            ViewData["Customerid"] = new SelectList(_context.Customer, "Customerid", "CarNumber");
            ViewData["IID"] = new SelectList(_context.Issue, "IID", "IssueDescription");
            return View();
        }

        // POST: User1/Challans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChallanID,ChallanNumber,ChallanDescription,Date,Fine,Customerid,IID")] Challan challan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(challan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Customerid"] = new SelectList(_context.Customer, "Customerid", "CarNumber", challan.Customerid);
            ViewData["IID"] = new SelectList(_context.Issue, "IID", "IssueDescription", challan.IID);
            return View(challan);
        }

        // GET: User1/Challans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var challan = await _context.Challans.FindAsync(id);
            if (challan == null)
            {
                return NotFound();
            }
            ViewData["Customerid"] = new SelectList(_context.Customer, "Customerid", "CarNumber", challan.Customerid);
            ViewData["IID"] = new SelectList(_context.Issue, "IID", "IssueDescription", challan.IID);
            return View(challan);
        }

        // POST: User1/Challans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChallanID,ChallanNumber,ChallanDescription,Date,Fine,Customerid,IID")] Challan challan)
        {
            if (id != challan.ChallanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(challan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChallanExists(challan.ChallanID))
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
            ViewData["Customerid"] = new SelectList(_context.Customer, "Customerid", "CarNumber", challan.Customerid);
            ViewData["IID"] = new SelectList(_context.Issue, "IID", "IssueDescription", challan.IID);
            return View(challan);
        }

        // GET: User1/Challans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var challan = await _context.Challans
                .Include(c => c.Customer)
                .Include(c => c.Issue)
                .FirstOrDefaultAsync(m => m.ChallanID == id);
            if (challan == null)
            {
                return NotFound();
            }

            return View(challan);
        }

        // POST: User1/Challans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var challan = await _context.Challans.FindAsync(id);
            _context.Challans.Remove(challan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChallanExists(int id)
        {
            return _context.Challans.Any(e => e.ChallanID == id);
        }
    }
}
