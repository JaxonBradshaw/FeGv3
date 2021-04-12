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
    public class BonesController : Controller
    {
        private readonly FagElGamousContext _context;

        public BonesController(FagElGamousContext context)
        {
            _context = context;
        }

        // GET: Bones/Create
        [Authorize(Roles = "Admin, Researcher")]
        public IActionResult Create()
        {
            ViewData["BurialId"] = new SelectList(_context.MainTbl, "BurialId", "BurialId");
            return View();
        }

        // POST: Bones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Researcher")]
        public async Task<IActionResult> Create([Bind("BurialId,BoneId,BasilarSuture,VentralArc,SubpubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedialIpRamus,DorsalPitting,ForemanMagnum,FemurHead,HumerusHead,Osteophytosis,PubicSymphysis,BoneLength,MedialClavicle,IliacCrest,FemurDiameter,Humerus,FemurLength,HumerusLength,TibiaLength,Robust,SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth,OsteologyNotes,BurialArtifactDescription,BuriedWithArtifacts,GilesGender")] Bones bones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bones);
                await _context.SaveChangesAsync();

                return RedirectToAction("BurialDetails", "Home", new { burialId = bones.BurialId });
            }
            ViewData["BurialId"] = new SelectList(_context.MainTbl, "BurialId", "BurialId", bones.BurialId);
            return View(bones);
        }

        // GET: Bones/Edit/5
        [Authorize(Roles = "Admin, Researcher")]
        public async Task<IActionResult> Edit(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bones = await _context.Bones.FindAsync(id);
            if (bones == null)
            {
                return NotFound();
            }
            ViewData["BurialId"] = new SelectList(_context.MainTbl, "BurialId", "BurialId", bones.BurialId);
            return View(bones);
        }

        // POST: Bones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Researcher")]
        public async Task<IActionResult> Edit(double id, [Bind("BurialId,BoneId,BasilarSuture,VentralArc,SubpubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedialIpRamus,DorsalPitting,ForemanMagnum,FemurHead,HumerusHead,Osteophytosis,PubicSymphysis,BoneLength,MedialClavicle,IliacCrest,FemurDiameter,Humerus,FemurLength,HumerusLength,TibiaLength,Robust,SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth,OsteologyNotes,BurialArtifactDescription,BuriedWithArtifacts,GilesGender")] Bones bones)
        {
            if (id != bones.BoneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BonesExists(bones.BoneId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("BurialDetails", "Home", new { burialId = bones.BurialId });
            }
            ViewData["BurialId"] = new SelectList(_context.MainTbl, "BurialId", "BurialId", bones.BurialId);
            return View(bones);
        }

        // GET: Bones/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bones = await _context.Bones
                .Include(b => b.Burial)
                .FirstOrDefaultAsync(m => m.BoneId == id);
            if (bones == null)
            {
                return NotFound();
            }

            return View(bones);
        }

        // POST: Bones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(double id)
        {
            var bones = await _context.Bones.FindAsync(id);
            _context.Bones.Remove(bones);
            await _context.SaveChangesAsync();

            return RedirectToAction("BurialDetails", "Home", new { burialId = bones.BurialId });
        }

        private bool BonesExists(double id)
        {
            return _context.Bones.Any(e => e.BoneId == id);
        }
    }
}
