//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoMascotas
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    
    public partial class Mascotas
    {
        public int Id { get; set; }
        public string Animal { get; set; }
        public string Raza { get; set; }
        public string Ubicacion { get; set; }
        public Nullable<bool> Sexo { get; set; }
        public string Descripcion { get; set; }
        public string Vacunas { get; set; }
        public Nullable<int> Edad { get; set; }
        public Nullable<int> Status { get; set; }
        public byte[] Imagen { get; set; }
        public string ImagenA { get; set; }
        public Nullable<int> RID { get; set; }

        public HttpPostedFileBase ImagenFile { get; set; }

    }
}
