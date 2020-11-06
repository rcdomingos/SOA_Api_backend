using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SOA_backend.Pers;

namespace SOA_backend.Models.DAO
{
    public class PlaceDAO
    {
        SqlConnection conn;
        SqlCommand cmd;

        //Metodo para inserir o usuario no banco
        public bool InsertPlace(User usuario, out string message)
        {
            conn = new ConnectionFactory().GetConnectionDB(out message);
            try
            {
                bool isCreated;
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO usuario(nome,email,senha) VALUES ('" + usuario.Nome +
                    "','" + usuario.Email +
                    "','" + usuario.Senha + "')";


                var linhasAfetadas = cmd.ExecuteNonQuery();

                isCreated = (linhasAfetadas > 0);

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


        public List<Place> SelectAllPlaces(out string message)
        {
            conn = new ConnectionFactory().GetConnectionDB(out message);
            try
            {
                SqlDataReader dr;
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT l.cod_local, l.nome, l.descricao,l.url_imagem, c.descricao AS 'categoria', l.latitude,l.longitude, " +
                    "(SELECT(SUM(nota_geral)/COUNT(nota_geral)) FROM avaliacao WHERE cod_local = l.cod_local) AS media_geral, " +
                    "(SELECT(SUM(nota_limpeza) / COUNT(nota_limpeza)) FROM avaliacao WHERE cod_local = l.cod_local) AS media_limpeza," +
                    "(SELECT(SUM(nota_distanciamento) / COUNT(nota_distanciamento)) FROM avaliacao WHERE cod_local = l.cod_local) AS media_distanciamento," +
                    "(SELECT(SUM(nota_uso_mascara) / COUNT(nota_uso_mascara)) FROM avaliacao WHERE cod_local = l.cod_local) AS media_uso_mascara" +
                    " FROM local l " +
                    "inner JOIN categoria c ON c.cod_categoria = l.cod_categoria";
                List<Place> PlaceList = new List<Place>();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    PlaceList.Add(new Place()
                    {
                        Id = Convert.ToInt32(dr[0].ToString()),
                        Nome = dr[1].ToString(),
                        Descricao = dr[2].ToString(),
                        Imagem = dr[3].ToString(),
                        Categoria = dr[4].ToString(),
                        Latitude = dr[5].ToString(),
                        Longitude = dr[6].ToString(),
                        MediaGeral = Convert.ToDecimal(dr[7].ToString()),
                        MediaLimpeza = Convert.ToDecimal(dr[8].ToString()),
                        MediaDistancia = Convert.ToDecimal(dr[9].ToString()),
                        MediaMascara = Convert.ToDecimal(dr[10].ToString()),
                    });
                }
                return PlaceList;
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


        public Place SelectPlaceById(string id, out string message)
        {
            conn = new ConnectionFactory().GetConnectionDB(out message);
            try
            {
                SqlDataReader dr;
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT l.cod_local, l.nome, l.descricao,l.url_imagem, c.descricao AS 'categoria', l.latitude,l.longitude, " +
                    "(SELECT(SUM(nota_geral)/COUNT(nota_geral)) FROM avaliacao WHERE cod_local = l.cod_local) AS media_geral, " +
                    "(SELECT(SUM(nota_limpeza) / COUNT(nota_limpeza)) FROM avaliacao WHERE cod_local = l.cod_local) AS media_limpeza," +
                    "(SELECT(SUM(nota_distanciamento) / COUNT(nota_distanciamento)) FROM avaliacao WHERE cod_local = l.cod_local) AS media_distanciamento," +
                    "(SELECT(SUM(nota_uso_mascara) / COUNT(nota_uso_mascara)) FROM avaliacao WHERE cod_local = l.cod_local) AS media_uso_mascara" +
                    " FROM local l " +
                    "inner JOIN categoria c ON c.cod_categoria = l.cod_categoria WHERE l.cod_local = " + id;


                Place selectedPlace = new Place();

                dr = cmd.ExecuteReader();
                dr.Read();

                selectedPlace.Id = Convert.ToInt32(dr[0].ToString());
                selectedPlace.Nome = dr[1].ToString();
                selectedPlace.Descricao = dr[2].ToString();
                selectedPlace.Imagem = dr[3].ToString();
                selectedPlace.Categoria = dr[4].ToString();
                selectedPlace.Latitude = dr[5].ToString();
                selectedPlace.Longitude = dr[6].ToString();
                selectedPlace.MediaGeral = Convert.ToDecimal(dr[7].ToString());
                selectedPlace.MediaLimpeza = Convert.ToDecimal(dr[8].ToString());
                selectedPlace.MediaDistancia = Convert.ToDecimal(dr[9].ToString());
                selectedPlace.MediaMascara = Convert.ToDecimal(dr[10].ToString());

                return selectedPlace;
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

    }


}