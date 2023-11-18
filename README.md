# InkOwl <img width="64" height="64" src="https://github.com/Eli-J-Paris/InkOwl/assets/130601227/c3eaf981-8a7d-4993-9ea5-d168bfe21437">
Ink Owl is a dual purpose research and note taking application where a user can store their online articles and notes one place. Assisted by a chat bot powered by Open AI and text to speech integration, online learning has never been this easy! 

This is my 120+ hour, two week long capstone project for Turing School of Software and Design. Having struggled taking hand written notes throughout highschool and my time at college, I was frustrated by how little I was learning during lectures. After switching to digital notes I quickly saw an improvement in my learning. From there I started to wonder about the full potential of taking notes digitally which eventually lead me to make InkOwl!

## Getting Started

### Prerequisites
* [pgAdmin](https://www.pgadmin.org/)
* [Visual Studio](https://visualstudio.microsoft.com/)

### Set up
1. Make a clone of this repo and open it in Visual Studio.
2. In either appsettings.json in the project or in your user sercret folder add:
   ```
   {
   "INKOWL_DBCONNECTIONSTRING": "Server=localhost;Database=InkOwl;Port=5432;Username=YOURPGADMINUSERNAME;Password=YOURPGADMINPASSWORD",
   }
   ```
3. (Optional) if you want to use the chat bot add this code:
    ```
   {
   "CHATGPT_APIKEY": "YOUR OWN UNIQUE OPEN AI API KEY"
   }
   ```
 4. In visual studio naviagate to tools -> NuGet package manager -> Package Manager Console -> run update-database in the package manager console.
 5. You are now ready to start studying!
