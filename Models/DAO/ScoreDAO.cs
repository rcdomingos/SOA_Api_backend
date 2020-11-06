using SOA_backend.Pers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SOA_backend.Models.DAO
{
    public class ScoreDAO
    {
        SqlConnection conn;
        SqlCommand cmd;

        public List<Score> SelectAllScore(int placeId, out string message)
        {
            conn = new ConnectionFactory().GetConnectionDB(out message);
            try
            {
                SqlDataReader dr;
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT a.cod_local, u.cod_usuario, u.nome, a.nota_geral, a.nota_limpeza, a.nota_distanciamento, a.nota_uso_mascara FROM avaliacao a JOIN usuario u ON u.cod_usuario = a.cod_usuario WHERE cod_local = " + placeId;
                List<Score> scoreList = new List<Score>();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    scoreList.Add(new Score()
                    {
                        Id = Convert.ToInt32(dr[0].ToString()),
                        UserId = Convert.ToInt32(dr[1].ToString()),
                        UserName = dr[2].ToString(),
                        TotalScore = Convert.ToDouble(dr[3].ToString()),
                        CleanScore = Convert.ToDouble(dr[4].ToString()),
                        DistanceScore = Convert.ToDouble(dr[5].ToString()),
                        MaskScore = Convert.ToDouble(dr[6].ToString()),
                    });
                }
                return scoreList;

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

        public bool InsertNewScore22(int placeId, Score score, out string message)
        {
            conn = new ConnectionFactory().GetConnectionDB(out message);

            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO avaliacao (cod_local, cod_usuario, nota_geral, nota_limpeza,nota_distanciamento, nota_uso_mascara)" +
                    "VALUES (" + placeId + "," + score.UserId + "," + score.TotalScore + "," + score.CleanScore + "," + score.DistanceScore + "," + score.MaskScore + ")";

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

        public bool InsertNewScore(int placeId, Score score, out string message)
        {
            conn = new ConnectionFactory().GetConnectionDB(out message);
            try
            {
                cmd = new SqlCommand("SP_ADD_PLACE_AVALIATION", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@PLACEID", SqlDbType.Int).Value = placeId;
                cmd.Parameters.Add("@USERID", SqlDbType.Int).Value = score.UserId;
                cmd.Parameters.Add("@GENERAL_NOTE", SqlDbType.Decimal).Value = score.TotalScore;
                cmd.Parameters.Add("@CLEAN_NOTE", SqlDbType.Decimal).Value = score.CleanScore;
                cmd.Parameters.Add("@DISTANCE_NOTE", SqlDbType.Decimal).Value = score.DistanceScore;
                cmd.Parameters.Add("@MASK_NOTE", SqlDbType.Decimal).Value = score.MaskScore;

                cmd.Parameters.Add("@RETURN", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;

                var rowsAffected = cmd.ExecuteNonQuery();

                message = cmd.Parameters["@RETURN"].Value.ToString();
                
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

        public bool DeleteScoreById(int scoreId, out string message)
        {
            conn = new ConnectionFactory().GetConnectionDB(out message);

            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM avaliacao WHERE cod_avalicao = " + scoreId;

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