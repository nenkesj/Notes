﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HowToDBEntities : DbContext
    {
        public HowToDBEntities()
            : base("name=HowToDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Info> Infoes { get; set; }
        public virtual DbSet<Key> Keys { get; set; }
        public virtual DbSet<Node> Nodes { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Summary> Summaries { get; set; }
        public virtual DbSet<Tree> Trees { get; set; }
        public virtual DbSet<Typ> Typs { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
    }
}
