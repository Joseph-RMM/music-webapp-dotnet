//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogicaNaverMusic.BaseDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuarios
    {
        public Usuarios()
        {
            this.VotoAlbum = new HashSet<VotoAlbum>();
            this.VotoArtista = new HashSet<VotoArtista>();
            this.VotoCancion = new HashSet<VotoCancion>();
            this.FavAlbum = new HashSet<FavAlbum>();
            this.FavArtista = new HashSet<FavArtista>();
            this.FavCancion = new HashSet<FavCancion>();
        }
    
        public int idUsuario { get; set; }
        public string username { get; set; }
        public string passsword { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string sexo { get; set; }
        public string foto { get; set; }
        public string estatus { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
    
        public virtual ICollection<VotoAlbum> VotoAlbum { get; set; }
        public virtual ICollection<VotoArtista> VotoArtista { get; set; }
        public virtual ICollection<VotoCancion> VotoCancion { get; set; }
        public virtual ICollection<FavAlbum> FavAlbum { get; set; }
        public virtual ICollection<FavArtista> FavArtista { get; set; }
        public virtual ICollection<FavCancion> FavCancion { get; set; }
    }
}
