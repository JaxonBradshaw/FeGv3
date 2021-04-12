using FeGv3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeGv3.Components
{
    public class FilterViewComponent : ViewComponent
    {
        private FagElGamousContext context;

        //constructor
        public FilterViewComponent(FagElGamousContext ctx)
        {
            context = ctx;
        }

        public IViewComponentResult Invoke()
        {
            return View(context.MainTbl
                //.Select(x => x.)
                .Distinct()
                .OrderBy(x => x)
                .ToList());
        }
    }
}
