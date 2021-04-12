using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FeGv3.Models;
using Microsoft.AspNetCore.Authorization;
using FeGv3.Models.ViewModels;

namespace FeGv3.Controllers
{
    public class SamplesController : Controller
    {
        private readonly FagElGamousContext _context;

        public SamplesController(FagElGamousContext context)
        {
            _context = context;
        }

        // GET: Samples/Create
        [Authorize(Roles = "Admin, Researcher")]
        [HttpGet]
        public IActionResult Create(double burialId)
        {
            Samples lastSample = _context.Samples.AsEnumerable().LastOrDefault();

            ViewData["BurialId"] = burialId;
            ViewData["SampleId"] = lastSample.SampleId + 1; //added here .Last() doesn't work
            return View();
        }

        // POST: Samples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Researcher")]
        public async Task<IActionResult> Create([Bind("BurialId,SampleId,Rack,Bag,Cluster,Date,PreviouslySampled,Notes,Initials")] Samples samples)
        {
            if (ModelState.IsValid)
            {
                _context.Add(samples);
                await _context.SaveChangesAsync();
                
                return RedirectToAction("BurialDetails", "Home", new { burialId = samples.BurialId });
            }
            ViewData["BurialId"] = samples.BurialId;
            return View(samples);
        }

        // GET: Samples/Edit/5
        [Authorize(Roles = "Admin, Researcher")]
        [HttpGet]
        public async Task<IActionResult> Edit(double? sampleId)
        {
            if (sampleId == null)
            {
                return NotFound();
            }

            var samples = await _context.Samples.FindAsync(sampleId);
            if (samples == null)
            {
                return NotFound();
            }
            ViewData["SampleId"] = sampleId;
            return View(samples);
        }

        // POST: Samples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Researcher")]
        public async Task<IActionResult> Edit([Bind("BurialId,SampleId,Rack,Bag,Cluster,Date,PreviouslySampled,Notes,Initials")] Samples samples)
        {
            /*if (id != samples.SampleId)
            {   this used a double id that was passed to the controller - not really needed
                return NotFound();
            }*/

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(samples);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SamplesExists(samples.SampleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("BurialDetails", "Home", new { burialId = samples.BurialId });
            }
            ViewData["BurialId"] = samples.BurialId;            
            return View(samples);
        }

        // GET: Samples/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(double? sampleId)
        {
            if (sampleId == null)
            {
                return NotFound();
            }

            var samples = await _context.Samples
                .Include(s => s.Burial)
                .FirstOrDefaultAsync(m => m.SampleId == sampleId);
            if (samples == null)
            {
                return NotFound();
            }

            return View(samples);
        }

        // POST: Samples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(double id)
        {
            var samples = await _context.Samples.FindAsync(id);

            double? currBurialId = samples.BurialId;

            _context.Samples.Remove(samples);
            await _context.SaveChangesAsync();

            return RedirectToAction("BurialDetails", "Home", new { burialId = currBurialId });
        }

        private bool SamplesExists(double id)
        {
            return _context.Samples.Any(e => e.SampleId == id);
        }
    }
}
