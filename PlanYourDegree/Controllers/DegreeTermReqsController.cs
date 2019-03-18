using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlanYourDegree.Data;
using PlanYourDegree.Models;

namespace PlanYourDegree.Controllers
{
    public class DegreeTermReqsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DegreeTermReqsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DegreeTermReqs
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["DegreePlanIDParam"] = String.IsNullOrEmpty(sortOrder) ? "degreeplanid_desc" : "degreeplanid";
            ViewData["TermIDParam"] = String.IsNullOrEmpty(sortOrder) ? "termid_desc" : "termid";
            ViewData["CourseIDParam"] = String.IsNullOrEmpty(sortOrder) ? "courseid_desc" : "courseid";

            var degreetermreq = from dtr in _context.DegreeTermReqs
                                select dtr;
            if (!String.IsNullOrEmpty(searchString))
            {
                degreetermreq = degreetermreq.Where(dtr => dtr.DegreeTermReqId.Equals(int.Parse(searchString))
                                       || dtr.TermId.Equals(int.Parse(searchString))
                                       || dtr.CourseId.Equals(int.Parse(searchString)));
            }

            switch (sortOrder)
            {
                case "degreeplanid_desc":
                    degreetermreq = degreetermreq.OrderByDescending(dtr => dtr.DegreePlanId);
                    break;
                case "degreeplanid":
                    degreetermreq = degreetermreq.OrderBy(dtr => dtr.DegreePlanId);
                    break;
                case "termid_desc":
                    degreetermreq = degreetermreq.OrderByDescending(dtr => dtr.TermId);
                    break;
                case "termid":
                    degreetermreq = degreetermreq.OrderBy(dtr => dtr.TermId);
                    break;
                case "courseid_desc":
                    degreetermreq = degreetermreq.OrderByDescending(dtr => dtr.CourseId);
                    break;
                case "courseid":
                    degreetermreq = degreetermreq.OrderBy(dtr => dtr.CourseId);
                    break;
                default:
                    degreetermreq = degreetermreq.OrderBy(dtr => dtr.DegreeTermReqId);
                    break;
            }


            //            var applicationDbContext = _context.DegreeTermReqs.Include(d => d.Course).Include(d => d.DegreePlan).Include(d => d.Term);
            //            return View(await applicationDbContext.ToListAsync());
             return View(await _context.DegreeTermReqs.Include(d => d.Course).Include(d => d.DegreePlan).Include(d => d.Term).ToListAsync());
          //  return View(await degreetermreq.AsNoTracking().ToListAsync());
        }

        // GET: DegreeTermReqs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreeTermReq = await _context.DegreeTermReqs
                .Include(d => d.Course)
                .Include(d => d.DegreePlan)
                .Include(d => d.Term)
                .FirstOrDefaultAsync(m => m.DegreeTermReqId == id);
            if (degreeTermReq == null)
            {
                return NotFound();
            }

            return View(degreeTermReq);
        }

        // GET: DegreeTermReqs/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseAbbrev");
            ViewData["DegreePlanId"] = new SelectList(_context.DegreePlans, "DegreePlanId", "DegreePlanAbbreve");
            ViewData["TermId"] = new SelectList(_context.Terms, "TermId", "TermId");
            return View();
        }

        // POST: DegreeTermReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DegreeTermReqId,DegreePlanId,TermId,CourseId")] DegreeTermReq degreeTermReq)
        {
            if (ModelState.IsValid)
            {
                _context.Add(degreeTermReq);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseAbbrev", degreeTermReq.CourseId);
            ViewData["DegreePlanId"] = new SelectList(_context.DegreePlans, "DegreePlanId", "DegreePlanAbbreve", degreeTermReq.DegreePlanId);
            ViewData["TermId"] = new SelectList(_context.Terms, "TermId", "TermId", degreeTermReq.TermId);
            return View(degreeTermReq);
        }

        // GET: DegreeTermReqs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreeTermReq = await _context.DegreeTermReqs.FindAsync(id);
            if (degreeTermReq == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseAbbrev", degreeTermReq.CourseId);
            ViewData["DegreePlanId"] = new SelectList(_context.DegreePlans, "DegreePlanId", "DegreePlanAbbreve", degreeTermReq.DegreePlanId);
            ViewData["TermId"] = new SelectList(_context.Terms, "TermId", "TermId", degreeTermReq.TermId);
            return View(degreeTermReq);
        }

        // POST: DegreeTermReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DegreeTermReqId,DegreePlanId,TermId,CourseId")] DegreeTermReq degreeTermReq)
        {
            if (id != degreeTermReq.DegreeTermReqId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(degreeTermReq);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DegreeTermReqExists(degreeTermReq.DegreeTermReqId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseAbbrev", degreeTermReq.CourseId);
            ViewData["DegreePlanId"] = new SelectList(_context.DegreePlans, "DegreePlanId", "DegreePlanAbbreve", degreeTermReq.DegreePlanId);
            ViewData["TermId"] = new SelectList(_context.Terms, "TermId", "TermId", degreeTermReq.TermId);
            return View(degreeTermReq);
        }

        // GET: DegreeTermReqs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreeTermReq = await _context.DegreeTermReqs
                .Include(d => d.Course)
                .Include(d => d.DegreePlan)
                .Include(d => d.Term)
                .FirstOrDefaultAsync(m => m.DegreeTermReqId == id);
            if (degreeTermReq == null)
            {
                return NotFound();
            }

            return View(degreeTermReq);
        }

        // POST: DegreeTermReqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var degreeTermReq = await _context.DegreeTermReqs.FindAsync(id);
            _context.DegreeTermReqs.Remove(degreeTermReq);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DegreeTermReqExists(int id)
        {
            return _context.DegreeTermReqs.Any(e => e.DegreeTermReqId == id);
        }
    }
}
