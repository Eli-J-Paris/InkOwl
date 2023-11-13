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

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            ChatRequest request = new ChatRequest();
            request.Model = "gpt-3.5-turbo";

            ChatGptMessage message = new ChatGptMessage();
            message.Role = "user";
            message.Content = query;

            request.Messages = new List<ChatGptMessage> { message };

            string reqJSON = JsonConvert.SerializeObject(request);
            HttpContent content = new StringContent(reqJSON, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await client.PostAsync(chatURL, content);

            if (responseMessage.IsSuccessStatusCode)
            {
                string resJSON = await responseMessage.Content.ReadAsStringAsync();

                ChatResponse response = JsonConvert.DeserializeObject<ChatResponse>(resJSON);

                foreach (Choice c in response.Choices)
                {
                    sb.Append(c.Message.Content);
                }

                HttpChatGPTResponse httpResponse = new HttpChatGPTResponse()
                {
                    Success = true,
                    Data = sb.ToString()
                };

                return Ok(httpResponse);
            }
            else
            {
                throw new HttpRequestException(responseMessage.ReasonPhrase);
            }
        }



    }
}
