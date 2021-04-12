using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FeGv3.Models
{
    public partial class FagElGamousContext : DbContext
    {
        public FagElGamousContext()
        {
        }

        public FagElGamousContext(DbContextOptions<FagElGamousContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Biology> Biology { get; set; }
        public virtual DbSet<Bones> Bones { get; set; }
        public virtual DbSet<Carbon> Carbon { get; set; }
        public virtual DbSet<MainTbl> MainTbl { get; set; }
        public virtual DbSet<Samples> Samples { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=FagElGamous;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Biology>(entity =>
            {
                entity.HasKey(e => e.BioId);

                entity.ToTable("biology$");

                entity.Property(e => e.ArtifactFound).HasColumnName("artifact_found");

                entity.Property(e => e.BoneTaken).HasColumnName("bone_taken");

                entity.Property(e => e.Burialsampletaken)
                    .HasColumnName("burialsampletaken")
                    .HasMaxLength(255);

                entity.Property(e => e.DescriptionOfTaken)
                    .HasColumnName("description_of_taken")
                    .HasMaxLength(255);

                entity.Property(e => e.EpiphysealUnion)
                    .HasColumnName("epiphyseal_union")
                    .HasMaxLength(255);

                entity.Property(e => e.EstimateAge)
                    .HasColumnName("estimate_age")
                    .HasMaxLength(255);

                entity.Property(e => e.EstimateLivingStature).HasColumnName("estimate_living_stature");

                entity.Property(e => e.HairTaken).HasColumnName("hair_taken");

                entity.Property(e => e.PathologyAnomalies)
                    .HasColumnName("pathology_anomalies")
                    .HasMaxLength(255);

                entity.Property(e => e.SoftTissueTaken).HasColumnName("soft_tissue_taken");

                entity.Property(e => e.TextileTaken).HasColumnName("textile_taken");

                entity.Property(e => e.ToothAttrition)
                    .HasColumnName("tooth_attrition")
                    .HasMaxLength(255);

                entity.Property(e => e.ToothEruption)
                    .HasColumnName("tooth_eruption")
                    .HasMaxLength(255);

                entity.Property(e => e.ToothTaken).HasColumnName("tooth_taken");

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.Biology)
                    .HasForeignKey(d => d.BurialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_biology$_main_tbl$");
            });

            modelBuilder.Entity<Bones>(entity =>
            {
                entity.HasKey(e => e.BoneId);

                entity.ToTable("bones$");

                entity.Property(e => e.BasilarSuture)
                    .HasColumnName("basilar_suture")
                    .HasMaxLength(255);

                entity.Property(e => e.BasionBregmaHeight).HasColumnName("basion_bregma_height");

                entity.Property(e => e.BasionNasion).HasColumnName("basion_nasion");

                entity.Property(e => e.BasionProsthionLength).HasColumnName("basion_prosthion_length");

                entity.Property(e => e.BizygomaticDiameter).HasColumnName("bizygomatic_diameter");

                entity.Property(e => e.BoneLength)
                    .HasColumnName("bone_length")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialArtifactDescription)
                    .HasColumnName("Burial/ Artifact Description")
                    .HasMaxLength(255);

                entity.Property(e => e.BuriedWithArtifacts)
                    .HasColumnName("Buried with Artifacts")
                    .HasMaxLength(255);

                entity.Property(e => e.CranialSuture)
                    .HasColumnName("cranial_suture")
                    .HasMaxLength(255);

                entity.Property(e => e.DorsalPitting).HasColumnName("dorsal_pitting");

                entity.Property(e => e.FemurDiameter)
                    .HasColumnName("femur_diameter")
                    .HasMaxLength(255);

                entity.Property(e => e.FemurHead).HasColumnName("femur_head");

                entity.Property(e => e.FemurLength).HasColumnName("femur_length");

                entity.Property(e => e.ForemanMagnum)
                    .HasColumnName("foreman_magnum")
                    .HasMaxLength(255);

                entity.Property(e => e.GilesGender).HasMaxLength(255);

                entity.Property(e => e.Gonian).HasColumnName("gonian");

                entity.Property(e => e.Humerus)
                    .HasColumnName("humerus")
                    .HasMaxLength(255);

                entity.Property(e => e.HumerusHead).HasColumnName("humerus_head");

                entity.Property(e => e.HumerusLength).HasColumnName("humerus_length");

                entity.Property(e => e.IliacCrest)
                    .HasColumnName("iliac_crest")
                    .HasMaxLength(255);

                entity.Property(e => e.InterorbitalBreadth).HasColumnName("interorbital_breadth");

                entity.Property(e => e.MaximumCranialBreadth).HasColumnName("maximum_cranial_breadth");

                entity.Property(e => e.MaximumCranialLength).HasColumnName("maximum_cranial_length");

                entity.Property(e => e.MaximumNasalBreadth).HasColumnName("maximum_nasal_breadth");

                entity.Property(e => e.MedialClavicle)
                    .HasColumnName("medial_clavicle")
                    .HasMaxLength(255);

                entity.Property(e => e.MedialIpRamus).HasColumnName("medial_IP_ramus");

                entity.Property(e => e.NasionProsthion).HasColumnName("nasion_prosthion");

                entity.Property(e => e.NuchalCrest).HasColumnName("nuchal_crest");

                entity.Property(e => e.OrbitEdge).HasColumnName("orbit_edge");

                entity.Property(e => e.OsteologyNotes).HasMaxLength(255);

                entity.Property(e => e.Osteophytosis)
                    .HasColumnName("osteophytosis")
                    .HasMaxLength(255);

                entity.Property(e => e.ParietalBossing).HasColumnName("parietal_bossing");

                entity.Property(e => e.PreaurSulcus).HasColumnName("preaur_sulcus");

                entity.Property(e => e.PubicBone).HasColumnName("pubic_bone");

                entity.Property(e => e.PubicSymphysis)
                    .HasColumnName("pubic_symphysis")
                    .HasMaxLength(255);

                entity.Property(e => e.Robust).HasColumnName("robust");

                entity.Property(e => e.SciaticNotch).HasColumnName("sciatic_notch");

                entity.Property(e => e.SubpubicAngle).HasColumnName("subpubic_angle");

                entity.Property(e => e.SupraorbitalRidges).HasColumnName("supraorbital_ridges");

                entity.Property(e => e.TibiaLength).HasColumnName("tibia_length");

                entity.Property(e => e.VentralArc).HasColumnName("ventral_arc");

                entity.Property(e => e.ZygomaticCrest).HasColumnName("zygomatic_crest");

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.Bones)
                    .HasForeignKey(d => d.BurialId)
                    .HasConstraintName("FK_bones$_main_tbl$");
            });

            modelBuilder.Entity<Carbon>(entity =>
            {
                entity.ToTable("carbon$");

                entity.Property(e => e.C14Sample2017).HasColumnName("C14 Sample 2017");

                entity.Property(e => e.Calibrated95CalendarDateAvg)
                    .HasColumnName("Calibrated 95% Calendar Date AVG")
                    .HasMaxLength(255);

                entity.Property(e => e.Calibrated95CalendarDateMax).HasColumnName("Calibrated 95% Calendar Date MAX");

                entity.Property(e => e.Calibrated95CalendarDateMin).HasColumnName("Calibrated 95% Calendar Date MIN");

                entity.Property(e => e.Calibrated95CalendarDateSpan).HasColumnName("Calibrated 95% Calendar Date SPAN");

                entity.Property(e => e.Category).HasMaxLength(255);

                entity.Property(e => e.Conventional14cAgeBp).HasColumnName("Conventional 14C age BP");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Location).HasMaxLength(255);

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.QuestionS)
                    .HasColumnName("Question(s)")
                    .HasMaxLength(255);

                entity.Property(e => e.SizeMl).HasColumnName("Size (ml)");

                entity.Property(e => e.Tube).HasColumnName("TUBE#");

                entity.Property(e => e._14cCalendarDate).HasColumnName("14C Calendar Date");

                entity.HasOne(d => d.Sample)
                    .WithMany(p => p.Carbon)
                    .HasForeignKey(d => d.SampleId)
                    .HasConstraintName("FK_carbon$_samples$");
            });

            modelBuilder.Entity<MainTbl>(entity =>
            {
                entity.HasKey(e => e.BurialId);

                entity.ToTable("main_tbl$");

                entity.Property(e => e.AgeCodeSingle)
                    .HasColumnName("Age Code SINGLE")
                    .HasMaxLength(255);

                entity.Property(e => e.AgeSkull2018)
                    .HasColumnName("Age _(Skull; _2018)")
                    .HasMaxLength(255);

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasMaxLength(255);

                entity.Property(e => e.ArtifactsDescription)
                    .HasColumnName("artifacts_description")
                    .HasMaxLength(255);

                entity.Property(e => e.BodyAnalysis)
                    .HasColumnName("Body Analysis")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialAdultChild)
                    .HasColumnName("burial adult child")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialDepth).HasColumnName("burial_depth");

                entity.Property(e => e.BurialLocationEw)
                    .HasColumnName("burial_location_EW")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialLocationNs)
                    .HasColumnName("burial_location_NS")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialNumber).HasColumnName("burial_number");

                entity.Property(e => e.BurialSituation).HasColumnName("burial_situation");

                entity.Property(e => e.BurialSubplot)
                    .HasColumnName("burial_subplot")
                    .HasMaxLength(255);

                entity.Property(e => e.BurialWrapping)
                    .HasColumnName("burial wrapping")
                    .HasMaxLength(255);

                entity.Property(e => e.Burialageatdeath)
                    .HasColumnName("burialageatdeath")
                    .HasMaxLength(255);

                entity.Property(e => e.Burialagemethod)
                    .HasColumnName("burialagemethod")
                    .HasMaxLength(255);

                entity.Property(e => e.Burialgendermethod)
                    .HasColumnName("burialgendermethod")
                    .HasMaxLength(255);

                entity.Property(e => e.ButtonOsteoma)
                    .HasColumnName("Button Osteoma")
                    .HasMaxLength(255);

                entity.Property(e => e.ByuSample)
                    .HasColumnName("BYU Sample")
                    .HasMaxLength(255);

                entity.Property(e => e.Cluster).HasMaxLength(255);

                entity.Property(e => e.CribraOrbitala)
                    .HasColumnName("Cribra Orbitala")
                    .HasMaxLength(255);

                entity.Property(e => e.DateFound)
                    .HasColumnName("date_found")
                    .HasMaxLength(255);

                entity.Property(e => e.DateOnSkull)
                    .HasColumnName("Date on Skull")
                    .HasMaxLength(255);

                entity.Property(e => e.DayFound)
                    .HasColumnName("day_found")
                    .HasMaxLength(255);

                entity.Property(e => e.FaceBundle)
                    .HasColumnName("Face Bundle")
                    .HasMaxLength(255);

                entity.Property(e => e.FieldBook)
                    .HasColumnName("Field Book")
                    .HasMaxLength(255);

                entity.Property(e => e.FieldBookPageNumber)
                    .HasColumnName("Field Book Page Number")
                    .HasMaxLength(255);

                entity.Property(e => e.GeFunctionTotal).HasColumnName("GE_function_total");

                entity.Property(e => e.GenderBodyCol)
                    .HasColumnName("gender_body_col")
                    .HasMaxLength(255);

                entity.Property(e => e.GenderGe)
                    .HasColumnName("gender_GE")
                    .HasMaxLength(255);

                entity.Property(e => e.Goods)
                    .HasColumnName("goods")
                    .HasMaxLength(255);

                entity.Property(e => e.HairColor)
                    .HasColumnName("hair_color")
                    .HasMaxLength(255);

                entity.Property(e => e.HairColorCode)
                    .HasColumnName("hair_color_code")
                    .HasMaxLength(255);

                entity.Property(e => e.HeadDirection)
                    .HasColumnName("head_direction")
                    .HasMaxLength(255);

                entity.Property(e => e.HighPairEw).HasColumnName("high_pair_EW");

                entity.Property(e => e.HighPairNs).HasColumnName("high_pair_NS");

                entity.Property(e => e.InitialsOfDataEntryChecker)
                    .HasColumnName("Initials of Data Entry Checker")
                    .HasMaxLength(255);

                entity.Property(e => e.InitialsOfDataEntryExpert)
                    .HasColumnName("Initials of Data Entry Expert")
                    .HasMaxLength(255);

                entity.Property(e => e.LengthOfRemains).HasColumnName("length_of_remains");

                entity.Property(e => e.LinearHypoplasiaEnamel)
                    .HasColumnName("Linear Hypoplasia Enamel")
                    .HasMaxLength(255);

                entity.Property(e => e.LowPairEw).HasColumnName("low_pair_EW");

                entity.Property(e => e.LowPairNs).HasColumnName("low_pair_NS");

                entity.Property(e => e.MetopicSuture)
                    .HasColumnName("Metopic Suture")
                    .HasMaxLength(255);

                entity.Property(e => e.MonthFound)
                    .HasColumnName("month_found")
                    .HasMaxLength(255);

                entity.Property(e => e.MonthOnSkull)
                    .HasColumnName("Month on skull")
                    .HasMaxLength(255);

                entity.Property(e => e.OsteologyUnknownComment)
                    .HasColumnName("Osteology unknown comment")
                    .HasMaxLength(255);

                entity.Property(e => e.PoroticHyperostosis)
                    .HasColumnName("Porotic Hyperostosis")
                    .HasMaxLength(255);

                entity.Property(e => e.PoroticHyperostosisLocations)
                    .HasColumnName("Porotic Hyperostosis (LOCATIONS)")
                    .HasMaxLength(255);

                entity.Property(e => e.PostcraniaAtMagazine)
                    .HasColumnName("Postcrania at Magazine")
                    .HasMaxLength(255);

                entity.Property(e => e.PostcraniaTrauma)
                    .HasColumnName("Postcrania Trauma")
                    .HasMaxLength(255);

                entity.Property(e => e.PostcraniaTrauma1)
                    .HasColumnName("Postcrania Trauma1")
                    .HasMaxLength(255);

                entity.Property(e => e.PreservationIndex)
                    .HasColumnName("preservation_index")
                    .HasMaxLength(255);

                entity.Property(e => e.RackAndShelf)
                    .HasColumnName("Rack and Shelf")
                    .HasMaxLength(255);

                entity.Property(e => e.SampleNumber).HasColumnName("sample_number");

                entity.Property(e => e.SexSkull2018)
                    .HasColumnName("Sex _(Skull; 2018)")
                    .HasMaxLength(255);

                entity.Property(e => e.SkullAtMagazine)
                    .HasColumnName("Skull at Magazine")
                    .HasMaxLength(255);

                entity.Property(e => e.SkullTrauma)
                    .HasColumnName("Skull Trauma")
                    .HasMaxLength(255);

                entity.Property(e => e.SouthToFeet).HasColumnName("south_to_feet");

                entity.Property(e => e.SouthToHead).HasColumnName("south_to_head");

                entity.Property(e => e.TemporalMandibularJointOsteoarthritisTmjOa)
                    .HasColumnName("Temporal Mandibular Joint Osteoarthritis (TMJ OA)")
                    .HasMaxLength(255);

                entity.Property(e => e.ToBeConfirmed)
                    .HasColumnName("TO BE CONFIRMED")
                    .HasMaxLength(255);

                entity.Property(e => e.WestToFeet).HasColumnName("west_to_feet");

                entity.Property(e => e.WestToHead).HasColumnName("west_to_head");

                entity.Property(e => e.YearFound)
                    .HasColumnName("year_found")
                    .HasMaxLength(255);

                entity.Property(e => e.YearOnSkull)
                    .HasColumnName("Year on skull")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Samples>(entity =>
            {
                entity.HasKey(e => e.SampleId);

                entity.ToTable("samples$");

                entity.Property(e => e.Bag)
                    .HasColumnName("Bag #")
                    .HasMaxLength(255);

                entity.Property(e => e.Cluster)
                    .HasColumnName("Cluster #")
                    .HasMaxLength(255);

                entity.Property(e => e.Initials).HasMaxLength(255);

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.PreviouslySampled)
                    .HasColumnName("Previously Sampled")
                    .HasMaxLength(255);

                entity.Property(e => e.Rack).HasColumnName("Rack #");

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.Samples)
                    .HasForeignKey(d => d.BurialId)
                    .HasConstraintName("FK_samples$_main_tbl$");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.userId);

                entity.ToTable("userInfo$");

                entity.Property(e => e.username)
                    .HasColumnName("username")
                    .HasMaxLength(255);

                entity.Property(e => e.password)
                    .HasColumnName("password")
                    .HasMaxLength(255);

                //entity.Property(e => e.role)
                //    .HasColumnName("role")
                //    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
