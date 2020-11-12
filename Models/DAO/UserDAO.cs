using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SOA_backend.Pers;

namespace SOA_backend.Models.DAO
{
    public class UserDAO
    {
        SqlConnection conn;
        SqlCommand cmd;

        //Metodo para inserir o usuario no banco
        public bool InsertUser(User usuario, out string message)
        {
            conn = new ConnectionFactory().GetConnectionDB(out message);
            try
            {
                bool isCreated;
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO usuario(nome,email,senha) VALUES ('" + usuario.Name + 
                    "','" + usuario.Email +
                    "','" + usuario.Password + "')";

                var rowsAffected = cmd.ExecuteNonQuery(); 

                isCreated = (rowsAffected > 0);

                return isCreated;
            }
            catch (Exception e)
            {
                message = "Erro ao inserir: " + e.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }

        }


        public List<User> SelectAllUsers(out string message)
        {
            conn = new ConnectionFactory().GetConnectionDB(out message);
            try
            {
                SqlDataReader dr;
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT cod_usuario, nome, email, senha FROM usuario";

                List<User> userList = new List<User>();
    
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    userList.Add(new User()
                    {
                        Id = Convert.ToInt32(dr[0].ToString()),
                        Name = dr[1].ToString(),
                        Email = dr[2].ToString(),
                        Password = dr[3].ToString(),
                    });
                }

                conn.Close();
                return userList;
            }
            catch (Exception e)
            {
                message = "Erro ao listar: " + e.Message;
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public User SelectUserById(string Id, out string message)
        {
            conn = new ConnectionFactory().GetConnectionDB(out message);

            try {
                SqlDataReader dr;
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT cod_usuario, nome, email, senha FROM usuario WHERE cod_usuario = " + Id;

                User selectedUser = new User();

                dr = cmd.ExecuteReader();
                dr.Read();
                selectedUser.Id = Convert.ToInt32(dr[0].ToString());
                selectedUser.Name = dr[1].ToString();
                selectedUser.Email = dr[2].ToString();
                selectedUser.Password = dr[3].ToString();

                return selectedUser;
            }
            catch (Exception e) {
                message = "Erro buscar usuario: " + e.Message;
                return null;
            }
            finally
            {
                conn.Close();
            }

        }


        public User SelectUserByEmailAndPass(string email, string password, out string message)
        {
            conn = new ConnectionFactory().GetConnectionDB(out message);

            try
            {
                SqlDataReader dr;
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT cod_usuario, nome, email, senha FROM usuario WHERE email = '" + email + "' AND senha = '" + password + "'";

                User selectedUser = new User();

                dr = cmd.ExecuteReader();
                dr.Read();
                selectedUser.Id = Convert.ToInt32(dr[0].ToString());
                selectedUser.Name = dr[1].ToString();
                selectedUser.Email = dr[2].ToString();
                selectedUser.Password = dr[3].ToString();

                return selectedUser;
            }
            catch (Exception e)
            {
                message = "Erro buscar usuario: " + e.Message;
                return null;
            }
            finally
            {
                conn.Close();
            }

        }

    }

}