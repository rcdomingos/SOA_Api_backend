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
        private string name;
        private string email;
        private string password;

        //construtor
        public User()
        { }

        public User(int pID)
        {
            Id = pID;
        }

        public User(int pID, string pName)
        {
            Id = pID; Name = pName;
        }

        public User(int pID,  string pName, string pEmail)
        {
            Id = pID;
            Name = pName;
            Email = pEmail;
        }

        public User(int pID, string pName, string pEmail, string pPassword)
        {
            Id = pID;
            Name = pName;
            Email = pEmail;
            Password = pPassword;
        }

        public int Id { get => id; set => id = value; }

        public string Name { get => name; set => name = value; }

        public string Email { get => email; set => email = value; }

        public string Password { get => password; set => password = value; }

    }
}