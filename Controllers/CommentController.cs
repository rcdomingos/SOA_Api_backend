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
    public class CommentController : ApiController
    {
        // GET: api/Comment
        public IEnumerable<string> Get(int id)
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/"Place/{id}/Comment
        [AcceptVerbs("GET")]
        [Route("Place/{id}/Comment")]
        public string ApiGetAllPlaceComment(int id)
        {
            CommentDAO commentDAO = new CommentDAO();

            List<Comment> commentList = commentDAO.SelectAllComment(id, out string message);

            if (commentList == null) return message;

            var commentJson = JsonConvert.SerializeObject(commentList);

            return commentJson;
        }

        // POST: api/"Place/{id}/Comment
        [AcceptVerbs("POST")]
        [Route("Place/{id}/Comment")]
        public string ApiAddNewComment(int id, [FromBody] Comment comment)
        {
            CommentDAO commentDAO = new CommentDAO();

            if(commentDAO.InsertNewComment(id,comment,out string message))
            {
                return "Comentario adicionado com sucesso! ";
            }
            else
            {
                return "Erro ao cadastrar o comentario " + message; 
            }

        }

        // DELETE: api/"Place/Comment/{id}
        [AcceptVerbs("DELETE")]
        [Route("Place/Comment/{id}")]
        public string ApiDeleteCommentById(int id)
        {
            CommentDAO commentDAO = new CommentDAO();

            if (commentDAO.DeleteCommentById(id, out string message))
            {
                return "Comentario excluido com sucesso! ";
            }
            else
            {
                return "Erro ao deletar o comentario " + message;
            }
        }
    }
}
