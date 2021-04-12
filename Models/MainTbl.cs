using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FeGv3.Models
{
    public partial class MainTbl
    {
        public MainTbl()
        {
            Biology = new HashSet<Biology>();
            Bones = new HashSet<Bones>();
            Samples = new HashSet<Samples>();
        }
        [Key]
        public double BurialId { get; set; }
        public string BurialLocationNs { get; set; }
        public string BurialLocationEw { get; set; }
        public double? LowPairNs { get; set; }
        public double? HighPairNs { get; set; }
        public double? LowPairEw { get; set; }
        public double? HighPairEw { get; set; }
        public string BurialSubplot { get; set; }
        public string Area { get; set; }
        public double? BurialDepth { get; set; }
        public double? SouthToHead { get; set; }
        public double? SouthToFeet { get; set; }
        public double? WestToHead { get; set; }
        public double? WestToFeet { get; set; }
        public string BurialSituation { get; set; }
        public double? LengthOfRemains { get; set; }
        public double? BurialNumber { get; set; }
        public double? SampleNumber { get; set; }
        public string GenderGe { get; set; }
        public string Burialgendermethod { get; set; }
        public string AgeCodeSingle { get; set; }
        public double? GeFunctionTotal { get; set; }
        public string GenderBodyCol { get; set; }
        public string ArtifactsDescription { get; set; }
        public string HairColor { get; set; }
        public string HairColorCode { get; set; }
        public string PreservationIndex { get; set; }
        public string YearFound { get; set; }
        public string MonthFound { get; set; }
        public string DayFound { get; set; }
        public string DateFound { get; set; }
        public string HeadDirection { get; set; }
        public string Burialageatdeath { get; set; }
        public string Burialagemethod { get; set; }
        public string YearOnSkull { get; set; }
        public string MonthOnSkull { get; set; }
        public string DateOnSkull { get; set; }
        public string FieldBook { get; set; }
        public string FieldBookPageNumber { get; set; }
        public string InitialsOfDataEntryExpert { get; set; }
        public string InitialsOfDataEntryChecker { get; set; }
        public string ByuSample { get; set; }
        public string BodyAnalysis { get; set; }
        public string SkullAtMagazine { get; set; }
        public string PostcraniaAtMagazine { get; set; }
        public string SexSkull2018 { get; set; }
        public string AgeSkull2018 { get; set; }
        public string RackAndShelf { get; set; }
        public string ToBeConfirmed { get; set; }
        public string SkullTrauma { get; set; }
        public string PostcraniaTrauma { get; set; }
        public string CribraOrbitala { get; set; }
        public string PoroticHyperostosis { get; set; }
        public string PoroticHyperostosisLocations { get; set; }
        public string MetopicSuture { get; set; }
        public string ButtonOsteoma { get; set; }
        public string PostcraniaTrauma1 { get; set; }
        public string OsteologyUnknownComment { get; set; }
        public string TemporalMandibularJointOsteoarthritisTmjOa { get; set; }
        public string LinearHypoplasiaEnamel { get; set; }
        public string BurialWrapping { get; set; }
        public string BurialAdultChild { get; set; }
        public string Goods { get; set; }
        public string Cluster { get; set; }
        public string FaceBundle { get; set; }
        public bool Photos { get; set; } //are there photos in the dataset (Y or N)

        public virtual ICollection<Biology> Biology { get; set; }
        public virtual ICollection<Bones> Bones { get; set; }
        public virtual ICollection<Samples> Samples { get; set; }
    }
}
