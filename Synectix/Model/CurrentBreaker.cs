//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CurrentBreaker
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CurrentBreaker()
        {
            this.ProjectEquipments = new HashSet<ProjectEquipment>();
        }
    
        public int Id { get; set; }
        public Nullable<int> IdManufacturer { get; set; }
        public Nullable<int> IdSeria { get; set; }
        public Nullable<int> IdCbCurrent { get; set; }
        public Nullable<int> IdIcuLiteral { get; set; }
        public Nullable<int> IdIcuValue { get; set; }
        public Nullable<int> IdPoleNumber { get; set; }
        public Nullable<int> IdVoltage { get; set; }
        public Nullable<int> IdDisType { get; set; }
        public Nullable<int> IdDisModel { get; set; }
        public Nullable<int> IdDisCurrent { get; set; }
        public string CbCatNumber { get; set; }
        public string DisCatNumber { get; set; }
        public string Note { get; set; }
    
        public virtual CbCurrent CbCurrent { get; set; }
        public virtual DisCurrent DisCurrent { get; set; }
        public virtual DisModel DisModel { get; set; }
        public virtual DisType DisType { get; set; }
        public virtual IcuLiteral IcuLiteral { get; set; }
        public virtual IcuValue IcuValue { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual PoleNumber PoleNumber { get; set; }
        public virtual Seria Seria { get; set; }
        public virtual Voltage Voltage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectEquipment> ProjectEquipments { get; set; }
    }
}
