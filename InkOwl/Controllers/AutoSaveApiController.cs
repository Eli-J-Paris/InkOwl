using InkOwl.DataAccess;
using InkOwl.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

namespace InkOwl.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AutoSaveApiController : ControllerBase
    {
        private InkOwlContext _context;

        public AutoSaveApiController(InkOwlContext context)
        {
            _context = context;
        }

        //[HttpPost]
        //[Route("/savenest")]
        //public async Task<IActionResult> NestEditorAutoSave([FromBody] string formdata)
        //{
        //    //string formData = context.Request.Form.ToString();
        //    Log.Information(formdata);
        //    return Ok();
        //}

        //[HttpPost]
        //[Route("/savenest/{nestId}/{articleId}/{noteId}")]
        //public async Task<IActionResult> ProcessRequest([FromBody] YourModel contentsJSON, int nestId, int articleId, int noteId )
        //{
        //    try
        //    {
        //        var nest = _context.Nests.Find(nestId);
        //        var note = _context.TextDocs.Find(noteId);

        //        var articleContent = contentsJSON.ArticleContent;
        //        var article = _context.Articles.Find(articleId);
        //        article.Content = articleContent;

        //        Log.Information("Article content: "+articleContent);
        //        _context.Articles.Update(article);
        //        _context.SaveChanges();



        //        // Deserialize the JSON string into an object
        //        //var contents = JsonConvert.DeserializeObject<YourModel>(contentsJSON);

        //        // Now 'contents' holds the deserialized data
        //        // Do something with 'contents' or log it
        //        Log.Information("Received JSON: {@Contents}", contentsJSON);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle deserialization errors
        //        Log.Error(ex, "Error processing JSON");
        //    }
        //    return Ok();
        //}
        

        //[HttpPost]
        //[Route("/savenest")]
        //public async Task<IActionResult> ProcessRequest(HttpResponseMessage url)
        //{

        //    string oResJSON = await url.Content.ReadAsStringAsync();
        //    var oResponse = JsonConvert.DeserializeObject<Nest>(oResJSON);
        //    Log.Warning(oResJSON + "Tank");
        //    return Ok();

        //}
    }
}
