using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HNScraper.Models
{
    public class StoryCollection
    {
        public List<StoryModel> Stories { get; private set; }

        public StoryCollection()
        {
            Stories = new List<StoryModel>();
        }
        public void Add(StoryModel newStory)
        {
            Stories.Add(newStory);
        }
        public bool Exists(int storyID)
        {
            StoryModel foundStory = Stories.Find(story => story.id == storyID);

            return (foundStory is StoryModel);
        }

    }
}
