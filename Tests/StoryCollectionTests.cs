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
        private StoryModel testModel1;
        private StoryModel testModel2;
        private StoryModel testModel3;

        [SetUp]
        public void Setup()
        {
            testModel1 = new StoryModel();
            testModel1.Title = "foo";
            testModel1.Url = "www.google.com";
            testModel1.By = "John Doe";
            testModel1.id = 12345;

            testModel2 = new StoryModel();
            testModel2.Title = "bar";
            testModel2.Url = "www.Amazon.com";
            testModel2.By = "Jane Doe";
            testModel2.id = 67890;

            testModel3 = new StoryModel();
            testModel3.Title = "hello";
            testModel3.Url = "www.stackoverflow.com";
            testModel3.By = "Bob Smith";
            testModel3.id = 11111;
        }
        [Test]
        public void AddStoryTest()
        {
            StoryCollection storyColl = new StoryCollection();

            storyColl.Add(testModel1);
            storyColl.Add(testModel2);

            Assert.IsTrue(storyColl.Stories.Count == 2);
        }

        [Test]
        public void NotExistTest()
        {
            StoryCollection storyColl = new StoryCollection();

            storyColl.Add(testModel1);
            storyColl.Add(testModel2);

            Assert.IsFalse(storyColl.Exists(testModel3.id));
        }
        [Test]
        public void DoesExistTest()
        {
            StoryCollection storyColl = new StoryCollection();

            storyColl.Add(testModel1);
            storyColl.Add(testModel2);

            Assert.IsTrue(storyColl.Exists(testModel2.id));
        }
    }
}
