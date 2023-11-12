using InkOwl.Models;
using Microsoft.EntityFrameworkCore;

namespace InkOwl.DataAccess
{
    public class InkOwlContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<TextDoc> TextDocs { get; set; }
        public DbSet<Nest> Nests { get; set; }
        public DbSet<LogTracker> LogTrackers { get; set; }

        public InkOwlContext(DbContextOptions<InkOwlContext> options) : base(options)
        {

        }

        public void DeleteArticlesFromNest(Nest nest)
        {
            var articles = nest.Articles;
            Articles.RemoveRange(articles);
            SaveChanges();
        }

        public void DeleteNotesFromNest(Nest nest)
        {
            var notes = nest.Notes;
            TextDocs.RemoveRange(notes);
            SaveChanges();
        }

    }
}
