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
        public async Task<IActionResult> Index()
        {
            return View(await _context.DegreeTermReqs.ToListAsync());
        }

        // GET: DegreeTermReqs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreeTermReq = await _context.DegreeTermReqs
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
            return View();
        }

        // POST: DegreeTermReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DegreeTermReqId,DegreePlanId,StudentTermId,CourseId")] DegreeTermReq degreeTermReq)
        {
            if (ModelState.IsValid)
            {
                _context.Add(degreeTermReq);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(degreeTermReq);
        }

        // POST: DegreeTermReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DegreeTermReqId,DegreePlanId,StudentTermId,CourseId")] DegreeTermReq degreeTermReq)
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
