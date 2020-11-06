using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOA_backend.Models
{
    public class Pessoa
    {
        //atributos
        private int aID;
        private string aCPF;
        private string aNome;
        private string aCidade;

     
        //construtor
        public Pessoa()
        { }

        public Pessoa(int pID)
        { 
            aID = pID;
        }

        public Pessoa(int pID, string pCPF)
        {
            aID = pID; ACPF = pCPF;
        }

        public Pessoa(int pID, string pCPF, string pNome)
        {
            aID = pID;
            ACPF = pCPF;
            ANome = pNome;
        }

        public Pessoa(int pID, string pCPF, string pNome, string pCidade)
        {
            aID = pID;
            ACPF = pCPF;
            ANome = pNome;
            ACidade = pCidade;
        }



        // gets e setter
        public int AID { get => aID; set => aID = value; }
        public string ACPF { get => aCPF; set => aCPF = value; }
        public string ANome { get => aNome; set => aNome = value; }
        public string ACidade { get => aCidade; set => aCidade = value; }
    }
}