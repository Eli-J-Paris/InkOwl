using InkOwl.DataAccess;
using InkOwl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InkOwl.Controllers
{
    public class HomeController : Controller
    {
        private readonly InkOwlContext _context;

        public HomeController(InkOwlContext context)
        {
            _context = context;
        }

        [HttpGet]
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
            var article = new Article { Title = "Untitled Article" };
            var textDoc = new TextDoc { Title = "Untitled Notes" };

            var nest = new Nest();
            nest.Articles.Add(article);
            nest.Notes.Add(textDoc);

            _context.Nests.Add(nest);
            _context.SaveChanges();

            return Redirect("/home");
        }

        [Route("/nest/{id}")]
        [HttpGet]
        public IActionResult ShowNest(int id)
        {    
           var nest = _context.Nests.Where(n => n.Id == id).Include(n => n.Articles).Include(n => n.Notes).First();
            ViewBag.activeArticle = nest.ActiveArticleId;
            ViewBag.activeNote = nest.ActiveNoteId;
            ChangeNavBar(nest);

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
            var nest = _context.Nests.Where(n => n.Id == id).Include(n => n.Articles).Include(n => n.Notes).First();
            _context.DeleteArticlesFromNest(nest);
            _context.DeleteNotesFromNest(nest);
            _context.Nests.Remove(nest);
            _context.SaveChanges();

            return Redirect("/home");
        }


        //When going into a nest it will send the nests title to the layout and display it in the navbar
        public void ChangeNavBar(Nest nest)
        {
            ViewBag.NestTitle = nest.Title;
        }



        //Old way of changing the active article

        //public int SetActiveArticle()
        //{
        //    int activeArticle = 0;
        //    if (Request.Cookies["ActiveArticle"] != null)
        //    {
        //        activeArticle = Convert.ToInt32(Request.Cookies["ActiveArticle"]);
        //    }
        //    Response.Cookies.Delete("ActiveArticle");

        //    return activeArticle;
        //}

        //public int SetActiveNote()
        //{
        //    int activeNote = 0;
        //    if (Request.Cookies["ActiveNote"] != null)
        //    {
        //        activeNote = Convert.ToInt32(Request.Cookies["ActiveNote"]);
        //    }
        //    Response.Cookies.Delete("ActiveNote");
        //    return activeNote;
        //}

    }
}