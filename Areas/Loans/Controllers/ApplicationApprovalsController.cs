using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoanManagementSystem.Data;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Areas.Loans.Controllers
{
    [Area("Loans")]
    public class ApplicationApprovalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationApprovalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Loans/ApplicationApprovals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ApplicationApproval.Include(a => a.LoanApplication);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Loans/ApplicationApprovals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationApproval = await _context.ApplicationApproval
                .Include(a => a.LoanApplication)
                .FirstOrDefaultAsync(m => m.ApprovalId == id);
            if (applicationApproval == null)
            {
                return NotFound();
            }

            return View(applicationApproval);
        }

        // GET: Loans/ApplicationApprovals/Create
        public IActionResult Create()
        {
            ViewData["LoanApplicationId"] = new SelectList(_context.LoanApplication, "LoanApplicationId", "ApplicationHolderName");
            return View();
        }

        // POST: Loans/ApplicationApprovals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApprovalId,ApplicationStatus,LoanApplicationId")] ApplicationApproval applicationApproval)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationApproval);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoanApplicationId"] = new SelectList(_context.LoanApplication, "LoanApplicationId", "ApplicationHolderName", applicationApproval.LoanApplicationId);
            return View(applicationApproval);
        }

        // GET: Loans/ApplicationApprovals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationApproval = await _context.ApplicationApproval.FindAsync(id);
            if (applicationApproval == null)
            {
                return NotFound();
            }
            ViewData["LoanApplicationId"] = new SelectList(_context.LoanApplication, "LoanApplicationId", "ApplicationHolderName", applicationApproval.LoanApplicationId);
            return View(applicationApproval);
        }

        // POST: Loans/ApplicationApprovals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApprovalId,ApplicationStatus,LoanApplicationId")] ApplicationApproval applicationApproval)
        {
            if (id != applicationApproval.ApprovalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationApproval);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationApprovalExists(applicationApproval.ApprovalId))
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
            ViewData["LoanApplicationId"] = new SelectList(_context.LoanApplication, "LoanApplicationId", "ApplicationHolderName", applicationApproval.LoanApplicationId);
            return View(applicationApproval);
        }

        // GET: Loans/ApplicationApprovals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationApproval = await _context.ApplicationApproval
                .Include(a => a.LoanApplication)
                .FirstOrDefaultAsync(m => m.ApprovalId == id);
            if (applicationApproval == null)
            {
                return NotFound();
            }

            return View(applicationApproval);
        }

        // POST: Loans/ApplicationApprovals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicationApproval = await _context.ApplicationApproval.FindAsync(id);
            _context.ApplicationApproval.Remove(applicationApproval);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationApprovalExists(int id)
        {
            return _context.ApplicationApproval.Any(e => e.ApprovalId == id);
        }
    }
}
