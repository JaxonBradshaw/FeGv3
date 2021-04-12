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
    public class BiologyController : Controller
    {
        private readonly FagElGamousContext _context;

        public BiologyController(FagElGamousContext context)
        {
            _context = context;
        }

        // GET: Biology/Create
        [Authorize(Roles = "Admin, Researcher")]
        public IActionResult Create()
        {
            ViewData["BurialId"] = new SelectList(_context.MainTbl, "BurialId", "BurialId");
            return View();
        }

        // POST: Biology/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for         
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Researcher")]
        public async Task<IActionResult> Create([Bind("BurialId,BioId,HairTaken,SoftTissueTaken,BoneTaken,ToothTaken,TextileTaken,DescriptionOfTaken,ArtifactFound,EstimateAge,EstimateLivingStature,ToothAttrition,ToothEruption,PathologyAnomalies,EpiphysealUnion,Burialsampletaken")] Biology biology)
        {
            if (ModelState.IsValid)
            {
                _context.Add(biology);
                await _context.SaveChangesAsync();

                return RedirectToAction("BurialDetails", "Home", new { burialId = biology.BurialId });
            }
            ViewData["BurialId"] = new SelectList(_context.MainTbl, "BurialId", "BurialId", biology.BurialId);
            return View(biology);
        }

        // GET: Biology/Edit/5
        [Authorize(Roles = "Admin, Researcher")]
        public async Task<IActionResult> Edit(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biology = await _context.Biology.FindAsync(id);
            if (biology == null)
            {
                return NotFound();
            }
            ViewData["BurialId"] = new SelectList(_context.MainTbl, "BurialId", "BurialId", biology.BurialId);
            return View(biology);
        }

        // POST: Biology/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Researcher")]
        public async Task<IActionResult> Edit(double id, [Bind("BurialId,BioId,HairTaken,SoftTissueTaken,BoneTaken,ToothTaken,TextileTaken,DescriptionOfTaken,ArtifactFound,EstimateAge,EstimateLivingStature,ToothAttrition,ToothEruption,PathologyAnomalies,EpiphysealUnion,Burialsampletaken")] Biology biology)
        {
            if (id != biology.BioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biology);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiologyExists(biology.BioId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("BurialDetails", "Home", new { burialId = biology.BurialId });
            }
            ViewData["BurialId"] = new SelectList(_context.MainTbl, "BurialId", "BurialId", biology.BurialId);
            return View(biology);
        }

        // GET: Biology/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biology = await _context.Biology
                .Include(b => b.Burial)
                .FirstOrDefaultAsync(m => m.BioId == id);
            if (biology == null)
            {
                return NotFound();
            }

            return View(biology);
        }

        // POST: Biology/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(double id)
        {
            var biology = await _context.Biology.FindAsync(id);
            _context.Biology.Remove(biology);
            await _context.SaveChangesAsync();

            return RedirectToAction("BurialDetails", "Home", new { burialId = biology.BurialId });
        }

        private bool BiologyExists(double id)
        {
            return _context.Biology.Any(e => e.BioId == id);
        }
    }
}