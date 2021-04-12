using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FeGv3.Models
{
    public partial class Samples
    {
        public Samples()
        {
            Carbon = new HashSet<Carbon>();
        }

        public double? BurialId { get; set; }
        public double SampleId { get; set; }
        public double? Rack { get; set; }
        public string Bag { get; set; }
        public string Cluster { get; set; }
        public double? Date { get; set; }
        public string PreviouslySampled { get; set; }
        public string Notes { get; set; }
        public string Initials { get; set; }

        public virtual MainTbl Burial { get; set; }
        public virtual ICollection<Carbon> Carbon { get; set; }
    }
}
