using System;

namespace TP9_Final_Integrador.Models{

    public class User{

        private int _IdUsuario;
        public int idUsuario { get {return _IdUsuario;} set { _IdUsuario=value;}}

        private string _Nombre;
        public string Nombre { get { return _Nombre;} set { _Nombre=value;}}

        private string _ImgUsuario;
        public string ImgUsuario { get {return _ImgUsuario;} set {_ImgUsuario=value;}}

        private string _Contraseña;
        public string Contraseña { get {return _Contraseña;} set { _Contraseña=value;}}

        private bool _Moderador;
        public bool Moderador { get { return _Moderador;} set { _Moderador=value;}}

        public User()
        {}

        public User(int IdUsuario, string Nombre, string ImgUsuario, string Contraseña, bool Moderador)
        {
            _IdUsuario=idUsuario;
            _Nombre=Nombre;
            _ImgUsuario=ImgUsuario;
            _Contraseña=Contraseña;
            _Moderador=Moderador;
        }
    }
}