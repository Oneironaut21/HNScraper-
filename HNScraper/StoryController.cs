using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;

namespace HNScraper
{
    [ApiController]
    [Route("[controller]")]
    public class StoryController : ControllerBase
    {
        static HttpClient Client { get; set; }

        List<int> TopStoryIDList = new List<int>();
        public static List<StoryModel> TopStories = new List<StoryModel>();  

        public StoryController()
        {
            if (Client == null) { 
                Client = new HttpClient();
                Client.BaseAddress = new Uri("https://hacker-news.firebaseio.com/"); 
            }

            
        }

        public async Task LoadTopStoryList(int storiesToLoad = 20)
        {


            await LoadTopStoryIDs();

            await LoadTopStoryInfo();



        }

        private async Task LoadTopStoryIDs()
        {
            string url = "v0/newstories.json";

            using (HttpResponseMessage response = await Client.GetAsync(url))
            {
                TopStoryIDList = await response.Content.ReadAsAsync<List<int>>();
            }
        }

        private async Task LoadTopStoryInfo()
        {
            string url = "";
            int storiesToLoad = 20;

            if (TopStoryIDList.Count < storiesToLoad)
                storiesToLoad = TopStoryIDList.Count;

            for (int i = 0; i < storiesToLoad ;  i++  )
            {
                url = $"https://hacker-news.firebaseio.com/v0/item/{ TopStoryIDList[i] }.json?print=pretty";

                using (HttpResponseMessage response = await Client.GetAsync(url))
                {
                    StoryModel storyData = await response.Content.ReadAsAsync<StoryModel>();

                    if (storyData.Url is null)
                        storyData.Url = "";

                    TopStories.Add(storyData);
                }
                
            }
        }

        [HttpGet]
        public IEnumerable<StoryModel> Get()
        {
            return TopStories.ToArray();
        }

    }
}
