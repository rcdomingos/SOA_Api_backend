using SOA_backend.Pers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SOA_backend.Models.DAO
{
    public class CommentDAO
    {
        SqlConnection conn;
        SqlCommand cmd;

        public List<Comment> SelectAllComment(int placeId, out string message)
        {
            conn = new ConnectionFactory().GetConnectionDB(out message);

            try
            {
                SqlDataReader dr;
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT com.cod_comentario,u.nome, com.titulo, com.comentario FROM comentario com JOIN usuario u ON u.cod_usuario = com.cod_usuario WHERE com.cod_local =" + placeId;

                List<Comment> commentList = new List<Comment>();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    commentList.Add(new Comment()
                    {
                        Id = Convert.ToInt32(dr[0].ToString()),
                        UserName = dr[1].ToString(),
                        Title = dr[2].ToString(),
                        CommentText = dr[3].ToString(),
                    });
                }
                return commentList;

            }
            catch (Exception e)
            {
                message = e.ToString();
                return null;
            }
            finally
            {
                conn.Close();
            }

        }

        public bool InsertNewComment(int placeId, Comment comment, out string message)
        {
            conn = new ConnectionFactory().GetConnectionDB(out message);

            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO comentario(cod_local, cod_usuario, titulo, comentario ) VALUES (" + placeId +
                    "," + comment.UserId +",'" + comment.Title + "','"+ comment.CommentText+"')";

                var rowsAffected = cmd.ExecuteNonQuery();

                return (rowsAffected > 0);

            }
            catch (Exception e)
            {
                message = e.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }

        }

        public bool DeleteCommentById(int commentId, out string message)
        {
            conn = new ConnectionFactory().GetConnectionDB(out message);

            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM comentario WHERE cod_comentario = " + commentId;

                var rowsAffected = cmd.ExecuteNonQuery();
                return (rowsAffected > 0);

            }
            catch (Exception e)
            {
                message = e.ToString();
                return false;
            }
            finally
            {
                conn.Close();
            }

        }


    }
}