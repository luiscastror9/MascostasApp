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
        [Required(ErrorMessage = "La razon social es un dato obligatorio")]
        public string Empresa { get; set; }
        [Required(ErrorMessage = "El nombre es un dato obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es un dato obligatorio")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es un dato obligatorio")]
        public string Nombre_de_Usuario { get; set; }
        [Required(ErrorMessage = "La contraseña es un dato obligatorio")]
        public string Pass { get; set; }
        [Required(ErrorMessage = "La localidad es un dato obligatorio")]
        public string Localidad { get; set; }
        [Required(ErrorMessage = "La fecha es un dato obligatorio")]
        public Nullable<System.DateTime> Fecha_de_nacimiento { get; set; }
        [Required(ErrorMessage = "El DNI/CUIT es un dato obligatorio")]
        public string DNI { get; set; }
        public string Tipo_de_usuario { get; set; }
        [Required(ErrorMessage = "El correo electronico es un dato obligatorio")]
        public string Email { get; set; }
    }
}