using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FeGv3.Models;
using FeGv3.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace FeGv3.Controllers
{
    public class MainTblsController : Controller
    {
        private FagElGamousContext _context { get; set; }
        public int pageSize = 20;

        public MainTblsController(FagElGamousContext context)
        {
            _context = context;
        }
        //public IActionResult Index(int pageNum = 1)
        //{
        //    //return View(await _context.MainTbl.ToListAsync());

        //    int pageSize = 20;

        //    return View(new IndexViewModel
        //    {
        //        MainTbls = (_context.MainTbl
        //        .OrderBy(m => m.BurialId)
        //            .Skip((pageNum - 1) * pageSize)
        //            .Take(pageSize)),


        //        PaginationModel = new PaginationModel
        //        {
        //            ItemsPerPage = pageSize,
        //            CurrPage = pageNum,

        //            TotalItems = _context.MainTbl.Count()
        //        },
        //    });


        //}

        // GET: MainTbls
        [HttpGet]        
        public IActionResult Index(string option, string search, int pageNum = 1)
        {            
            if (System.String.IsNullOrEmpty(option) && System.String.IsNullOrEmpty(search))
            {
                return View(new IndexViewModel
                {
                    MainTbls = (_context.MainTbl
                        .OrderBy(m => m.BurialId)
                        .Skip((pageNum - 1) * pageSize)
                        .Take(pageSize)),
                    PaginationModel = new PaginationModel
                    {
                        ItemsPerPage = pageSize,
                        CurrPage = pageNum,
                        TotalItems = _context.MainTbl.Count()                        
                    },
                    Search = search,
                    Option = option
                });
            }            
            else
            {
                if (option == "LowNS")
                {
                    return View(new IndexViewModel
                    {
                        MainTbls = _context.MainTbl
                            .Where(x => x.LowPairNs.ToString() == search || search == null)
                            .OrderBy(m => m.BurialId)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .ToList(),
                        PaginationModel = new PaginationModel
                        {
                            ItemsPerPage = pageSize,
                            CurrPage = pageNum,
                            TotalItems = _context.MainTbl
                                .Where(x => x.LowPairNs.ToString() == search || search == null)
                                .Count()
                        },
                        Search = search,
                        Option = option
                    });                                        
                }
                else if (option == "LowEW")
                {
                    return View(new IndexViewModel
                    {
                        MainTbls = _context.MainTbl
                            .Where(x => x.LowPairEw.ToString() == search || search == null)
                            .OrderBy(m => m.BurialId)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .ToList(),
                        PaginationModel = new PaginationModel
                        {
                            ItemsPerPage = pageSize,
                            CurrPage = pageNum,
                            TotalItems = _context.MainTbl
                                .Where(x => x.LowPairEw.ToString() == search || search == null)
                                .Count()
                        },
                        Search = search,
                        Option = option
                    });
                }
                else if (option == "BurialNumber")
                {
                    return View(new IndexViewModel
                    {
                        MainTbls = _context.MainTbl
                            .Where(x => x.BurialNumber.ToString() == search || search == null)
                            .OrderBy(m => m.BurialId)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .ToList(),
                        PaginationModel = new PaginationModel
                        {
                            ItemsPerPage = pageSize,
                            CurrPage = pageNum,
                            TotalItems = _context.MainTbl
                                .Where(x => x.BurialNumber.ToString() == search || search == null)
                                .Count()
                        },
                        Search = search,
                        Option = option
                    });
                }
                //else if (option == "Gender")
                //{
                //    return View(new IndexViewModel
                //    {
                //        MainTbls = _context.MainTbl
                //            .Where(x => x.GenderGe == search)
                //            .OrderBy(m => m.BurialId)
                //            .Skip((pageNum - 1) * pageSize)
                //            .Take(pageSize)
                //            .ToList(),
                //        PaginationModel = new PaginationModel
                //        {
                //            ItemsPerPage = pageSize,
                //            CurrPage = pageNum,
                //            TotalItems = _context.MainTbl
                //                .Where(x => x.GenderGe == search || search == null)
                //                .Count()
                //        }
                //    });
                //}
                else
                {
                    return View(new IndexViewModel
                    {
                        MainTbls = (_context.MainTbl
                        .OrderBy(m => m.BurialId)
                        .Skip((pageNum - 1) * pageSize)
                        .Take(pageSize)),
                        PaginationModel = new PaginationModel
                        {
                            ItemsPerPage = pageSize,
                            CurrPage = pageNum,
                            TotalItems = _context.MainTbl.Count()
                        },
                        Search = search,
                        Option = option
                    });
                }
            }            
        }

        // GET: MainTbls/Details/5
        /*
        public async Task<IActionResult> Details(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burialDetails = await _context.MainTbl
                .FirstOrDefaultAsync(m => m.BurialId == id);
            if (burialDetails == null)
            {
                return NotFound();
            }

            return View(burialDetails);
        }
        */
        //GET: MainTbls/Create
        [Authorize(Roles = "Admin, Researcher")]
        public IActionResult Create()   // you'll need to pass in the role of the user here
        {
            //if (_context.UserInfo.Where(x => x.role == role) == null)
            //{
            //    return NotFound(); //we want to return not found, but also not show the View if they aren't a researcher (so you'll need to edit the view too)
            //};
            return View();
        }

        // POST: MainTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Researcher")]
        public async Task<IActionResult> Create([Bind("BurialId,BurialLocationNs,BurialLocationEw,LowPairNs,HighPairNs,LowPairEw,HighPairEw,BurialSubplot,Area,BurialDepth,SouthToHead,SouthToFeet,WestToHead,WestToFeet,BurialSituation,LengthOfRemains,BurialNumber,SampleNumber,GenderGe,Burialgendermethod,AgeCodeSingle,GeFunctionTotal,GenderBodyCol,ArtifactsDescription,HairColor,HairColorCode,PreservationIndex,YearFound,MonthFound,DayFound,DateFound,HeadDirection,Burialageatdeath,Burialagemethod,YearOnSkull,MonthOnSkull,DateOnSkull,FieldBook,FieldBookPageNumber,InitialsOfDataEntryExpert,InitialsOfDataEntryChecker,ByuSample,BodyAnalysis,SkullAtMagazine,PostcraniaAtMagazine,SexSkull2018,AgeSkull2018,RackAndShelf,ToBeConfirmed,SkullTrauma,PostcraniaTrauma,CribraOrbitala,PoroticHyperostosis,PoroticHyperostosisLocations,MetopicSuture,ButtonOsteoma,PostcraniaTrauma1,OsteologyUnknownComment,TemporalMandibularJointOsteoarthritisTmjOa,LinearHypoplasiaEnamel,BurialWrapping,BurialAdultChild,Goods,Cluster,FaceBundle")] MainTbl mainTbl)
        {
            if (ModelState.IsValid)
            {
                // mainTbl.BurialId = _context.MainTbl.Count() + 1;

                _context.Add(mainTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mainTbl);
        }

        // GET: MainTbls/Edit/5
        [Authorize(Roles = "Admin, Researcher")]
        public async Task<IActionResult> Edit(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainTbl = await _context.MainTbl.FindAsync(id);
            if (mainTbl == null)
            {
                return NotFound();
            }
            return View(mainTbl);
        }

        // POST: MainTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Researcher")]
        public async Task<IActionResult> Edit(double id, [Bind("BurialId,BurialLocationNs,BurialLocationEw,LowPairNs,HighPairNs,LowPairEw,HighPairEw,BurialSubplot,Area,BurialDepth,SouthToHead,SouthToFeet,WestToHead,WestToFeet,BurialSituation,LengthOfRemains,BurialNumber,SampleNumber,GenderGe,Burialgendermethod,AgeCodeSingle,GeFunctionTotal,GenderBodyCol,ArtifactsDescription,HairColor,HairColorCode,PreservationIndex,YearFound,MonthFound,DayFound,DateFound,HeadDirection,Burialageatdeath,Burialagemethod,YearOnSkull,MonthOnSkull,DateOnSkull,FieldBook,FieldBookPageNumber,InitialsOfDataEntryExpert,InitialsOfDataEntryChecker,ByuSample,BodyAnalysis,SkullAtMagazine,PostcraniaAtMagazine,SexSkull2018,AgeSkull2018,RackAndShelf,ToBeConfirmed,SkullTrauma,PostcraniaTrauma,CribraOrbitala,PoroticHyperostosis,PoroticHyperostosisLocations,MetopicSuture,ButtonOsteoma,PostcraniaTrauma1,OsteologyUnknownComment,TemporalMandibularJointOsteoarthritisTmjOa,LinearHypoplasiaEnamel,BurialWrapping,BurialAdultChild,Goods,Cluster,FaceBundle")] MainTbl mainTbl)
        {
            if (id != mainTbl.BurialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mainTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainTblExists(mainTbl.BurialId))
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
            return View(mainTbl);
        }

        // GET: MainTbls/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainTbl = await _context.MainTbl
                .FirstOrDefaultAsync(m => m.BurialId == id);
            if (mainTbl == null)
            {
                return NotFound();
            }

            return View(mainTbl);
        }

        // POST: MainTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(double id)
        {
            var mainTbl = await _context.MainTbl.FindAsync(id);
            _context.MainTbl.Remove(mainTbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainTblExists(double id)
        {
            return _context.MainTbl.Any(e => e.BurialId == id);
        }
    }
}
