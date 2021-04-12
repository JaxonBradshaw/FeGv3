using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FeGv3.Models;
using Microsoft.AspNetCore.Authorization;

namespace FeGv3.Controllers
{
    public class CarbonsController : Controller
    {
        private readonly FagElGamousContext _context;

        public CarbonsController(FagElGamousContext context)
        {
            _context = context;
        }

        // GET: Carbons/Create
        [Authorize(Roles = "Admin, Researcher")]
        [HttpGet]
        public IActionResult Create(double sampleId)
        {
            Carbon lastCarbon = _context.Carbon.AsEnumerable().LastOrDefault();

            ViewData["SampleId"] = sampleId;
            ViewData["CarbonId"] = lastCarbon.CarbonId + 1;
            return View();
        }

        // POST: Carbons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Researcher")]        
        public async Task<IActionResult> Create([Bind("SampleId,CarbonId,Rack,Tube,Description,SizeMl,Foci,C14Sample2017,Location,QuestionS,Unknown,Conventional14cAgeBp,_14cCalendarDate,Calibrated95CalendarDateMax,Calibrated95CalendarDateMin,Calibrated95CalendarDateSpan,Calibrated95CalendarDateAvg,Category,Notes")] Carbon carbon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carbon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SampleId"] = carbon.SampleId;
            double? currBurialId = _context.Samples.Where(s => s.SampleId == carbon.SampleId).First().BurialId;
            return RedirectToAction("BurialDetails", "Home", new { burialId = currBurialId });
        }

        // GET: Carbons/Edit/5        
        [Authorize(Roles = "Admin, Researcher")]
        [HttpGet]
        public async Task<IActionResult> Edit(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carbon = await _context.Carbon.FindAsync(id);
            if (carbon == null)
            {
                return NotFound();
            }
            ViewData["SampleId"] = new SelectList(_context.Samples, "SampleId", "SampleId", carbon.SampleId);
            return View(carbon);
        }

        // POST: Carbons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Researcher")]        
        public async Task<IActionResult> Edit(double id, [Bind("SampleId,CarbonId,Rack,Tube,Description,SizeMl,Foci,C14Sample2017,Location,QuestionS,Unknown,Conventional14cAgeBp,_14cCalendarDate,Calibrated95CalendarDateMax,Calibrated95CalendarDateMin,Calibrated95CalendarDateSpan,Calibrated95CalendarDateAvg,Category,Notes")] Carbon carbon)
        {
            if (id != carbon.CarbonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carbon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarbonExists(carbon.CarbonId))
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
            ViewData["SampleId"] = carbon.SampleId;
            double? currBurialId = _context.Samples.Where(s => s.SampleId == carbon.SampleId).First().BurialId;
            return RedirectToAction("BurialDetails", "Home", new { burialId = currBurialId });
        }

        // GET: Carbons/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carbon = await _context.Carbon
                .Include(c => c.Sample)
                .FirstOrDefaultAsync(m => m.CarbonId == id);
            if (carbon == null)
            {
                return NotFound();
            }

            return View(carbon);
        }

        // POST: Carbons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Researcher")]        
        public async Task<IActionResult> DeleteConfirmed(double id)
        {
            var carbon = await _context.Carbon.FindAsync(id);
            double? currSampleId = carbon.SampleId;
            _context.Carbon.Remove(carbon);

            ViewData["SampleId"] = currSampleId;
            double? currBurialId = _context.Samples.Where(s => s.SampleId == currSampleId).First().BurialId;
            return RedirectToAction("BurialDetails", "Home", new { burialId = currBurialId });
        }

        private bool CarbonExists(double id)
        {
            return _context.Carbon.Any(e => e.CarbonId == id);
        }
    }
}
