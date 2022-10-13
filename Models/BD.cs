using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace TP9_Final_Integrador.Models
{
public static class BD
    {
        private static string _connectionString = @"Server=A-PHZ2-CIDI-038; DataBase=BD;Trusted_Connection=True;";

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
            string SQL = "SELECT * FROM Post WHERE IdPost = @pId";
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
            SQL +=" WHERE P.IdBoard=@pId AND P.fkPost is NULL ORDER BY P.FechaCreacion";

            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                Lista = db.Query<Post>(SQL, new { pId = Id }).ToList();
            } 
            return Lista;
        }
        public static void DeletePostById(int Id)
        {
            string SQL = "DELETE FROM Post WHERE IdPost=@pId"; 
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(SQL, new { pId = Id }); 
            } 
        }
        public static void InsertPost(Post item)
        {
            string SQL = "INSERT INTO Post(IdBoard, IdUsuario, imagen, Descripcion, FechaCreacion, Titulo)";
            SQL += " VALUES (@pIdBoard, @pIdUsuario, @pImagen, @pDescripcion,@pFechaCreacion,@pTitulo) "; 
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(SQL, new {
                    pIdBoard = item.IdBoard,
                    pIdUsuario = item.IdUsuario,
                    pImagen = item.Imagen,
                    pDescripcion = item.Descripcion,
                    pFechaCreacion =item.FechaCreacion,
                    pTitulo = item.Titulo
                }); 
            }   
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
    }
}