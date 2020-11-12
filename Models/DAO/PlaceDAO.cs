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
                cmd.CommandText = "INSERT INTO usuario(nome,email,senha) VALUES ('" + usuario.Name +
                    "','" + usuario.Email +
                    "','" + usuario.Password + "')";


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


        public List<Place> SelectAllPlaces(out string message, int cod_category = 0)
        {
            conn = new ConnectionFactory().GetConnectionDB(out message);
            string queryCategory = cod_category != 0 ? "WHERE l.cod_categoria =" + cod_category : null;
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
                    "inner JOIN categoria c ON c.cod_categoria = l.cod_categoria " + queryCategory;
                List<Place> PlaceList = new List<Place>();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    PlaceList.Add(new Place()
                    {
                        Id = Convert.ToInt32(dr[0].ToString()),
                        Name = dr[1].ToString(),
                        Description = dr[2].ToString(),
                        Image = dr[3].ToString(),
                        Category = dr[4].ToString(),
                        Latitude = dr[5].ToString(),
                        Longitude = dr[6].ToString(),
                        AverageTotalScore = string.IsNullOrEmpty(dr[7].ToString()) ? 0 : Convert.ToDecimal(dr[7].ToString()),
                        AverageCleaningScore = string.IsNullOrEmpty(dr[8].ToString()) ? 0 : Convert.ToDecimal(dr[8].ToString()),
                        AverageDistanceScore = string.IsNullOrEmpty(dr[9].ToString()) ? 0 : Convert.ToDecimal(dr[9].ToString()),
                        AverageMaskUseScore = string.IsNullOrEmpty(dr[10].ToString()) ? 0 : Convert.ToDecimal(dr[10].ToString()),
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
                selectedPlace.Name = dr[1].ToString();
                selectedPlace.Description = dr[2].ToString();
                selectedPlace.Image = dr[3].ToString();
                selectedPlace.Category = dr[4].ToString();
                selectedPlace.Latitude = dr[5].ToString();
                selectedPlace.Longitude = dr[6].ToString();
                selectedPlace.AverageTotalScore = string.IsNullOrEmpty(dr[7].ToString()) ? 0 : Convert.ToDecimal(dr[7].ToString());
                selectedPlace.AverageCleaningScore = string.IsNullOrEmpty(dr[8].ToString()) ? 0 : Convert.ToDecimal(dr[8].ToString());
                selectedPlace.AverageDistanceScore = string.IsNullOrEmpty(dr[9].ToString()) ? 0 : Convert.ToDecimal(dr[9].ToString());
                selectedPlace.AverageMaskUseScore = string.IsNullOrEmpty(dr[10].ToString()) ? 0 : Convert.ToDecimal(dr[10].ToString());

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