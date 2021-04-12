using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FeGv3.Models
{
    public partial class Bones
    {
        public double? BurialId { get; set; }
        public double BoneId { get; set; }
        public string BasilarSuture { get; set; }
        public double? VentralArc { get; set; }
        public double? SubpubicAngle { get; set; }
        public double? SciaticNotch { get; set; }
        public double? PubicBone { get; set; }
        public double? PreaurSulcus { get; set; }
        public double? MedialIpRamus { get; set; }
        public double? DorsalPitting { get; set; }
        public string ForemanMagnum { get; set; }
        public double? FemurHead { get; set; }
        public double? HumerusHead { get; set; }
        public string Osteophytosis { get; set; }
        public string PubicSymphysis { get; set; }
        public string BoneLength { get; set; }
        public string MedialClavicle { get; set; }
        public string IliacCrest { get; set; }
        public string FemurDiameter { get; set; }
        public string Humerus { get; set; }
        public double? FemurLength { get; set; }
        public double? HumerusLength { get; set; }
        public double? TibiaLength { get; set; }
        public double? Robust { get; set; }
        public double? SupraorbitalRidges { get; set; }
        public double? OrbitEdge { get; set; }
        public double? ParietalBossing { get; set; }
        public double? Gonian { get; set; }
        public double? NuchalCrest { get; set; }
        public double? ZygomaticCrest { get; set; }
        public string CranialSuture { get; set; }
        public double? MaximumCranialLength { get; set; }
        public double? MaximumCranialBreadth { get; set; }
        public double? BasionBregmaHeight { get; set; }
        public double? BasionNasion { get; set; }
        public double? BasionProsthionLength { get; set; }
        public double? BizygomaticDiameter { get; set; }
        public double? NasionProsthion { get; set; }
        public double? MaximumNasalBreadth { get; set; }
        public double? InterorbitalBreadth { get; set; }
        public string OsteologyNotes { get; set; }
        public string BurialArtifactDescription { get; set; }
        public string BuriedWithArtifacts { get; set; }
        public string GilesGender { get; set; }

        public virtual MainTbl Burial { get; set; }
    }
}
