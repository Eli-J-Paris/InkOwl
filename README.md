# InkOwl <img width="64" height="64" src="https://github.com/Eli-J-Paris/InkOwl/assets/130601227/c3eaf981-8a7d-4993-9ea5-d168bfe21437">
Ink Owl is a dual purpose research and note taking application where a user can store their online articles and notes one place. Assisted by a chat bot powered by Open AI and text to speech integration, online learning has never been this easy! 

This is my 120+ hour, two week long capstone project for Turing School of Software and Design. Having struggled taking hand written notes throughout highschool and my time at college, I was frustrated by how little I was learning during lectures. After switching to digital notes I quickly saw an improvement in my learning. From there I started to wonder about the full potential of taking notes digitally which eventually lead me to make InkOwl!
<img width="960" alt="image" src="https://github.com/Eli-J-Paris/InkOwl/assets/130601227/7aa3d8de-d484-4d46-a28a-3c856f69e5a6">


## Features
- Web scraping for online article contents
- Fully functioning text editors for articles and notes
- Ability to store mutiple articles along side multiple notes inside of one 'Nest'
- Auto save leveraging AJAX
- Chat Bot powered by Open Ai's ChatGPT
- Text to speech so that articles can be read to users 
### Future Additions
- More robust and accurate web scraping
- uploading an article by pdf
- Better voices for text to speech
- More Test Coverage
- Create a single article or note document
- More error handeling and logging
## Getting Started

### Prerequisites
* [pgAdmin](https://www.pgadmin.org/)
* [Visual Studio](https://visualstudio.microsoft.com/)

### Set up
1. Make a clone of this repo and open it in Visual Studio.
2. In either appsettings.json in the project or in your user sercrets folder add:
   ```
   {
   "INKOWL_DBCONNECTIONSTRING": "Server=localhost;Database=InkOwl;Port=5432;Username=YOURPGADMINUSERNAME;Password=YOURPGADMINPASSWORD",
   }
   ```
3. (Optional) if you want to use the chat bot add this code to user secrets:
    ```
   {
   "CHATGPT_APIKEY": "YOUR OWN UNIQUE OPEN AI API KEY"
   }
   ```
 4. In visual studio naviagate to tools -> NuGet package manager -> Package Manager Console -> run update-database in the package manager console.
 5. You are now ready to start studying!

## Tech Stack & Tools Used
- ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
- ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
- ![Postgres](https://img.shields.io/badge/postgres-%23316192.svg?style=for-the-badge&logo=postgresql&logoColor=white)
- ![ChatGPT](https://img.shields.io/badge/chatGPT-74aa9c?style=for-the-badge&logo=openai&logoColor=white)
- ![HTML5](https://img.shields.io/badge/html5-%23E34F26.svg?style=for-the-badge&logo=html5&logoColor=white)
- ![CSS3](https://img.shields.io/badge/css3-%231572B6.svg?style=for-the-badge&logo=css3&logoColor=white)
- ![JavaScript](https://img.shields.io/badge/javascript-%23323330.svg?style=for-the-badge&logo=javascript&logoColor=%23F7DF1E)
- ![Bootstrap](https://img.shields.io/badge/bootstrap-%238511FA.svg?style=for-the-badge&logo=bootstrap&logoColor=white)
- ![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white)
- ![Postman](https://img.shields.io/badge/Postman-FF6C37?style=for-the-badge&logo=postman&logoColor=white)
- [OpenAi API](https://openai.com/blog/openai-api)
- [QuillJS](https://quilljs.com/)
- [ASP .NET Core](https://github.com/dotnet/aspnetcore)
- [Entity Framework Core](https://github.com/dotnet/efcore)
- [Serilog](https://serilog.net/)
- [XUnit](https://github.com/xunit/xunit)


