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
    public class DegreesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DegreesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Degrees
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["DegreeIdParm"] = sortOrder== "Id" ? "id_desc" : "Id";
            ViewData["NameSortParm"] = sortOrder== "Name" ? "name_desc" : "Name";
            ViewData["NAbbreSortParm"] = sortOrder== "Abbre" ? "abbre_desc" : "Abbre";
            ViewData["CurrentFilter"] = searchString;

           // ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            var degrees = from d in _context.Degrees
                          select d;
            if (!String.IsNullOrEmpty(searchString))
            {
                degrees = degrees.Where(d => d.DegreeAbbrive.Contains(searchString) || d.DegreeName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "id_desc":
                    degrees = degrees.OrderByDescending(d => d.DegreeId);
                    break;
                case "Name":
                    degrees = degrees.OrderBy(d => d.DegreeName);
                    break; 
                case "name_desc":
                    degrees = degrees.OrderByDescending(d => d.DegreeName);
                    break;
                case "abbre_desc":
                    degrees = degrees.OrderByDescending(d => d.DegreeAbbrive);
                    break;
                case "Abbre":
                        degrees = degrees.OrderBy(d => d.DegreeAbbrive);
                    break;
                case "Id":
                default:
                    degrees = degrees.OrderBy(d => d.DegreeId);
                    break;
               
            }
            return View(await degrees.AsNoTracking().ToListAsync());
            //return View(await _context.Degrees.ToListAsync());
        }

        // GET: Degrees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degree = await _context.Degrees
                .FirstOrDefaultAsync(m => m.DegreeId == id);
            if (degree == null)
            {
                return NotFound();
            }

            return View(degree);
        }

        // GET: Degrees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Degrees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DegreeId,DegreeAbbrive,DegreeName")] Degree degree)
        {
            if (ModelState.IsValid)
            {
                _context.Add(degree);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(degree);
        }

        // GET: Degrees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degree = await _context.Degrees.FindAsync(id);
            if (degree == null)
            {
                return NotFound();
            }
            return View(degree);
        }

        // POST: Degrees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DegreeId,DegreeAbbrive,DegreeName")] Degree degree)
        {
            if (id != degree.DegreeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(degree);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DegreeExists(degree.DegreeId))
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
            return View(degree);
        }

        // GET: Degrees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degree = await _context.Degrees
                .FirstOrDefaultAsync(m => m.DegreeId == id);
            if (degree == null)
            {
                return NotFound();
            }

            return View(degree);
        }

        // POST: Degrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var degree = await _context.Degrees.FindAsync(id);
            _context.Degrees.Remove(degree);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DegreeExists(int id)
        {
            return _context.Degrees.Any(e => e.DegreeId == id);
        }
    }
}
