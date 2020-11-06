using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOA_backend.Models
{
    public class Place
    {
        //atributos
        private int id;
        private string nome;
        private string descricao;
        private string imagem;
        private string categoria;
        private string latitude;
        private string longitude;
        private decimal mediaGeral;
        private decimal mediaLimpeza;
        private decimal mediaDistancia;
        private decimal mediaMascara;

        //construtor
        public Place()
        { }


        public Place(int pID, string pNome, string pDescricao, string pImagem, string pCategoria, string pLatitude, 
            string pLongitude,decimal pMediaGeral, decimal pMediaLimpeza, decimal pMediaDistancia, decimal pMediaMascara)
        {
            Id = pID;
            Nome = pNome;
            Descricao = pDescricao;
            Imagem = pImagem;
            Categoria = pCategoria;
            Latitude = pLatitude;
            Longitude = pLongitude;
            MediaGeral = pMediaGeral;
            MediaLimpeza = pMediaLimpeza;
            MediaDistancia = pMediaDistancia;
            mediaMascara = pMediaMascara;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string Imagem { get => imagem; set => imagem = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Latitude { get => latitude; set => latitude = value; }
        public string Longitude { get => longitude; set => longitude = value; }
        public decimal MediaGeral { get => mediaGeral; set => mediaGeral =value; }
        public decimal MediaLimpeza { get => mediaLimpeza; set => mediaLimpeza = value; }
        public decimal MediaDistancia { get => mediaDistancia; set => mediaDistancia = value; }
        public decimal MediaMascara { get => mediaMascara; set => mediaMascara = value; }



    }
}