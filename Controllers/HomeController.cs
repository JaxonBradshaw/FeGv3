using FeGv3.Data;
using FeGv3.Models;
using FeGv3.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FeGv3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FagElGamousContext _context;
        //private readonly ApplicationDbContext _AppDbContext;
        //private readonly string _CurrentUserId;
        // we have the database working

        public HomeController(ILogger<HomeController> logger, FagElGamousContext ctx)
        {
            _logger = logger;
            _context = ctx;                        
        }

        public IActionResult Index()
        {            
            return View();
        }

        /*public IActionResult test()
        {
            var userid = HttpContext.Session.GetInt32("currentUser");
            if (userid != null)
            {
                UserInfo currentUser = _context.UserInfo.Where(x => x.userId == userid).FirstOrDefault();
                return View("test", currentUser);
            }
            return View("test");
        }*/

        [HttpGet]
        public IActionResult BurialDetails(double burialId)
        {
            IEnumerable<Samples> SamplesInfo = _context.Samples.Where(b => b.BurialId == burialId);
            Dictionary<Samples, Carbon> samplesAndCarbon = new Dictionary<Samples, Carbon>();

            Console.WriteLine(burialId);

            foreach (var sample in SamplesInfo)
            {
                Carbon cDate = _context.Carbon.Where(c => c.SampleId == sample.SampleId).FirstOrDefault();
                if (cDate != null)
                {
                    samplesAndCarbon.Add(sample, cDate);
                }
                else
                {
                    samplesAndCarbon.Add(sample, null);
                }
            }

            if (samplesAndCarbon.Count == 0)
            {
                samplesAndCarbon = null;
            }                                          

            return View(new BurialDetailsViewModel
            {
                BurialInfo = _context.MainTbl.Where(b => b.BurialId == burialId).First(),
                BonesInfo = _context.Bones.Where(b => b.BurialId == burialId).FirstOrDefault(),
                BiologyInfo = _context.Biology.Where(b => b.BurialId == burialId).FirstOrDefault(),
                SamplesAndCarbon = samplesAndCarbon,                
            });
        }

        [HttpGet]
        public IActionResult Photos()
        {
            return View();
        }

        // S3 stuff
        [HttpGet]
        public async Task<IActionResult> FileUploadForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FileUploadForm(FileUploadForm FileUpload)
        {
            using (var memoryStream = new MemoryStream())
            {
                await FileUpload.FormFile.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    await S3Upload.UploadFileAsync(memoryStream, "intex-fagelgamous", "AKIAVY5M47Y5S26WCNPL");
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
