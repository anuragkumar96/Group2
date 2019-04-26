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
    public class DegreePlansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DegreePlansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DegreePlans
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["StudentidSortParm"] = sortOrder == "Studentid" ? "Studentid_desc" : "Studentid";
            ViewData["DegreePlanAbvSortParm"] = String.IsNullOrEmpty(sortOrder) ? "DegreeplanAbv_desc" : "";
            ViewData["DegreePlanNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "DegreePlanName_desc" : "";
            ViewData["DegreeidSortParm"] = sortOrder == "Degreesid" ? "Degreeid_desc" : "Degreeid";
            ViewData["CurrentFilter"] = searchString;
            var degreeplans = from s in _context.DegreePlans
                              select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                degreeplans = degreeplans.Where(s => s.DegreePlanAbbrev.Contains(searchString)
                                       || s.DegreePlanName.Contains(searchString) || s.StudentID.ToString().Contains(searchString) || s.DegreeID.ToString().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Studentid_desc":
                    degreeplans = degreeplans.OrderByDescending(s => s.StudentID);
                    break;
                case "Studentid":
                    degreeplans = degreeplans.OrderBy(s => s.StudentID);
                    break;
                case "DegreeplanAbv_desc":
                    degreeplans = degreeplans.OrderBy(s => s.DegreePlanAbbrev);
                    break;
                case "DegreePlanName_desc":
                    degreeplans = degreeplans.OrderBy(s => s.DegreePlanName);
                    break;
                case "Degreeid_desc":
                    degreeplans = degreeplans.OrderByDescending(s => s.DegreeID);
                    break;
                case "Degreeid":
                    degreeplans = degreeplans.OrderBy(s => s.DegreeID);
                    break;
                default:
                    degreeplans = degreeplans.OrderBy(s => s.DegreePlanId);
                    break;
            }
            return View(await degreeplans.AsNoTracking().ToListAsync());
        }

        // GET: DegreePlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreePlan = await _context.DegreePlans
                .Include(d => d.Degree)
                .Include(d => d.Student)
                .FirstOrDefaultAsync(m => m.DegreePlanId == id);
            if (degreePlan == null)
            {
                return NotFound();
            }

            return View(degreePlan);
        }

        // GET: DegreePlans/Create
        public IActionResult Create()
        {
            ViewData["DegreeID"] = new SelectList(_context.Degrees, "DegreeId", "DegreeAbrrev");
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentId", "First");
            return View();
        }

        // POST: DegreePlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DegreePlanId,DegreeID,StudentID,DegreePlanAbbrev,DegreePlanName,Done")] DegreePlan degreePlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(degreePlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DegreeID"] = new SelectList(_context.Degrees, "DegreeId", "DegreeAbrrev", degreePlan.DegreeID);
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentId", "First", degreePlan.StudentID);
            return View(degreePlan);
        }

        // GET: DegreePlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) { return NotFound(); }
            var studentDegreePlan = await _context.DegreePlans
                .Include(p => p.Degree).ThenInclude(pd => pd.Requirements)
                .Include(p => p.Student)
                .Include(p => p.StudentTerms).ThenInclude(pt => pt.DegreePlanTermRequirement)
                .SingleOrDefaultAsync(m => m.DegreePlanId == id);

            if (studentDegreePlan == null) { return NotFound(); }
            ViewData["DegreeId"] = new SelectList(_context.Degrees, "DegreeId", "DegreeAbrrev", studentDegreePlan.DegreeID);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "First", studentDegreePlan.StudentID);
            return View(studentDegreePlan);
        }

        // POST: DegreePlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DegreePlanId,DegreeID,StudentID,DegreePlanAbbrev,DegreePlanName")] DegreePlan degreePlan)
        {
            if (id != degreePlan.DegreePlanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(degreePlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DegreePlanExists(degreePlan.DegreePlanId))
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
            ViewData["DegreeID"] = new SelectList(_context.Degrees, "DegreeId", "DegreeAbrrev", degreePlan.DegreeID);
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentId", "First", degreePlan.StudentID);
            return View(degreePlan);
        }

        // GET: DegreePlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreePlan = await _context.DegreePlans
                .Include(d => d.Degree)
                .Include(d => d.Student)
                .FirstOrDefaultAsync(m => m.DegreePlanId == id);
            if (degreePlan == null)
            {
                return NotFound();
            }

            return View(degreePlan);
        }

        // POST: DegreePlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var degreePlan = await _context.DegreePlans.FindAsync(id);
            _context.DegreePlans.Remove(degreePlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DegreePlanExists(int id)
        {
            return _context.DegreePlans.Any(e => e.DegreePlanId == id);
        }
    }
}
