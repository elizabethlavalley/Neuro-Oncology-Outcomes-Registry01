﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TumorTaskforce_Research
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class tumorDBEntities : DbContext
    {
        public tumorDBEntities()
            : base("name=tumorDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FamilyHistoryPivot> FamilyHistoryPivots { get; set; }
        public virtual DbSet<HealthFactorsPivot> HealthFactorsPivots { get; set; }
        public virtual DbSet<OtherMedsPivot> OtherMedsPivots { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PossibleFamilyHistory> PossibleFamilyHistories { get; set; }
        public virtual DbSet<PossibleHealthFactor> PossibleHealthFactors { get; set; }
        public virtual DbSet<PossibleOtherMed> PossibleOtherMeds { get; set; }
        public virtual DbSet<PossibleSymptom> PossibleSymptoms { get; set; }
        public virtual DbSet<PossibleTreatment> PossibleTreatments { get; set; }
        public virtual DbSet<SymptomsPivot> SymptomsPivots { get; set; }
        public virtual DbSet<TreatmentsPivot> TreatmentsPivots { get; set; }
    }
}