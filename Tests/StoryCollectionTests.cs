using System;
using System.Collections.Generic;
using System.Text;
using HNScraper;
using HNScraper.Models;
using NUnit.Framework;

namespace Tests
{
    class StoryCollectionTests
    {
        [Test]
        public void AddStoryTest()
        {
            var storyColl = new StoryCollection();
            StoryModel newModel = new StoryModel();

            newModel.Title = "foo";
            newModel.Url = "www.google.com";
            newModel.By = "John Doe";

            storyColl.Add(newModel);

            Assert.IsTrue(storyColl.Stories.Count == 1);
        }
    }
}
