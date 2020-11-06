using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace SOA_backend.Models
{
    public class Comment
    {
        private int id;
        private int userId;
        private string userName;
        private string title;
        private string commentText;

        public Comment() { }

        public Comment(int pId, string pUserName, string pTitle, string pCommentText)
        {
            Id = pId;
            UserName = pUserName;
            Title = pTitle;
            CommentText = pCommentText;
        }

        public Comment( int pUserId, string pTitle, string pCommentText)
        {
            UserId = pUserId;
            Title = pTitle;
            CommentText = pCommentText;
        }


        public Comment(int pId, int pUserId, string pUserName, string pTitle, string pCommentText)
        {
            Id = pId;
            UserId = pUserId;
            UserName = pUserName;
            Title = pTitle;
            CommentText = pCommentText;
        }


        public int Id { get => id; set => id = value; }
        public string UserName { get => userName; set => userName = value; }
        public int UserId { get => userId; set => userId = value; }
        public string Title { get => title; set => title = value; }
        public string CommentText { get => commentText; set => commentText = value; }
    }
}