using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlanYourDegree_WS02.Data;
using PlanYourDegree_WS02.Models;

namespace PlanYourDegree_WS02.Controllers
{
    public class DegreePlanTermRequirementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DegreePlanTermRequirementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DegreePlanTermRequirements
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            //ViewData["StatusSortParm"] = String.IsNullOrEmpty(sortOrder) ? "status_desc" : "";
            ViewData["CreditSortParm"] = sortOrder == "Credits" ? "credit_desc" : "Credits";
            ViewData["TermsSortParm"] = sortOrder == "Terms" ? "term_desc" : "Term";
            ViewData["DegreeplanSortParm"] = sortOrder == "Degreeplans" ? "degreeplan_desc" : "Degreeplan";
            ViewData["CurrentFilter"] = searchString;
            var slots = from s in _context.DegreePlanTermRequirements
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                slots = slots.Where(s => s.TermID.ToString().Contains(searchString)
                                 || s.RequirementID.ToString().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Degreeplan_desc":
                    slots = slots.OrderByDescending(s => s.DegreePlanID);
                    break;
                case "credit_desc":
                    slots = slots.OrderBy(s => s.RequirementID);
                    break;
                case "term_desc":
                    slots = slots.OrderByDescending(s => s.TermID);
                    break;
                case "Cedits":
                    slots = slots.OrderBy(s => s.RequirementID);
                    break;
                case "Term":
                    slots = slots.OrderByDescending(s => s.TermID);
                    break;
                default:
                    slots = slots.OrderBy(s => s.DegreePlanTermRequirementId);
                    break;
            }
            //  var applicationDbContext = _context.Slots.Include(s => s.SlotId).Include(s => s.DegreePlan);
            //return View(await applicationDbContext.ToListAsync());
            return View(await slots.AsNoTracking().ToListAsync());
        }

        // GET: DegreePlanTermRequirements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreePlanTermRequirement = await _context.DegreePlanTermRequirements
                .Include(d => d.DegreePlan)
                .Include(d => d.Requirement)
                .FirstOrDefaultAsync(m => m.DegreePlanTermRequirementId == id);
            if (degreePlanTermRequirement == null)
            {
                return NotFound();
            }

            return View(degreePlanTermRequirement);
        }

        // GET: DegreePlanTermRequirements/Create
        public IActionResult Create()
        {
            ViewData["DegreePlanID"] = new SelectList(_context.DegreePlans, "DegreePlanId", "DegreePlanAbbrev");
            ViewData["RequirementID"] = new SelectList(_context.Requirements, "RequirementID", "CourseName");
            return View();
        }

        // POST: DegreePlanTermRequirements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DegreePlanTermRequirementId,DegreePlanID,TermID,RequirementID")] DegreePlanTermRequirement degreePlanTermRequirement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(degreePlanTermRequirement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DegreePlanID"] = new SelectList(_context.DegreePlans, "DegreePlanId", "DegreePlanAbbrev", degreePlanTermRequirement.DegreePlanID);
            ViewData["RequirementID"] = new SelectList(_context.Requirements, "RequirementID", "CourseName", degreePlanTermRequirement.RequirementID);
            return View(degreePlanTermRequirement);
        }

        // GET: DegreePlanTermRequirements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreePlanTermRequirement = await _context.DegreePlanTermRequirements.FindAsync(id);
            if (degreePlanTermRequirement == null)
            {
                return NotFound();
            }
            ViewData["DegreePlanID"] = new SelectList(_context.DegreePlans, "DegreePlanId", "DegreePlanAbbrev", degreePlanTermRequirement.DegreePlanID);
            ViewData["RequirementID"] = new SelectList(_context.Requirements, "RequirementID", "CourseName", degreePlanTermRequirement.RequirementID);
            return View(degreePlanTermRequirement);
        }

        // POST: DegreePlanTermRequirements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DegreePlanTermRequirementId,DegreePlanID,TermID,RequirementID")] DegreePlanTermRequirement degreePlanTermRequirement)
        {
            if (id != degreePlanTermRequirement.DegreePlanTermRequirementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(degreePlanTermRequirement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DegreePlanTermRequirementExists(degreePlanTermRequirement.DegreePlanTermRequirementId))
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
            ViewData["DegreePlanID"] = new SelectList(_context.DegreePlans, "DegreePlanId", "DegreePlanAbbrev", degreePlanTermRequirement.DegreePlanID);
            ViewData["RequirementID"] = new SelectList(_context.Requirements, "RequirementID", "CourseName", degreePlanTermRequirement.RequirementID);
            return View(degreePlanTermRequirement);
        }

        // GET: DegreePlanTermRequirements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreePlanTermRequirement = await _context.DegreePlanTermRequirements
                .Include(d => d.DegreePlan)
                .Include(d => d.Requirement)
                .FirstOrDefaultAsync(m => m.DegreePlanTermRequirementId == id);
            if (degreePlanTermRequirement == null)
            {
                return NotFound();
            }

            return View(degreePlanTermRequirement);
        }

        // POST: DegreePlanTermRequirements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var degreePlanTermRequirement = await _context.DegreePlanTermRequirements.FindAsync(id);
            _context.DegreePlanTermRequirements.Remove(degreePlanTermRequirement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DegreePlanTermRequirementExists(int id)
        {
            return _context.DegreePlanTermRequirements.Any(e => e.DegreePlanTermRequirementId == id);
        }
    }
}
