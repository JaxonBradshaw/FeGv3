using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeGv3.Models.ViewModels
{
    public class PaginationModel
    {
        public int ItemsPerPage { get; set; }
        public int CurrPage { get; set; }
        public int TotalItems { get; set; }
        public int Pages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}