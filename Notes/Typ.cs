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
    
    public partial class Typ
    {
        public Typ()
        {
            this.Infoes = new HashSet<Info>();
            this.Keys = new HashSet<Key>();
            this.Nodes = new HashSet<Node>();
            this.Pictures = new HashSet<Picture>();
            this.Trees = new HashSet<Tree>();
        }
    
        public short TypeID { get; set; }
        public string Label { get; set; }
        public string Category { get; set; }
    
        public virtual ICollection<Info> Infoes { get; set; }
        public virtual ICollection<Key> Keys { get; set; }
        public virtual ICollection<Node> Nodes { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<Tree> Trees { get; set; }
    }
}
