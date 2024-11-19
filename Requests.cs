

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Requests
    {
        public int request_id { get; set; }
        public Nullable<int> application_number { get; set; }
        public Nullable<System.DateTime> request_date { get; set; }
        public Nullable<int> subject_id { get; set; }
        public Nullable<int> fault_type_id { get; set; }
        public string problem_description { get; set; }
        public Nullable<int> child_id { get; set; }
        public Nullable<int> status_id { get; set; }
        public Nullable<int> teacher_id { get; set; }
    
        public virtual Childs Childs { get; set; }
        public virtual FaultTypes FaultTypes { get; set; }
        public virtual RequestStatus RequestStatus { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Teachers Teachers { get; set; }
    }
}
