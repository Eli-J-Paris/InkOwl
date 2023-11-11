using HtmlAgilityPack;
using InkOwl.DataAccess;
using InkOwl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InkOwl.Controllers
{
    public class DocumentEditorController : Controller
    {
        private readonly InkOwlContext _context;

        public DocumentEditorController(InkOwlContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("/nest/update/{nestId}/{articleId}/{noteId}")]
        public IActionResult UpdateNest(int nestId, int articleId, int noteId, string articleContent, string noteContent, string articleTitle, string noteTitle, string url)
        {
            UpdateArticle(articleId, articleContent, articleTitle, url);
            UpdateNote(noteId, noteContent, noteTitle);

            return Redirect($"/nest/{nestId}");
        }


        [HttpPost]
        [Route("/article/{nestId}/{articleId}/upload")]
        public IActionResult UploadArticle(int nestId, string url, int articleId, string articleTitle)
        {
            var article = _context.Articles.Find(articleId);
            article.Content = GetArticleContent(url);
            UpdateArticle(articleId, article.Content, articleTitle, url);

            return Redirect($"/nest/{nestId}");
        }


        [HttpPost]
        [Route("/nest/{nestId}/addarticle")]
        public IActionResult AddNewArticleToNest(int nestId)
        {
            Article newArticle = new Article { Title = "Untitled Article" };
            var nest = _context.Nests.Find(nestId);

            nest.Articles.Add(newArticle);
            _context.Nests.Update(nest);
            _context.SaveChanges();

            return Redirect($"/nest/{nestId}");
        }

        [HttpPost]
        [Route("/nest/{nestId}/addnote")]
        public IActionResult AddNewNoteToNest(int nestId)
        {
            TextDoc newNote = new TextDoc { Title = "Untitled Notes" };
            var nest = _context.Nests.Find(nestId);

            nest.Notes.Add(newNote);
            _context.Nests.Update(nest);
            _context.SaveChanges();

            return Redirect($"/nest/{nestId}");
        }

        [HttpPost]
        [Route("/nest/{nestId}/activearticle")]
        public IActionResult ChangeActiveArticle(int nestId, int articleIndex)
        {
            Response.Cookies.Append("ActiveArticle", articleIndex.ToString());
            return Redirect($"/nest/{nestId}");
        }


        [HttpPost]
        [Route("/nest/{nestId}/activenote")]
        public IActionResult ChangeActiveNote(int nestId, int noteIndex)
        {
            Response.Cookies.Append("ActiveNote", noteIndex.ToString());
            return Redirect($"/nest/{nestId}");
        }

        public void UpdateArticle(int articleId, string articleContent, string articleTitle, string url)
        {
            var article = _context.Articles.Find(articleId);
            if (article == null)
            {
                NotFound();
            }

            article.Content = articleContent;
            article.Title = articleTitle;
            article.Url = url;
            _context.Articles.Update(article);
            _context.SaveChanges();
        }

        public void UpdateNote(int noteId, string noteContent, string noteTitle)
        {
            var note = _context.TextDocs.Find(noteId);
            if (note == null)
            {
                NotFound();
            }
            note.Content = noteContent;
            note.Title = noteTitle;
            _context.TextDocs.Update(note);
            _context.SaveChanges();
        }

        static string GetArticleContent(string url)
        {
            var document = GetDocument(url);
            string articleContent = string.Empty;
            // article.Content = document.DocumentNode.SelectSingleNode(contentXpath).InnerHtml;



            //this will scrape the entire body if its not a turing article
            var htmlArticle = document.DocumentNode.SelectSingleNode("//body");


            HtmlNodeCollection childNodes = htmlArticle.ChildNodes;

            foreach (var node in childNodes)
            {
                if (node.NodeType == HtmlNodeType.Element)
                {
                    articleContent += node.OuterHtml;
                }
            }

            // article.Content = document.DocumentNode.InnerHtml;
            return articleContent;
        }

        static HtmlDocument GetDocument(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            return doc;
        }

    }
}
