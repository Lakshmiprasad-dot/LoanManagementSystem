using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoanManagementSystem.Data;
using LoanManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace LoanManagementSystem.Areas.Loans.Controllers
{
    [Area("Loans")]
    [Authorize(Roles = "AppAdmin")]
    public class LoanEligibilitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoanEligibilitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Loans/LoanEligibilities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LoanEligibility.Include(l => l.LoanType);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> Index1()
        {
            var applicationDbContext = _context.LoanEligibility.Include(l => l.LoanType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Loans/LoanEligibilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanEligibility = await _context.LoanEligibility
                .Include(l => l.LoanType)
                .FirstOrDefaultAsync(m => m.LoanEligibilityId == id);
            if (loanEligibility == null)
            {
                return NotFound();
            }

            return View(loanEligibility);
        }

        // GET: Loans/LoanEligibilities/Create
        public IActionResult Create()
        {
            ViewData["LoanId"] = new SelectList(_context.LoanTypes, "LoanId", "LoanTypeName");
            return View();
        }

        // POST: Loans/LoanEligibilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoanEligibilityId,AgeLimit,Nationality,TypeOfEmployment,LoanId")] LoanEligibility loanEligibility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loanEligibility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoanId"] = new SelectList(_context.LoanTypes, "LoanId", "LoanTypeName", loanEligibility.LoanId);
            return View(loanEligibility);
        }

        // GET: Loans/LoanEligibilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanEligibility = await _context.LoanEligibility.FindAsync(id);
            if (loanEligibility == null)
            {
                return NotFound();
            }
            ViewData["LoanId"] = new SelectList(_context.LoanTypes, "LoanId", "LoanTypeName", loanEligibility.LoanId);
            return View(loanEligibility);
        }

        // POST: Loans/LoanEligibilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoanEligibilityId,AgeLimit,Nationality,TypeOfEmployment,LoanId")] LoanEligibility loanEligibility)
        {
            if (id != loanEligibility.LoanEligibilityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loanEligibility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanEligibilityExists(loanEligibility.LoanEligibilityId))
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
            ViewData["LoanId"] = new SelectList(_context.LoanTypes, "LoanId", "LoanTypeName", loanEligibility.LoanId);
            return View(loanEligibility);
        }

        // GET: Loans/LoanEligibilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanEligibility = await _context.LoanEligibility
                .Include(l => l.LoanType)
                .FirstOrDefaultAsync(m => m.LoanEligibilityId == id);
            if (loanEligibility == null)
            {
                return NotFound();
            }

            return View(loanEligibility);
        }

        // POST: Loans/LoanEligibilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loanEligibility = await _context.LoanEligibility.FindAsync(id);
            _context.LoanEligibility.Remove(loanEligibility);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoanEligibilityExists(int id)
        {
            return _context.LoanEligibility.Any(e => e.LoanEligibilityId == id);
        }
    }
}
