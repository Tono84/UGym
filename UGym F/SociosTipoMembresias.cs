//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UGym_F
{
    using System;
    using System.Collections.Generic;
    
    public partial class SociosTipoMembresias
    {
        public int SocioId { get; set; }
        public int TipoMembresiaId { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaExpiracion { get; set; }
        public string Estado { get; set; }
    
        public virtual Socios Socios { get; set; }
        public virtual TipoMembresias TipoMembresias { get; set; }
    }
}