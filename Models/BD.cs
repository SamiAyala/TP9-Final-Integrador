using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace TP9_Final_Integrador.Models
{
public static class BD
    {
        private static string _connectionString = @"Server=A-PHZ2-CIDI-033; DataBase=BD;Trusted_Connection=True;";

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
        public static List<Post> GetPostsByBoard(int Id)
        {
            List<Post> Lista = null;
            string SQL = "SELECT * FROM Post P INNER JOIN Board B ON P.IdBoard=B.IdBoard"; 
            SQL +=" WHERE P.IdBoard=@pId";

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
    }
}