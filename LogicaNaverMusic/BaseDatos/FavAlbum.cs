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
    
    public partial class FavAlbum
    {
        public int idFavAlbum { get; set; }
        public int idAlbum { get; set; }
        public int idUser { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
    }
}
