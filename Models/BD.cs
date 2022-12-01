using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace TP9_Final_Integrador.Models
{
public static class BD
    {
        private static string _connectionString = @"Server=PC-SAMI\SQLEXPRESS; DataBase=BD;Trusted_Connection=True;";
        public static User usuario = getUserById(1);
        public static List<Board> GetBoards()
        {
            List<Board> Lista = null;
            string SQL = "SELECT * FROM Board"; 
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                Lista = db.Query<Board>(SQL).ToList(); 
            } 
            return Lista;
        }
        public static Board GetBoardById(int id)
        {
            Board b = null;
            string SQL = "SELECT * FROM Board WHERE IdBoard = @pId"; 
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                b = db.QueryFirstOrDefault<Board>(SQL, new{@pId = id}); 
            }
            return b;
        }
        public static Post GetPostById(int id)
        {
            Post p = null;
            string SQL = "SELECT P.*,U.Nombre FROM Post P inner join Usuario U on P.IdUsuario=U.IdUsuario WHERE IdPost = @pId";
            using(SqlConnection db= new SqlConnection(_connectionString))
            {
                p = db.QueryFirstOrDefault<Post> (SQL, new {@pId = id});
            }
            return p;
        }
        public static List<Post> GetPostsByBoard(int Id)
        {
            List<Post> Lista = null;
            string SQL = "SELECT * FROM Post P INNER JOIN Board B ON P.IdBoard=B.IdBoard"; 
            SQL +=" WHERE P.IdBoard=@pId AND P.FkPost is NULL ORDER BY P.FechaCreacion";

            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                Lista = db.Query<Post>(SQL, new { pId = Id }).ToList();
            } 
            return Lista;
        }
        public static List<Post> getPostsByFkPost(int Id)
        {
            List <Post> Lista = null;
            string SQL = "select P.*,U.Nombre from Post P inner join Post P2 on P.fkPost=p2.idPost inner join Usuario U on P.idUsuario=U.IdUsuario";
            SQL +=" where P2.idPost=@pId and P.fkPost=P2.idPost and P2.fkPost is null";

            using(SqlConnection db = new SqlConnection (_connectionString))
            {
                Lista = db.Query<Post>(SQL, new {pId = Id }).ToList();
            }
            return Lista;
        }
        public static void DeletePostById(int Id)
        {
            string SQL = "DELETE FROM Post WHERE IdPost=@pId or FkPost=@pId"; 
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(SQL, new { pId = Id }); 
            } 
        }
        public static void DeleteBoardById(int Id)
        {
            string SQL = "DELETE FROM Board WHERE IdBoard=@pId"; 
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(SQL, new { pId = Id }); 
            } 
        }
        public static void InsertPost(Post item)
        {
            string SQL = "INSERT INTO Post(IdBoard, IdUsuario, imagen, Descripcion, FechaCreacion, Titulo, FkPost)";
            SQL += " VALUES (@pIdBoard, @pIdUsuario, @pImagen, @pDescripcion,@pFechaCreacion,@pTitulo,@pFkPost)"; 
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(SQL, new {
                    pIdBoard = item.IdBoard,
                    pIdUsuario = item.IdUsuario,
                    pImagen = item.Imagen,
                    pDescripcion = item.Descripcion,
                    pFechaCreacion =item.FechaCreacion,
                    pTitulo = item.Titulo,
                    pFkPost=item.FkPost
                }); 
            }   
        }
        public static void InsertBoard(Board item)
        {
            string SQL = "INSERT INTO Board(Nombre, CantMaximaPosts)";
            SQL += " VALUES (@pNombre, @pCantMaximaPosts)"; 
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(SQL, new {
                    pNombre=item.Nombre,
                    pCantMaximaPosts=item.CantMaxPosts
                }); 
            }   
        }
        public static string InsertUser(User item, string Contraseña2)
        {
            string SQL = "SELECT COUNT(Nombre) FROM Usuario U WHERE U.Nombre = @pNombre";
            if (item.Contraseña != Contraseña2) return "PasswordsDontCoincide";
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                int i = db.QueryFirstOrDefault<int>(SQL, new {
                    pNombre = item.Nombre
                }); 
                if (i > 0) return "UsernameTaken";
                SQL = "INSERT INTO Usuario(Nombre, Contraseña, Moderador)";
                SQL += " VALUES (@pNombre, @pContraseña, @pModerador)";
                db.Execute(SQL, new {
                    pNombre = item.Nombre,
                    pContraseña = item.Contraseña,
                    pModerador = item.Moderador
                });
            }
            return "Ok";
        }
        public static string CheckUser(String Nombre, String Contraseña)
        {
            string SQL = "SELECT COUNT(Nombre) FROM Usuario WHERE contraseña = @pContraseña AND Nombre = @pNombre";
            using(SqlConnection db = new SqlConnection(_connectionString)){
                int i = db.QueryFirstOrDefault<int>(SQL, new {
                    pNombre = Nombre,
                    pContraseña = Contraseña
                });
                if (i==0) return "Wrong";
            }
            return "Ok";
        }
        public static List<Post> getPostsByUser(int Id)
        {
            List<Post> Lista = null;
            string SQL = "SELECT * FROM Post P INNER JOIN Usuario U ON P.IdUsuario=U.IdUsuario"; 
            SQL +=" WHERE P.IdBoard=@pId ORDER BY P.FechaCreacion";

            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                Lista = db.Query<Post>(SQL, new { pId = Id }).ToList();
            } 
            return Lista;
        }
        public static User getUserById(int Id)
        {
            User U = null;
            string SQL = "SELECT * FROM Usuario U";
            SQL += " WHERE U.IdUsuario=@pId";

            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                U = db.QueryFirstOrDefault<User> (SQL, new {pId=Id});
            }
            return U;
        }
        public static User getUserByName(string Nombre)
        {
            User U = null;
            string SQL = "SELECT * FROM Usuario U";
            SQL += " WHERE U.Nombre=@pNombre";

            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                U = db.QueryFirstOrDefault<User> (SQL, new {pNombre=Nombre});
            }
            return U;
        }
    }
}