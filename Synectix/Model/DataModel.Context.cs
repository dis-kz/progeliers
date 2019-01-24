﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DataEntities : DbContext
    {
        public DataEntities()
            : base(SynectixConnection.Instance.GetConnectionString(1))
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BaseSize> BaseSizes { get; set; }
        public virtual DbSet<BlockEquipment> BlockEquipments { get; set; }
        public virtual DbSet<CbCurrent> CbCurrents { get; set; }
        public virtual DbSet<CbCurrentIcu> CbCurrentIcus { get; set; }
        public virtual DbSet<Contactor> Contactors { get; set; }
        public virtual DbSet<CurrentBreaker> CurrentBreakers { get; set; }
        public virtual DbSet<CurrentTransform> CurrentTransforms { get; set; }
        public virtual DbSet<DesignNumber> DesignNumbers { get; set; }
        public virtual DbSet<DesignType> DesignTypes { get; set; }
        public virtual DbSet<DisCurrent> DisCurrents { get; set; }
        public virtual DbSet<DisCurrentCb> DisCurrentCbs { get; set; }
        public virtual DbSet<DisCurrentType> DisCurrentTypes { get; set; }
        public virtual DbSet<DisModel> DisModels { get; set; }
        public virtual DbSet<DisType> DisTypes { get; set; }
        public virtual DbSet<DisTypeModel> DisTypeModels { get; set; }
        public virtual DbSet<EquipNote> EquipNotes { get; set; }
        public virtual DbSet<FileData> FileDatas { get; set; }
        public virtual DbSet<FunctionRole> FunctionRoles { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<IcuLiteral> IcuLiterals { get; set; }
        public virtual DbSet<IcuValue> IcuValues { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<ManufDisCurrent> ManufDisCurrents { get; set; }
        public virtual DbSet<ModulEquip> ModulEquips { get; set; }
        public virtual DbSet<NumericParam> NumericParams { get; set; }
        public virtual DbSet<PoleNumber> PoleNumbers { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectBlock> ProjectBlocks { get; set; }
        public virtual DbSet<ProjectEquipment> ProjectEquipments { get; set; }
        public virtual DbSet<ProjectFile> ProjectFiles { get; set; }
        public virtual DbSet<ProjectNumber> ProjectNumbers { get; set; }
        public virtual DbSet<ProjectStage> ProjectStages { get; set; }
        public virtual DbSet<ProjectState> ProjectStates { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Schema> Schemata { get; set; }
        public virtual DbSet<Seria> Serias { get; set; }
        public virtual DbSet<StringParam> StringParams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Voltage> Voltages { get; set; }
        public virtual DbSet<VSize> VSizes { get; set; }
    }
}
