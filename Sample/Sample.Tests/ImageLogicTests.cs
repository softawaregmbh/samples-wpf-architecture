﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sample.Tests
{
    [TestClass]
    public class ImageLogicTests
    {
        private class DummyImageManager : IImageManager
        {
            private readonly int count;

            public DummyImageManager(int count)
            {
                this.count = count;
            }

            public IEnumerable<Image> GetImages()
            {
                for (int i = 0; i < count; i++)
                {
                    yield return new Image() { Path = $@"C:\temp\image{i}.jpg" };
                }                
            }

            public void DeleteImage(Image image)
            {
            }
        }

        [TestMethod]
        public void SearchImages_SearchTextEmpty_ReturnsAllImages()
        {
            int count = 2;
            var logic = new ImageLogic(new DummyImageManager(count));

            var images = logic.SearchImages(string.Empty);

            Assert.AreEqual(count, images.Count());
        }
    }
}