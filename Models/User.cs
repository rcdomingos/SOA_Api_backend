using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOA_backend.Models
{
    public class User
    {
        //atributos
        private int id;
        private string nome;
        private string email;
        private string senha;

        //construtor
        public User()
        { }

        public User(int pID)
        {
            Id = pID;
        }

        public User(int pID, string pNome)
        {
            Id = pID; Nome = pNome;
        }

        public User(int pID,  string pNome, string pEmail)
        {
            Id = pID;
            Nome = pNome;
            Email = pEmail;
        }

        public User(int pID, string pNome, string pEmail, string pSenha)
        {
            Id = pID;
            Nome = pNome;
            Email = pEmail;
            Senha = pSenha;
        }

        public int Id { get => id; set => id = value; }

        public string Nome { get => nome; set => nome = value; }

        public string Email { get => email; set => email = value; }

        public string Senha { get => senha; set => senha = value; }

    }
}