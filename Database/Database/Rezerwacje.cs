//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rezerwacje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rezerwacje()
        {
            this.RezerwacjeMiejsca = new HashSet<RezerwacjeMiejsca>();
        }
    
        public int RezerwacjaID { get; set; }
        public int SeansID { get; set; }
        public int KlientID { get; set; }
        public System.DateTime DataRezerwacji { get; set; }
    
        public virtual Klienci Klienci { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RezerwacjeMiejsca> RezerwacjeMiejsca { get; set; }
        public virtual Seanse Seanse { get; set; }
    }
}
