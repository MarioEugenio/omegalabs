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
    
    public partial class CON_CONCURSO
    {
        public int CON_ID { get; set; }
        public string CON_NOME { get; set; }
        public int STA_ID { get; set; }
        public int CID_ID { get; set; }
        public int EST_ID { get; set; }
    
        public virtual CID_CIDADE CID_CIDADE { get; set; }
        public virtual EST_ESTADO EST_ESTADO { get; set; }
        public virtual STA_STATUS STA_STATUS { get; set; }
    }
}
