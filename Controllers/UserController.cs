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
        public string ApiGetAllUsers()
        {         
            UserDAO _usuarioDAO = new UserDAO();
            List<User> userList = _usuarioDAO.SelectAllUsers(out string message);

            if (userList == null) return message;

            var usuariosJson = JsonConvert.SerializeObject(userList);

            return usuariosJson.ToString();
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
        public string ApiAddNewUser([FromBody] User usuario)
        {
            UserDAO _usuarioDAO = new UserDAO();

            if (_usuarioDAO.InsertUser(usuario, out string message))
            {
                return "Usuario cadastrado com sucesso";
            }
            else
            {
                return "Erro: " + message;
            };

        }

        //GET: api/Usuario/login
        [AcceptVerbs("GET")]
        [Route("Usuario/Login")]
        public string ApiUserLogin(string email, string senha)
        {
            UserDAO _usuarioDAO = new UserDAO();
            User user = _usuarioDAO.SelectUserByEmailAndPass(email, senha, out string message);
            if (user == null) return message;
            var userJson = JsonConvert.SerializeObject(user);
            return userJson.ToString();
        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody] string value)
        {
        }

  
    }
}
