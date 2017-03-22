//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetBook
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pet()
        {
            this.Profiles = new HashSet<Profile>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Size { get; set; }
        public int Weight { get; set; }
        public bool IsAggressive { get; set; }
        public bool OnMed { get; set; }
        public System.DateTime StartDate { get; set; }
        public int VisitsPerYear { get; set; }
        public bool IsHealthy { get; set; }
        public int CustomerId { get; set; }
        public bool Gender { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
