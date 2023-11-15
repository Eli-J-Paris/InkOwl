namespace InkOwl.Models
{
    public class TextDoc
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Content { get; set; }

        public Nest Nest { get; set; }
    }
}
