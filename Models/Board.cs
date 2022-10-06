using System;

namespace TP9_Final_Integrador.Models{

    public class Board{

        private int _IdBoard;
        public int IdBoard { get { return _IdBoard;} set { _IdBoard=value;}}

        private string _Nombre;
        public string Nombre { get { return _Nombre;} set { _Nombre=value;}}

        private int _CantMaxPosts;
        public int CantMaxPosts { get { return _CantMaxPosts;} set { _CantMaxPosts=value;}}

        public Board()
        {}

        public Board(int IdBoard, string Nombre, int CantMaxPosts)
        {
            _IdBoard=IdBoard;
            _Nombre=Nombre;
            _CantMaxPosts=CantMaxPosts;
        }
    }
}