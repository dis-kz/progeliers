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
    
    public partial class CbCurrentIcu
    {
        public int Id { get; set; }
        public Nullable<int> IdCbCurrent { get; set; }
        public Nullable<int> IdIcuValue { get; set; }
    
        public virtual CbCurrent CbCurrent { get; set; }
        public virtual IcuValue IcuValue { get; set; }
    }
}
