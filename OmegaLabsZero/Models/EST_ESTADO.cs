//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OmegaLabsZero.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EST_ESTADO
    {
        public EST_ESTADO()
        {
            this.CON_CONCURSO = new HashSet<CON_CONCURSO>();
        }
    
        public int EST_ID { get; set; }
        public string EST_NOME { get; set; }
    
        public virtual ICollection<CON_CONCURSO> CON_CONCURSO { get; set; }
    }
}