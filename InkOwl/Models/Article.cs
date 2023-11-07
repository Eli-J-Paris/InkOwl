﻿namespace InkOwl.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Content { get; set; }

        //public Article()
        //{
        //    Title = "Untitled Article";
        //    Content = "Empty Article";
        //}
    }
}
