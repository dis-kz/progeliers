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
    
    public partial class DesignNumber
    {
        public int Id { get; set; }
        public Nullable<int> IdManufacturer { get; set; }
        public Nullable<int> IdSeria { get; set; }
        public Nullable<int> IdCbCurrent { get; set; }
        public Nullable<int> IdPoleNumber { get; set; }
        public Nullable<int> IdDesignType { get; set; }
        public string DesCatNumber { get; set; }
        public string Note { get; set; }
    
        public virtual CbCurrent CbCurrent { get; set; }
        public virtual DesignType DesignType { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual PoleNumber PoleNumber { get; set; }
        public virtual Seria Seria { get; set; }
    }
}
