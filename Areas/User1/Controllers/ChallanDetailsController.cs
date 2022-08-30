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
using System.Data;

namespace EChallan1.Web.Areas.User1.Controllers
{
    [Area("User1")]
    [Authorize]
    //[Authorize(Roles = "AppAdmin")]
    public class ChallanDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChallanDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User1/ChallanDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ChallanDetails.Include(c => c.Challan).Include(c => c.PaymentMethod);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: User1/ChallanDetails -- For User
        public async Task<IActionResult> Index1()
        {
            var applicationDbContext = _context.ChallanDetails.Include(c => c.Challan).Include(c => c.PaymentMethod);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: User1/ChallanDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var challanDetail = await _context.ChallanDetails
                .Include(c => c.Challan)
                .Include(c => c.PaymentMethod)
                .FirstOrDefaultAsync(m => m.CDID == id);
            if (challanDetail == null)
            {
                return NotFound();
            }

            return View(challanDetail);
        }

        // GET: User1/ChallanDetails/Create
        public IActionResult Create()
        {
            ViewData["CID"] = new SelectList(_context.Challans, "ChallanID", "ChallanNumber");
            ViewData["PID"] = new SelectList(_context.PaymentMethod, "PaymentMethodId", "PaymentStatus");
            return View();
        }

        // POST: User1/ChallanDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CDID,UpiId,PaymentStatus,CID,PID")] ChallanDetail challanDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(challanDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CID"] = new SelectList(_context.Challans, "ChallanID", "ChallanNumber", challanDetail.CID);
            ViewData["PID"] = new SelectList(_context.PaymentMethod, "PaymentMethodId", "PaymentStatus", challanDetail.PID);
            return View(challanDetail);
        }

        // GET: User1/ChallanDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var challanDetail = await _context.ChallanDetails.FindAsync(id);
            if (challanDetail == null)
            {
                return NotFound();
            }
            ViewData["CID"] = new SelectList(_context.Challans, "ChallanID", "ChallanNumber", challanDetail.CID);
            ViewData["PID"] = new SelectList(_context.PaymentMethod, "PaymentMethodId", "PaymentStatus", challanDetail.PID);
            return View(challanDetail);
        }

        // POST: User1/ChallanDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CDID,UpiId,PaymentStatus,CID,PID")] ChallanDetail challanDetail)
        {
            if (id != challanDetail.CDID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(challanDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChallanDetailExists(challanDetail.CDID))
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
            ViewData["CID"] = new SelectList(_context.Challans, "ChallanID", "ChallanNumber", challanDetail.CID);
            ViewData["PID"] = new SelectList(_context.PaymentMethod, "PaymentMethodId", "PaymentStatus", challanDetail.PID);
            return View(challanDetail);
        }

        // GET: User1/ChallanDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var challanDetail = await _context.ChallanDetails
                .Include(c => c.Challan)
                .Include(c => c.PaymentMethod)
                .FirstOrDefaultAsync(m => m.CDID == id);
            if (challanDetail == null)
            {
                return NotFound();
            }

            return View(challanDetail);
        }

        // POST: User1/ChallanDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var challanDetail = await _context.ChallanDetails.FindAsync(id);
            _context.ChallanDetails.Remove(challanDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChallanDetailExists(int id)
        {
            return _context.ChallanDetails.Any(e => e.CDID == id);
        }
    }
}
