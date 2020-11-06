using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;

namespace SOA_backend.Models
{
    public class Score
    {
        private int id;
        private int userId;
        private string userName;
        private double totalScore;
        private double cleanScore;
        private double distanceScore;
        private double maskScore;

        public Score() { }

        public Score(int pId, int pUseId, string pUserName, double pTotalScore, double pCleanScore, double pDistanceScore, double pMaskScore)
        {
            Id = pId;
            UserId = pUseId;
            UserName = pUserName;
            TotalScore = pTotalScore;
            CleanScore = pCleanScore;
            DistanceScore = pDistanceScore;
            MaskScore = pMaskScore;
        }


        public Score(int pUseId, double pCleanScore, double pDistanceScore, double pMaskScore)
        {
            UserId = pUseId;
            CleanScore = pCleanScore;
            DistanceScore = pDistanceScore;
            MaskScore = pMaskScore;
        }

        public int Id { get => id; set => id = value; }
        public int UserId { get => userId; set => userId = value; }
        public string UserName { get => userName; set => userName = value; }
        public double TotalScore { get => totalScore; set => totalScore = value; }
        public double CleanScore { get => cleanScore; set => cleanScore = value; }
        public double DistanceScore { get => distanceScore; set => distanceScore = value; }
        public double MaskScore { get => maskScore; set => maskScore = value; }
    }
}