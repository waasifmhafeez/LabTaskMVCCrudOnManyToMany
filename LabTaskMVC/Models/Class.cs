//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LabTaskMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> TeacherId { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}