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
    
    public partial class FileData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FileData()
        {
            this.ProjectFiles = new HashSet<ProjectFile>();
        }
    
        public int Id { get; set; }
        public System.Guid GUID { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Extension { get; set; }
        public Nullable<long> Size { get; set; }
        public string Author { get; set; }
        public byte[] Data { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectFile> ProjectFiles { get; set; }
    }
}
