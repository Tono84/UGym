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
    
    public partial class Empleados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleados()
        {
            this.Anuncios = new HashSet<Anuncios>();
            this.EntrenadoresClases = new HashSet<EntrenadoresClases>();
            this.InformesEvaluacion = new HashSet<InformesEvaluacion>();
            this.InformesInbody = new HashSet<InformesInbody>();
            this.InformesTerapia = new HashSet<InformesTerapia>();
            this.PlanAlimentacion = new HashSet<PlanAlimentacion>();
            this.Reportes = new HashSet<Reportes>();
            this.Rutinas = new HashSet<Rutinas>();
            this.Socios = new HashSet<Socios>();
        }
    
        public int EmpleadoId { get; set; }
        public int NumeroEmpleado { get; set; }
        public string Contraseña { get; set; }
        public string NombreCompleto { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string CorreoElectronico { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public Nullable<int> ContactoEmergenciaId { get; set; }
        public int RolId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anuncios> Anuncios { get; set; }
        public virtual ContactoEmergencia ContactoEmergencia { get; set; }
        public virtual Roles Roles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EntrenadoresClases> EntrenadoresClases { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InformesEvaluacion> InformesEvaluacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InformesInbody> InformesInbody { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InformesTerapia> InformesTerapia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanAlimentacion> PlanAlimentacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reportes> Reportes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rutinas> Rutinas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Socios> Socios { get; set; }
    }
}