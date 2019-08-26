using System;
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

        [TestMethod]
        [TestCategory("Exceptions")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SearchImages_SearchTextNull_ThrowsArgumentNullException()
        {
            var logic = new ImageLogic(new DummyImageManager(2));

            logic.SearchImages(null);
        }

        [TestMethod]
        [TestCategory("Exceptions")]
        public void SearchImages_SearchTextNull_ThrowsArgumentNullException2()
        {
            int count = 2;
            var logic = new ImageLogic(new DummyImageManager(count));

            Assert.ThrowsException<ArgumentNullException>(() => logic.SearchImages(null));
        }

        [DataTestMethod]
        [DataRow("", 20)]
        [DataRow("xyz", 0)]
        [DataRow("image", 20)]
        [DataRow("image1", 11)]
        public void SearchImages_ValidSearchText_ReturnsCorrectResult(string searchText, int expectedResults)
        {
            int count = 20;
            var logic = new ImageLogic(new DummyImageManager(count));

            var images = logic.SearchImages(searchText);

            Assert.AreEqual(expectedResults, images.Count());
        }
    }
}
