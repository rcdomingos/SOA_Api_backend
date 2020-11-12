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
        private string name;
        private string description;
        private string image;
        private string category;
        private string latitude;
        private string longitude;
        private decimal averageTotalScore;
        private decimal averageCleaningScore;
        private decimal averageDistanceScore;
        private decimal averageMaskUseScore;

        //construtor
        public Place()
        { }


        public Place(int pID, string pName, string pDescription, string pImage, string pCategory, string pLatitude, 
            string pLongitude,decimal pAverageTotalScore, decimal pAverageCleaningScore, decimal pAverageDistanceScore, decimal pAverageMaskUseScore)
        {
            Id = pID;
            Name = pName;
            Description = pDescription;
            Image = pImage;
            Category = pCategory;
            Latitude = pLatitude;
            Longitude = pLongitude;
            AverageTotalScore = pAverageTotalScore;
            AverageCleaningScore = pAverageCleaningScore;
            AverageDistanceScore = pAverageDistanceScore;
            AverageMaskUseScore = pAverageMaskUseScore;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Image { get => image; set => image = value; }
        public string Category { get => category; set => category = value; }
        public string Latitude { get => latitude; set => latitude = value; }
        public string Longitude { get => longitude; set => longitude = value; }
        public decimal AverageTotalScore { get => averageTotalScore; set => averageTotalScore =value; }
        public decimal AverageCleaningScore { get => averageCleaningScore; set => averageCleaningScore = value; }
        public decimal AverageDistanceScore { get => averageDistanceScore; set => averageDistanceScore = value; }
        public decimal AverageMaskUseScore { get => averageMaskUseScore; set => averageMaskUseScore = value; }



    }
}