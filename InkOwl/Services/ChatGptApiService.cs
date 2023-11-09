using InkOwl.Interfaces;
using InkOwl.Models;
using InkOwl.Models.ChatGptModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace InkOwl.Services
{
    public class ChatGptApiService :IChatGptApiService
    {
        private readonly IConfiguration _configuration;
        private static  HttpClient Client;

        public ChatGptApiService(IConfiguration configuration)
        {
            _configuration = configuration;
            //SetUpClient();
        }

        //private void SetUpClient()
        //{
        //    Client = new HttpClient()
        //    {
        //        BaseAddress = new Uri("https://api.openai.com")
        //    };

        //    Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration["CHATGPT_APIKEY"]);
        //    Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //}
        public async Task<string> AskChatGPT(string query)
        {
            string apiEndPoint = "https://api.openai.com/v1/chat/completions";
            string apiKey = _configuration["CHATGPT_APIKEY"];
            StringBuilder sb = new StringBuilder();

             Client = new HttpClient();
             Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            ChatRequest oRequest = new ChatRequest();
            oRequest.Model = "gpt-3.5-turbo";

            ChatGptMessage oMessage = new ChatGptMessage();
            oMessage.Role = "user";
            oMessage.Content = query;

            oRequest.Messages = new List<ChatGptMessage> { oMessage };

            string oReqJSON = JsonConvert.SerializeObject(oRequest);
            HttpContent oContent = new StringContent(oReqJSON, Encoding.UTF8, "application/json");

            HttpResponseMessage oResponseMessage = await Client.PostAsync(apiEndPoint, oContent);

            if (oResponseMessage.IsSuccessStatusCode)
            {
                string oResJSON = await oResponseMessage.Content.ReadAsStringAsync();

                ChatResponse oResponse = JsonConvert.DeserializeObject<ChatResponse>(oResJSON);

                foreach (Choice c in oResponse.Choices)
                {
                    sb.Append(c.Message.Content);
                }

                //HttpChatGPTResponse oHttpResponse = new HttpChatGPTResponse()
                //{
                //    Success = true,
                //    Data = sb.ToString()
                //};

                return sb.ToString();
            }
            else
            {
                throw new HttpRequestException(oResponseMessage.ReasonPhrase);
            }

        }
    }
}
