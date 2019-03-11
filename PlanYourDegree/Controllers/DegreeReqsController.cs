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
        public async Task<IActionResult> Index()
        {
            return View(await _context.DegreeReqs.ToListAsync());
        }

        // GET: DegreeReqs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreeReq = await _context.DegreeReqs
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
            return View();
        }

        // POST: DegreeReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DegreeReqId,DegreeId,CourseId")] DegreeReq degreeReq)
        {
            if (ModelState.IsValid)
            {
                _context.Add(degreeReq);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(degreeReq);
        }

        // POST: DegreeReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DegreeReqId,DegreeId,CourseId")] DegreeReq degreeReq)
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
