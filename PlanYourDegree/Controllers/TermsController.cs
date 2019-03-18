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
    public class TermsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TermsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Terms
        public async Task<IActionResult> Index(String sortOrder,String searchString)
        {
            ViewData["TermAbbrevParm"] = String.IsNullOrEmpty(sortOrder) ? "TermAbbrev_desc" : "TermAbbrev";
            ViewData["TermNameParm"] = String.IsNullOrEmpty(sortOrder) ? "TermName_desc" : "TermName";
            ViewData["CurrentFilter"] = searchString;

            var terms = from t in _context.Terms
                           select t;
            if (!String.IsNullOrEmpty(searchString))
            {
                terms = terms.Where(t => t.TermAbbrev.Contains(searchString)
                                       || t.TermName.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "TermAbbrev_desc":
                    terms = terms.OrderByDescending(t => t.TermAbbrev);
                    break;
                case "TermAbbrev":
                    terms = terms.OrderBy(t => t.TermAbbrev);
                    break;
                case "TermName_desc":
                    terms = terms.OrderByDescending(t => t.TermName);
                    break;
                case "TermName":
                    terms = terms.OrderBy(t => t.TermName);
                    break;

                default:
                    terms = terms.OrderBy(t => t.TermId);
                    break;
            }
            return View(await terms.AsNoTracking().ToListAsync());
        }
      
               


        // GET: Terms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var term = await _context.Terms
                .FirstOrDefaultAsync(m => m.TermId == id);
            if (term == null)
            {
                return NotFound();
            }

            return View(term);
        }

        // GET: Terms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Terms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TermId,TermAbbrev,TermName")] Term term)
        {
            if (ModelState.IsValid)
            {
                _context.Add(term);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(term);
        }

        // GET: Terms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var term = await _context.Terms.FindAsync(id);
            if (term == null)
            {
                return NotFound();
            }
            return View(term);
        }

        // POST: Terms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TermId,TermAbbrev,TermName")] Term term)
        {
            if (id != term.TermId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(term);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TermExists(term.TermId))
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
            return View(term);
        }

        // GET: Terms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var term = await _context.Terms
                .FirstOrDefaultAsync(m => m.TermId == id);
            if (term == null)
            {
                return NotFound();
            }

            return View(term);
        }

        // POST: Terms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var term = await _context.Terms.FindAsync(id);
            _context.Terms.Remove(term);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TermExists(int id)
        {
            return _context.Terms.Any(e => e.TermId == id);
        }
    }
}
