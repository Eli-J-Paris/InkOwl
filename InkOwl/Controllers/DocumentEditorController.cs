using HtmlAgilityPack;
using InkOwl.DataAccess;
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
        public IActionResult UpdateNest(int nestId, int articleId, int noteId, string articleContent, string noteContent)
        {
            UpdateArticle(articleId, articleContent);
            UpdateNote(noteId, noteContent);

            return Redirect($"/nest/{nestId}");
        }


        [HttpPost]
        [Route("/article/{nestId}/{articleId}/upload")]
        public IActionResult UploadArticle(int nestId, string url, int articleId)
        {
            var article = _context.Articles.Find(articleId);
            article.Content = GetArticleContent(url);
            UpdateArticle(articleId, article.Content);

            return Redirect($"/nest/{nestId}");
        }

        public void UpdateArticle(int articleId, string articleContent)
        {
            var article = _context.Articles.Find(articleId);
            if (article == null)
            {
                NotFound();
            }

            article.Content = articleContent;
            _context.Articles.Update(article);
            _context.SaveChanges();
        }


        public void UpdateNote(int noteId, string noteContent)
        {
            var note = _context.TextDocs.Find(noteId);
            if (note == null)
            {
                NotFound();
            }
            note.Content = noteContent;
            _context.TextDocs.Update(note);
            _context.SaveChanges();
        }

        static string GetArticleContent(string url)
        {
            var document = GetDocument(url);
            // string contentXpath = "//*[@id=\"4890\"]";
            string articleContent = string.Empty;
            // article.Content = document.DocumentNode.SelectSingleNode(contentXpath).InnerHtml;
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
