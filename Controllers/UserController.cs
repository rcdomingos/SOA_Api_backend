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
    public class UserController : ApiController
    {
        // GET: api/Usuario
        [AcceptVerbs("GET")]
        [Route("Usuario")]
        public HttpResponseMessage ApiGetAllUsers()
        {
            UserDAO _usuarioDAO = new UserDAO();
            IEnumerable<User> users = _usuarioDAO.SelectAllUsers(out string message);

            var usersToJson = JsonConvert.SerializeObject(users);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, usersToJson);
            return response;
        }

        // GET: api/Usuario/5
        [AcceptVerbs("GET")]
        [Route("Usuario/{id}")]
        public string ApiGetUserById(string id)
        {
            UserDAO _usuarioDAO = new UserDAO();
            User user = _usuarioDAO.SelectUserById(id, out string message);
            if (user == null) return message;
            var userJson = JsonConvert.SerializeObject(user);
            return userJson.ToString();
        }


        // POST: api/Usuario
        [AcceptVerbs("POST")]
        [Route("Usuario")]
        public HttpResponseMessage ApiAddNewUser([FromBody] User usuario)
        {
            UserDAO _usuarioDAO = new UserDAO();

            if (_usuarioDAO.InsertUser(usuario, out string message))
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            else
            {
                string _ResponseMessage = message;

                if (message.Contains("Violation of UNIQUE KEY constraint")) _ResponseMessage = "O email " + usuario.Email + " ja esta em uso!";

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError, _ResponseMessage);
                return response;
            };

        }

        //GET: api/Usuario/login
        [AcceptVerbs("GET")]
        [Route("Usuario/Login")]
        public HttpResponseMessage ApiUserLogin(string email, string password)
        {
            var response = new HttpResponseMessage();
            UserDAO _usuarioDAO = new UserDAO();
            User user = _usuarioDAO.SelectUserByEmailAndPass(email, password, out string message);
            if (user == null)
            {
                response = Request.CreateResponse(HttpStatusCode.Unauthorized, message);
            }
            else
            {
                var userJson = JsonConvert.SerializeObject(user);
                response = Request.CreateResponse(HttpStatusCode.OK, userJson);
            }

            return response;
        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody] string value)
        {
        }


    }
}
