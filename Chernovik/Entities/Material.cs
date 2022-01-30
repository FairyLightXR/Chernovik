//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chernovik.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Material()
        {
            this.MaterialCountHistory = new HashSet<MaterialCountHistory>();
            this.ProductMaterial = new HashSet<ProductMaterial>();
            this.Supplier = new HashSet<Supplier>();
        }
    
        public int ID { get; set; }
        public string Title { get; set; }
        public int CountInPack { get; set; }
        public string Unit { get; set; }
        public Nullable<double> CountInStock { get; set; }
        public double MinCount { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string Image { get; set; }
        public int MaterialTypeID { get; set; }
    
        public virtual MaterialType MaterialType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialCountHistory> MaterialCountHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductMaterial> ProductMaterial { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supplier> Supplier { get; set; }
    }
}
