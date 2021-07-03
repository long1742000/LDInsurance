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
    public class InsuranceRegistrationsController : Controller
    {
        private readonly LDInsuranceContext _context;

        public InsuranceRegistrationsController(LDInsuranceContext context)
        {
            _context = context;
        }

        // GET: InsuranceRegistrations
        public async Task<IActionResult> Index()
        {
            var lDInsuranceContext = _context.InsuranceRegistrations.Include(i => i.Insurance).Include(i => i.Vehicle);
            return View(await lDInsuranceContext.ToListAsync());
        }

        // GET: InsuranceRegistrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceRegistration = await _context.InsuranceRegistrations
                .Include(i => i.Insurance)
                .Include(i => i.Vehicle)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (insuranceRegistration == null)
            {
                return NotFound();
            }

            return View(insuranceRegistration);
        }

        // GET: InsuranceRegistrations/Create
        public IActionResult Create()
        {
            ViewData["InsuranceID"] = new SelectList(_context.Insurances, "ID", "ID");
            ViewData["VehicleID"] = new SelectList(_context.Vehicles, "ID", "ID");
            return View();
        }

        // POST: InsuranceRegistrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,VehicleID,InsuranceID,StartDate,EndDate,Price,Status")] InsuranceRegistration insuranceRegistration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insuranceRegistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InsuranceID"] = new SelectList(_context.Insurances, "ID", "ID", insuranceRegistration.InsuranceID);
            ViewData["VehicleID"] = new SelectList(_context.Vehicles, "ID", "ID", insuranceRegistration.VehicleID);
            return View(insuranceRegistration);
        }

        // GET: InsuranceRegistrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceRegistration = await _context.InsuranceRegistrations.FindAsync(id);
            if (insuranceRegistration == null)
            {
                return NotFound();
            }
            ViewData["InsuranceID"] = new SelectList(_context.Insurances, "ID", "ID", insuranceRegistration.InsuranceID);
            ViewData["VehicleID"] = new SelectList(_context.Vehicles, "ID", "ID", insuranceRegistration.VehicleID);
            return View(insuranceRegistration);
        }

        // POST: InsuranceRegistrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,VehicleID,InsuranceID,StartDate,EndDate,Price,Status")] InsuranceRegistration insuranceRegistration)
        {
            if (id != insuranceRegistration.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insuranceRegistration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsuranceRegistrationExists(insuranceRegistration.ID))
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
            ViewData["InsuranceID"] = new SelectList(_context.Insurances, "ID", "ID", insuranceRegistration.InsuranceID);
            ViewData["VehicleID"] = new SelectList(_context.Vehicles, "ID", "ID", insuranceRegistration.VehicleID);
            return View(insuranceRegistration);
        }

        // GET: InsuranceRegistrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceRegistration = await _context.InsuranceRegistrations
                .Include(i => i.Insurance)
                .Include(i => i.Vehicle)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (insuranceRegistration == null)
            {
                return NotFound();
            }

            return View(insuranceRegistration);
        }

        // POST: InsuranceRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insuranceRegistration = await _context.InsuranceRegistrations.FindAsync(id);
            _context.InsuranceRegistrations.Remove(insuranceRegistration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsuranceRegistrationExists(int id)
        {
            return _context.InsuranceRegistrations.Any(e => e.ID == id);
        }

        public IActionResult Register()
        {
            HttpContext.Session.SetString("PageBeing", "Insurances");
            if (HttpContext.Session.GetInt32("ID") == null)
            {

                return RedirectToAction("Login", "Accounts");
            }
            else
            {
                ViewData["InsuranceID"] = new SelectList(_context.Insurances, "ID", "ID");
                ViewData["VehicleID"] = new SelectList(_context.Vehicles, "ID", "ID");
                return View();
            }
        }

        [HttpPost]
        public IActionResult Register([Bind("ID,VehicleID,InsuranceID,StartDate,EndDate,Price,Status")] InsuranceRegistration vehicle)
        {
            vehicle.Status = true;
            vehicle.StartDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                _context.SaveChanges();
                return RedirectToAction("Index", "InsuranceRegistrations");
            }
            ViewData["InsuranceID"] = new SelectList(_context.Insurances, "ID", "ID");
            ViewData["VehicleID"] = new SelectList(_context.Vehicles, "ID", "ID");
            return View();

        }
    }
}
