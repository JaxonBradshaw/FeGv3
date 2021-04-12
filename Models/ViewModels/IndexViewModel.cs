using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeGv3.Models.ViewModels
{
    public class IndexViewModel
    {
        public PaginationModel PaginationModel { get; set; }
        public IEnumerable<MainTbl> MainTbls { get; set; }
        #nullable enable
        public string? Search { get; set; }
        public string? Option { get; set; }
    }
}
