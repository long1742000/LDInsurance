using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LDInsurance.Data;
using LDInsurance.Models;
using Microsoft.AspNetCore.Http;

namespace LDInsurance.Controllers
{
    public class TransactionHistoriesController : Controller
    {
        private readonly LDInsuranceContext _context;

        public TransactionHistoriesController(LDInsuranceContext context)
        {
            _context = context;
        }

        // GET: TransactionHistories
        public IActionResult Index(int? id)
        {
            HttpContext.Session.SetString("PageBeing", "TransactionHistories");
            if (HttpContext.Session.GetInt32("ID") == null)
            {

                return RedirectToAction("Login", "Accounts");
            }
            else
            {
                var TransactionHistoriesContext = _context.TransactionHistory.Where(p => p.AccountID == id);
                return View(TransactionHistoriesContext.ToList());
            }
        }

        // GET: TransactionHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionHistory = await _context.TransactionHistory
                .Include(t => t.Account)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (transactionHistory == null)
            {
                return NotFound();
            }

            return View(transactionHistory);
        }

        // GET: TransactionHistories/Create
        public IActionResult Create()
        {
            ViewData["AccountID"] = new SelectList(_context.Accounts, "ID", "Name");
            return View();
        }

        // POST: TransactionHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AccountID,InsuranceID,Card,Date,Price,Status")] TransactionHistory transactionHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transactionHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountID"] = new SelectList(_context.Accounts, "ID", "Name", transactionHistory.AccountID);
            return View(transactionHistory);
        }

        // GET: TransactionHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionHistory = await _context.TransactionHistory.FindAsync(id);
            if (transactionHistory == null)
            {
                return NotFound();
            }
            ViewData["AccountID"] = new SelectList(_context.Accounts, "ID", "Name", transactionHistory.AccountID);
            return View(transactionHistory);
        }

        // POST: TransactionHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AccountID,InsuranceID,Card,Date,Price,Status")] TransactionHistory transactionHistory)
        {
            if (id != transactionHistory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transactionHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionHistoryExists(transactionHistory.ID))
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
            ViewData["AccountID"] = new SelectList(_context.Accounts, "ID", "Name", transactionHistory.AccountID);
            return View(transactionHistory);
        }

        // GET: TransactionHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionHistory = await _context.TransactionHistory
                .Include(t => t.Account)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (transactionHistory == null)
            {
                return NotFound();
            }

            return View(transactionHistory);
        }

        // POST: TransactionHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionHistory = await _context.TransactionHistory.FindAsync(id);
            _context.TransactionHistory.Remove(transactionHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionHistoryExists(int id)
        {
            return _context.TransactionHistory.Any(e => e.ID == id);
        }

        public IActionResult Pay()
        {
            HttpContext.Session.SetString("PageBeing", "TransactionHistories");
            if (HttpContext.Session.GetInt32("ID") == null)
            {

                return RedirectToAction("Login", "Accounts");
            }
            else
            {
                ViewData["AccountID"] = new SelectList(_context.Accounts, "ID", "Name");
                return View();
            }
        }

        [HttpPost]
        public IActionResult Pay([Bind("ID,AccountID,InsuranceID,Card,Date,Price,Status")] TransactionHistory transactionHistory)
        {
            transactionHistory.AccountID = HttpContext.Session.GetInt32("ID");
            transactionHistory.Status = true;
            transactionHistory.Date = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(transactionHistory);
                _context.SaveChanges();
                return RedirectToAction("Pay", "TransactionHistories");
            }
            ViewData["AccountID"] = new SelectList(_context.Accounts, "ID", "Name", transactionHistory.AccountID);
            return View();
        }

        public IActionResult Thanks()
        {
            return View();
        }

    }
}
