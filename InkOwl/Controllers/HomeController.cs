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

        [Route("/test")]
        public IActionResult Testing() 
        {
            return View();
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
            var nest = _context.Nests.Where(n => n.Id == id).Include(n => n.Articles).Include(n => n.Notes).First();
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

        [Route("/chatbot")]
        public IActionResult ChatBot()
        {
            return View();
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