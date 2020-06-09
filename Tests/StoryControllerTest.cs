using HNScraper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task StoryControllerReturnsStories()
        {
            var controller = new StoryController();
            var response   =  controller.Get();

            bool returnedStories = true;
            await foreach (var Story in controller.Get())
            {
                if (!(Story is StoryModel))
                {
                    returnedStories = false;
                    break;
                }
            }
            Assert.IsTrue(returnedStories);
        }
    }
}