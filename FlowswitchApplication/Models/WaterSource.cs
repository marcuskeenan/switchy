//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlowswitchApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class WaterSource
    {
        public WaterSource()
        {
            this.Flowswitches = new HashSet<Flowswitch>();
        }
    
        public int ID { get; set; }
        public string Source { get; set; }
    
        public virtual ICollection<Flowswitch> Flowswitches { get; set; }
    }
}
