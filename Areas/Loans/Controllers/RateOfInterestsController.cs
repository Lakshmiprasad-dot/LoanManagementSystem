﻿using System;
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
    public class RateOfInterestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RateOfInterestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Loans/RateOfInterests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RateOfInterests.Include(r => r.LoanType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Loans/RateOfInterests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rateOfInterest = await _context.RateOfInterests
                .Include(r => r.LoanType)
                .FirstOrDefaultAsync(m => m.RateOfInterestId == id);
            if (rateOfInterest == null)
            {
                return NotFound();
            }

            return View(rateOfInterest);
        }

        // GET: Loans/RateOfInterests/Create
        public IActionResult Create()
        {
            ViewData["LoanId"] = new SelectList(_context.LoanTypes, "LoanId", "LoanTypeName");
            return View();
        }

        // POST: Loans/RateOfInterests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RateOfInterestId,LoanAmount1,LoanAmount2,LoanId")] RateOfInterest rateOfInterest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rateOfInterest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoanId"] = new SelectList(_context.LoanTypes, "LoanId", "LoanTypeName", rateOfInterest.LoanId);
            return View(rateOfInterest);
        }

        // GET: Loans/RateOfInterests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rateOfInterest = await _context.RateOfInterests.FindAsync(id);
            if (rateOfInterest == null)
            {
                return NotFound();
            }
            ViewData["LoanId"] = new SelectList(_context.LoanTypes, "LoanId", "LoanTypeName", rateOfInterest.LoanId);
            return View(rateOfInterest);
        }

        // POST: Loans/RateOfInterests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RateOfInterestId,LoanAmount1,LoanAmount2,LoanId")] RateOfInterest rateOfInterest)
        {
            if (id != rateOfInterest.RateOfInterestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rateOfInterest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RateOfInterestExists(rateOfInterest.RateOfInterestId))
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
            ViewData["LoanId"] = new SelectList(_context.LoanTypes, "LoanId", "LoanTypeName", rateOfInterest.LoanId);
            return View(rateOfInterest);
        }

        // GET: Loans/RateOfInterests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rateOfInterest = await _context.RateOfInterests
                .Include(r => r.LoanType)
                .FirstOrDefaultAsync(m => m.RateOfInterestId == id);
            if (rateOfInterest == null)
            {
                return NotFound();
            }

            return View(rateOfInterest);
        }

        // POST: Loans/RateOfInterests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rateOfInterest = await _context.RateOfInterests.FindAsync(id);
            _context.RateOfInterests.Remove(rateOfInterest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RateOfInterestExists(int id)
        {
            return _context.RateOfInterests.Any(e => e.RateOfInterestId == id);
        }
    }
}
