using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoMascotas.Models
{
    public class ValidarUsuario
    {
        public int ID { get; set; }
        
        public string Empresa { get; set; }


        public string Nombre { get; set; }


        public string Apellido { get; set; }

        [Required(ErrorMessage = "Este dato es obligatorio")]
        public string Nombre_de_Usuario { get; set; }

        [Required(ErrorMessage = "Este dato es obligatorio")]
        public string Pass { get; set; }

        [Required(ErrorMessage = "Este dato es obligatorio")]
        public string Localidad { get; set; }

        [Display(Name = "fecha de nacimiento")]
        [Required(ErrorMessage = "Este dato es obligatorio")]
        public Nullable<System.DateTime> Fecha_de_nacimiento { get; set; }

        [Required(ErrorMessage = "Este dato es obligatorio")]
        public string DNI { get; set; }
        
        public string Tipo_de_usuario { get; set; }

        [Required(ErrorMessage = "Este dato es obligatorio")]
        [EmailAddress(ErrorMessage="Email invalido")]
        public string Email { get; set; }
    }
}