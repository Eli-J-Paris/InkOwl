using HtmlAgilityPack;
using InkOwl.DataAccess;
using InkOwl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace InkOwl.Controllers
{
    public class HomeController : Controller
    {
        private readonly InkOwlContext _context;

        public HomeController(InkOwlContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var nests = _context.Nests.ToList();
            return View(nests);
        }

        [HttpPost]
        [Route("/nest/new")]
        public IActionResult CreateNest()
        {
            //create a new untitled nest
            var article = new Article();
            var textDoc = new TextDoc();

            var nest = new Nest();
            nest.Articles.Add(article);
            nest.Notes.Add(textDoc);

            _context.Nests.Add(nest);
            _context.SaveChanges();
            return Redirect("/home");
        }

        [Route("/nest/{id}")]
        public IActionResult ShowNest(int id)
        {
            var nest = _context.Nests.Where(n => n.Id == id).Include(n =>n.Articles).Include(n=>n.Notes).First();
            return View(nest);
        }

        [HttpPost]
        [Route("/nest/edit/{id}")]
        public IActionResult EditNest(int id, string title)
        {
            var nest = _context.Nests.Find(id);
            nest.Title = title;
            _context.Nests.Update(nest);
            _context.SaveChanges();

            return Redirect("/home");

        }

        [HttpPost]
        [Route("/nest/delete/{id}")]
        public IActionResult DeleteNest(int id)
        {
            var nest = _context.Nests.Where(n =>n.Id ==id).Include(n=>n.Articles).Include(n=>n.Notes).First();
            _context.Nests.Remove(nest);
            _context.SaveChanges();

            return Redirect("/home");

        }

        [HttpPost]
        [Route("/nest/update/{nestId}/{articleId}/{noteId}")]
        public IActionResult UpdateNest(int nestId,int articleId,int noteId, string articleContent, string noteContent)
        {
            UpdateArticle(articleId, articleContent);
            UpdateNote(noteId, noteContent);

            //return Redirect($"/nest/{nestId}");
            return Redirect("/home");
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


        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}