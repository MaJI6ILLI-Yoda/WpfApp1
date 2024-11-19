
namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class FaultTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FaultTypes()
        {
            this.Requests = new HashSet<Requests>();
        }
    
        public int fault_type_id { get; set; }
        public string fault_type_name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Requests> Requests { get; set; }
    }
}
