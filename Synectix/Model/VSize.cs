//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class VSize
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VSize()
        {
            this.ProjectBlocks = new HashSet<ProjectBlock>();
        }
    
        public int Id { get; set; }
        public Nullable<int> IdManuf { get; set; }
        public Nullable<int> IdPoleNumber { get; set; }
        public Nullable<int> IdSeria { get; set; }
        public Nullable<int> IdCbrCurrent { get; set; }
        public Nullable<int> IdSchema { get; set; }
        public string SizeName { get; set; }
        public Nullable<int> Fraction { get; set; }
    
        public virtual CbCurrent CbCurrent { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual PoleNumber PoleNumber { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectBlock> ProjectBlocks { get; set; }
        public virtual Schema Schema { get; set; }
        public virtual Seria Seria { get; set; }
    }
}
