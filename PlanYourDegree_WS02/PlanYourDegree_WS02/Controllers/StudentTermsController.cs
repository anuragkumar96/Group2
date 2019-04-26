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
    public class StudentTermsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentTermsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentTerms
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {

            ViewData["TermLabelSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Terms_desc" : "";
            ViewData["TermSortParm"] = sortOrder == "Term" ? "term_desc" : "Term";
            // ViewData["StudentSortParm"] = sortOrder == "StudentID" ? "studentID_desc" : "StudentID";
            ViewData["DegreePlanIDParm"] = sortOrder == "DegreePlanID" ? "degreePlanID_desc" : "DegreePlanID";
            ViewData["CurrentFilter"] = searchString;
            var studentTerms = from s in _context.StudentTerms
                               select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                studentTerms = studentTerms.Where(s => s.Term.ToString().Contains(searchString)
                                 || s.TermLabel.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "degreePlanID_desc":
                    studentTerms = studentTerms.OrderByDescending(s => s.DegreePlanId);
                    break;
                case "DegreePlanID":
                    studentTerms = studentTerms.OrderBy(s => s.DegreePlanId);
                    break;

                case "Terms_desc":
                    studentTerms = studentTerms.OrderByDescending(s => s.TermLabel);
                    break;
                case "Term":
                    studentTerms = studentTerms.OrderBy(s => s.Term);
                    break;

                case "term_desc":
                    studentTerms = studentTerms.OrderByDescending(s => s.Term);
                    break;
                default:
                    studentTerms = studentTerms.OrderBy(s => s.StudentTermId);
                    break;
            }
            //var applicationDbContext = _context.StudentTerms.Include(s => s.StudentTermId).Include(s => s.DegreePlan);
            //return View(await applicationDbContext.ToListAsync());
            return View(await studentTerms.AsNoTracking().ToListAsync());
        }

        // GET: StudentTerms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTerm = await _context.StudentTerms
                .Include(s => s.DegreePlan)
                .FirstOrDefaultAsync(m => m.StudentTermId == id);
            if (studentTerm == null)
            {
                return NotFound();
            }

            return View(studentTerm);
        }

        // GET: StudentTerms/Create
        public IActionResult Create()
        {
            ViewData["DegreePlanId"] = new SelectList(_context.DegreePlans, "DegreePlanId", "DegreePlanAbbrev");
            return View();
        }

        // POST: StudentTerms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentTermId,Term,TermLabel,DegreePlanId")] StudentTerm studentTerm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentTerm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DegreePlanId"] = new SelectList(_context.DegreePlans, "DegreePlanId", "DegreePlanAbbrev", studentTerm.DegreePlanId);
            return View(studentTerm);
        }

        // GET: StudentTerms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTerm = await _context.StudentTerms.FindAsync(id);
            if (studentTerm == null)
            {
                return NotFound();
            }
            ViewData["DegreePlanId"] = new SelectList(_context.DegreePlans, "DegreePlanId", "DegreePlanAbbrev", studentTerm.DegreePlanId);
            return View(studentTerm);
        }

        // POST: StudentTerms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentTermId,Term,TermLabel,DegreePlanId")] StudentTerm studentTerm)
        {
            if (id != studentTerm.StudentTermId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentTerm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentTermExists(studentTerm.StudentTermId))
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
            ViewData["DegreePlanId"] = new SelectList(_context.DegreePlans, "DegreePlanId", "DegreePlanAbbrev", studentTerm.DegreePlanId);
            return View(studentTerm);
        }

        // GET: StudentTerms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTerm = await _context.StudentTerms
                .Include(s => s.DegreePlan)
                .FirstOrDefaultAsync(m => m.StudentTermId == id);
            if (studentTerm == null)
            {
                return NotFound();
            }

            return View(studentTerm);
        }

        // POST: StudentTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentTerm = await _context.StudentTerms.FindAsync(id);
            _context.StudentTerms.Remove(studentTerm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentTermExists(int id)
        {
            return _context.StudentTerms.Any(e => e.StudentTermId == id);
        }
    }
}
