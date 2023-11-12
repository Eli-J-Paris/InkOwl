using InkOwl.Models.ChatGptModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace InkOwl.Controllers
{
    [ApiController]
    public class ChatGptApiController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ChatGptApiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("AskChatGPT")]
        public async Task<IActionResult> AskChatGPT([FromBody] string query)
        {
            string chatURL = "https://api.openai.com/v1/chat/completions";
            string apiKey = _configuration["CHATGPT_APIKEY"];
            StringBuilder sb = new StringBuilder();

            HttpClient oClient = new HttpClient();
            oClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            ChatRequest oRequest = new ChatRequest();
            oRequest.Model = "gpt-3.5-turbo";

            ChatGptMessage oMessage = new ChatGptMessage();
            oMessage.Role = "user";
            oMessage.Content = query;

            oRequest.Messages = new List<ChatGptMessage> { oMessage };

            string oReqJSON = JsonConvert.SerializeObject(oRequest);
            HttpContent oContent = new StringContent(oReqJSON, Encoding.UTF8, "application/json");

            HttpResponseMessage oResponseMessage = await oClient.PostAsync(chatURL, oContent);

            if (oResponseMessage.IsSuccessStatusCode)
            {
                string oResJSON = await oResponseMessage.Content.ReadAsStringAsync();

                ChatResponse oResponse = JsonConvert.DeserializeObject<ChatResponse>(oResJSON);

                foreach (Choice c in oResponse.Choices)
                {
                    sb.Append(c.Message.Content);
                }

                HttpChatGPTResponse oHttpResponse = new HttpChatGPTResponse()
                {
                    Success = true,
                    Data = sb.ToString()
                };

                return Ok(oHttpResponse);
            }
            else
            {
                throw new HttpRequestException(oResponseMessage.ReasonPhrase);
            }
        }



    }
}
