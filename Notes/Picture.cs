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
    
    public partial class Picture
    {
        public int PictureID { get; set; }
        public int NodeID { get; set; }
        public short TypeID { get; set; }
        public string Picture1 { get; set; }
        public string Title { get; set; }
        public int PictureSize { get; set; }
        public short DisplayAt { get; set; }
        public short DisplayStopAt { get; set; }
        public int InfoID { get; set; }
    
        public virtual Node Node { get; set; }
        public virtual Typ Type { get; set; }
    }
}
