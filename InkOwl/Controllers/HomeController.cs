using InkOwl.DataAccess;
using InkOwl.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Speech.Synthesis;

namespace InkOwl.Controllers
{
    public class HomeController : Controller
    {
        private readonly InkOwlContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public HomeController(InkOwlContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }


        [Route("/voice")]
        public IActionResult Voice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Speak(string text, int nestId)
        {
            text ??= "Welcome to Ink Owl";
            string textToSpeak = text;

            string outputPath = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", "output.wav");

            using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
            {
                synthesizer.SetOutputToWaveFile(outputPath);
                synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);

                synthesizer.Speak(textToSpeak);
            }

            return RedirectToAction("ShowNest", new {id= nestId});  // Redirect to the view containing the audio player
        }

        public IActionResult GetAudio()
        {
            // Use _hostingEnvironment.ContentRootPath to get the root path of the application
            string audioPath = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", "output.wav");

            // Return the audio file
            return PhysicalFile(audioPath, "audio/wav");
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
            if (nest == null) return NotFound();

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