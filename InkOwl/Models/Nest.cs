namespace InkOwl.Models
{
    public class Nest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Article> Articles { get; set; } = new List<Article>();
        public List<TextDoc> Notes { get; set; } = new List<TextDoc>();
    }
}
