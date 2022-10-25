using System;

namespace TP9_Final_Integrador.Models{
    public class Post{
        private int _IdPost;
        public int IdPost { get{ return _IdPost;} set { _IdPost=value;}}
        
        private int _IdBoard;
        public int IdBoard { get { return _IdBoard;} set { _IdBoard=value;}}

        private int _IdUsuario;
        public int IdUsuario { get { return _IdUsuario;} set {_IdUsuario=value;}}

        private string _Imagen;
        public string Imagen { get { return _Imagen;} set {_Imagen=value;}}
        
        private string _Descripcion;
        public string Descripcion { get { return _Descripcion;} set {_Descripcion=value;}}

        private DateTime _FechaCreacion;
        public DateTime FechaCreacion { get { return _FechaCreacion;} set {_FechaCreacion=value;}}

        private string _Titulo;
        public string Titulo { get { return _Titulo;} set { _Titulo=value;}}

        private int _FkPost;
        public int FkPost { get { return _FkPost;} set { _FkPost=value;}}

        private string _Nombre;
        public string Nombre { get { return _Nombre; } set { _Nombre = value; }}

        public Post()
        {}

        public Post(int IdPost,int IdBoard,int IdUsuario, string Imagen, string Descripcion, DateTime FechaCreacion, string Titulo, int FkPost, string Nombre)
        {
            _IdPost=IdPost;
            _IdBoard=IdBoard;
            _IdUsuario=IdUsuario;
            _Imagen=Imagen;
            _Descripcion=Descripcion;
            _FechaCreacion=FechaCreacion;
            _Titulo=Titulo;
            _FkPost=FkPost;
            _Nombre=Nombre;
        }
    }
}