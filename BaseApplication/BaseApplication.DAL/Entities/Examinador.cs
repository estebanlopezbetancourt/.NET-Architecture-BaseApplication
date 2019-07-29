//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaseApplication.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Examinador
    {
        public Examinador()
        {
            this.ExaminadorRol = new HashSet<ExaminadorRol>();
        }
    
        public int Id { get; set; }
        public int Rut { get; set; }
        public string RutDv { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public System.DateTime Birthdate { get; set; }
        public int Cellphone { get; set; }
        public string Email { get; set; }
        public double PaymentAmount { get; set; }
        public int ComunaId { get; set; }
    
        public virtual Comuna Comuna { get; set; }
        public virtual ICollection<ExaminadorRol> ExaminadorRol { get; set; }
    }
}