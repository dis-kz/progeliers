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
