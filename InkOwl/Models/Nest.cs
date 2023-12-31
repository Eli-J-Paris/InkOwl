﻿namespace InkOwl.Models
{
    public class Nest
    {
        public int Id { get; set; }
        public string? Title { get; set; } = "Untitled Nest";
        public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();
        public List<Article> Articles { get; set; } = new List<Article>();
        public List<TextDoc> Notes { get; set; } = new List<TextDoc>();
        public int ActiveArticleId { get; set; } = 0;
        public int ActiveNoteId { get; set; } = 0;
    }
}
