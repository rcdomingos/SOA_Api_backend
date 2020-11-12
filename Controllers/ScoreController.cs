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
        public HttpResponseMessage ApiGetAllPlaceScore(int id)
        {
            ScoreDAO scoreDAO = new ScoreDAO();

            IEnumerable<Score> scoreList = scoreDAO.SelectAllScore(id, out string message);

            var scoreToJson = JsonConvert.SerializeObject(scoreList);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, scoreToJson);
            return response;
        }


        // POST: api/"Place/{id}/Score
        [AcceptVerbs("POST")]
        [Route("Place/{id}/Score")]
        public HttpResponseMessage ApiAddNewScore(int id, [FromBody] Score score)
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
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError, message);
                return response;
            }

        }


        // DELETE: api/"Place/Comment/{id}
        [AcceptVerbs("DELETE")]
        [Route("Place/Score/{id}")]
        public HttpResponseMessage ApiDeleteScoreById(int id)
        {
            ScoreDAO scoreDAO = new ScoreDAO();

            if (scoreDAO.DeleteScoreById(id, out string message))
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError, message);
                return response;
            }
        }
    }
}
