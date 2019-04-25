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
    public class DegreeReqsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DegreeReqsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DegreeReqs
        public async Task<IActionResult> Index(String sortOrder, string searchString)
        {
            ViewData["DegreeReqIdParm"] = sortOrder == "DegreeReqId" ? "DegreeReqId_desc" : "DegreeReqId";
            ViewData["DegreeIdParm"] = sortOrder == "DegreeId" ? "DegreeId_desc" : "DegreeId";
            ViewData["CourseParm"] = sortOrder == "Course" ? "Course_desc" : "Course";
            ViewData["RequirementNumberParm"] = sortOrder == "RequirementNumber" ? "RequirementNumber_desc" : "RequirementNumber";
            ViewData["CourseNameParm"] = sortOrder == "CourseName" ? "CourseName_desc" : "CourseName";

            ViewData["CurrentFilter"] = searchString;
            // var applicationDbContext = _context.DegreeReqs.Include(d => d.Course).Include(d => d.Degree);
            // return View(await applicationDbContext.ToListAsync());
            var degreereqs = from dr in _context.DegreeReqs select dr;
            if (!String.IsNullOrEmpty(searchString))
            {
                degreereqs = degreereqs.Where(dr => dr.DegreeReqId.Equals(searchString) ||
                dr.Degree.Equals(searchString) || dr.Course.Equals(searchString) || dr.RequirementNumber.Equals(searchString) ||
                dr.CourseName.Equals(searchString));
            }
            switch (sortOrder)
            {
                case "DegreeReqId":
                    degreereqs = degreereqs.OrderBy(dp => dp.DegreeReqId);
                    break;
                case "DegreeReqId_desc":
                    degreereqs = degreereqs.OrderByDescending(dp => dp.DegreeReqId);
                    break;
                case "DegreeId":
                    degreereqs = degreereqs.OrderBy(dp => dp.DegreeId);
                    break;
                case "DegreeId_desc":
                    degreereqs = degreereqs.OrderByDescending(dp => dp.DegreeId);
                    break;
                case "Course":
                    degreereqs = degreereqs.OrderBy(dp => dp.Course);
                    break;
                case "Course_desc":
                    degreereqs = degreereqs.OrderByDescending(dp => dp.Course);
                    break;
                case "RequirementNumber":
                    degreereqs = degreereqs.OrderBy(dp => dp.RequirementNumber);
                    break;
                case "RequirementNumber_desc":
                    degreereqs = degreereqs.OrderByDescending(dp => dp.RequirementNumber);
                    break;
                case "CourseName":
                    degreereqs = degreereqs.OrderBy(dp => dp.CourseName);
                    break;
                case "CourseName_desc":
                    degreereqs = degreereqs.OrderByDescending(dp => dp.CourseName);
                    break;
                default:
                    degreereqs = degreereqs.OrderBy(dp => dp.DegreeReqId);
                    break;
            }
            return View(await degreereqs.AsNoTracking().ToListAsync());
        }

        // GET: DegreeReqs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreeReq = await _context.DegreeReqs
                .Include(d => d.Course)
                .Include(d => d.Degree)
                .FirstOrDefaultAsync(m => m.DegreeReqId == id);
            if (degreeReq == null)
            {
                return NotFound();
            }

            return View(degreeReq);
        }

        // GET: DegreeReqs/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseAbbrev");
            ViewData["DegreeId"] = new SelectList(_context.Degrees, "DegreeId", "DegreeAbbrive");
            return View();
        }

        // POST: DegreeReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DegreeReqId,DegreeId,CourseId,RequirementNumber,CourseName")] DegreeReq degreeReq)
        {
            if (ModelState.IsValid)
            {
                _context.Add(degreeReq);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseAbbrev", degreeReq.CourseId);
            ViewData["DegreeId"] = new SelectList(_context.Degrees, "DegreeId", "DegreeAbbrive", degreeReq.DegreeId);
            return View(degreeReq);
        }

        // GET: DegreeReqs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreeReq = await _context.DegreeReqs.FindAsync(id);
            if (degreeReq == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseAbbrev", degreeReq.CourseId);
            ViewData["DegreeId"] = new SelectList(_context.Degrees, "DegreeId", "DegreeAbbrive", degreeReq.DegreeId);
            return View(degreeReq);
        }

        // POST: DegreeReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DegreeReqId,DegreeId,CourseId,RequirementNumber,CourseName")] DegreeReq degreeReq)
        {
            if (id != degreeReq.DegreeReqId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(degreeReq);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DegreeReqExists(degreeReq.DegreeReqId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseAbbrev", degreeReq.CourseId);
            ViewData["DegreeId"] = new SelectList(_context.Degrees, "DegreeId", "DegreeAbbrive", degreeReq.DegreeId);
            return View(degreeReq);
        }

        // GET: DegreeReqs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreeReq = await _context.DegreeReqs
                .Include(d => d.Course)
                .Include(d => d.Degree)
                .FirstOrDefaultAsync(m => m.DegreeReqId == id);
            if (degreeReq == null)
            {
                return NotFound();
            }

            return View(degreeReq);
        }

        // POST: DegreeReqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var degreeReq = await _context.DegreeReqs.FindAsync(id);
            _context.DegreeReqs.Remove(degreeReq);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DegreeReqExists(int id)
        {
            return _context.DegreeReqs.Any(e => e.DegreeReqId == id);
        }
    }
}
