//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Notes
{
    using System;
    using System.Collections.Generic;
    
    public partial class Summary
    {
        public int SummaryID { get; set; }
        public int NodeID { get; set; }
        public string Summary1 { get; set; }
    
        public virtual Node Node { get; set; }
    }
}