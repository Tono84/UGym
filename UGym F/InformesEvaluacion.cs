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
    
    public partial class InformesEvaluacion
    {
        public int InformeEvaluacionId { get; set; }
        public string EnlaceInformeEvaluacion { get; set; }
        public System.DateTime FechaCarga { get; set; }
        public int SocioId { get; set; }
        public int EmpleadoId { get; set; }
    
        public virtual Empleados Empleados { get; set; }
        public virtual Socios Socios { get; set; }
    }
}
