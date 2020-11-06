using Newtonsoft.Json;
using SOA_backend.Models;
using SOA_backend.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SOA_backend.Controllers
{
    [RoutePrefix("api")]
    public class ScoreController : ApiController
    {

        // GET: api/"Place/{id}/Score
        [AcceptVerbs("GET")]
        [Route("Place/{id}/Score")]
        public string ApiGetAllPlaceScore(int id)
        {
            ScoreDAO scoreDAO = new ScoreDAO();

            List<Score> scoreList = scoreDAO.SelectAllScore(id, out string message);

            if (scoreList == null) return message;

            var scoreJson = JsonConvert.SerializeObject(scoreList);

            return scoreJson;
        }


        // POST: api/"Place/{id}/Score
        [AcceptVerbs("POST")]
        [Route("Place/{id}/Score")]
        public string ApiAddNewScore(int id, [FromBody] Score score)
        {
            ScoreDAO scoreDAO = new ScoreDAO();

            Score _scoreWithTotal = new Score();
            _scoreWithTotal.UserId = score.UserId;
            _scoreWithTotal.DistanceScore = score.DistanceScore;
            _scoreWithTotal.MaskScore = score.MaskScore;
            _scoreWithTotal.CleanScore = score.CleanScore;
            _scoreWithTotal.TotalScore = Math.Round((score.MaskScore + score.CleanScore + score.DistanceScore) / 3, 2);

            if (scoreDAO.InsertNewScore(id, _scoreWithTotal, out string message))
            {
                return "Avaliação adicionada com sucesso! ";
            }
            else
            {
                return "Erro ao cadastrar o Avaliação " + message;
            }

        }


        // DELETE: api/"Place/Comment/{id}
        [AcceptVerbs("DELETE")]
        [Route("Place/Score/{id}")]
        public string ApiDeleteScoreById(int id)
        {
            ScoreDAO scoreDAO = new ScoreDAO();

            if (scoreDAO.DeleteScoreById(id, out string message))
            {
                return "Avaliação excluida com sucesso! ";
            }
            else
            {
                return "Erro ao deletar Avaliação " + message;
            }
        }
    }
}
