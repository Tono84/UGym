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
    
    public partial class Reportes
    {
        public int ReporteId { get; set; }
        public string NombreReporte { get; set; }
        public System.DateTime FechaGeneracion { get; set; }
        public string TipoReporte { get; set; }
        public string Descripcion { get; set; }
        public string DatosReporte { get; set; }
        public int EmpleadoId { get; set; }
    
        public virtual Empleados Empleados { get; set; }
    }
}
