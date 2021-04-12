using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FeGv3.Models
{
    public partial class Carbon
    {
        public double? SampleId { get; set; }
        public double CarbonId { get; set; }
        public double? Rack { get; set; }
        public double? Tube { get; set; }
        public string Description { get; set; }
        public double? SizeMl { get; set; }
        public double? Foci { get; set; }
        public double? C14Sample2017 { get; set; }
        public string Location { get; set; }
        public string QuestionS { get; set; }
        public double? Unknown { get; set; }
        public double? Conventional14cAgeBp { get; set; }
        public double? _14cCalendarDate { get; set; }
        public double? Calibrated95CalendarDateMax { get; set; }
        public double? Calibrated95CalendarDateMin { get; set; }
        public double? Calibrated95CalendarDateSpan { get; set; }
        public string Calibrated95CalendarDateAvg { get; set; }
        public string Category { get; set; }
        public string Notes { get; set; }

        public virtual Samples Sample { get; set; }
    }
}
