using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample
{
    public class ImageLogic : IImageLogic
    {
        private readonly IImageManager imageManager;

        public ImageLogic(IImageManager imageManager)
        {
            this.imageManager = imageManager ?? throw new ArgumentNullException(nameof(imageManager));
        }

        public IEnumerable<Image> SearchImages(string searchText)
        {
            if (searchText == null)
            {
                throw new ArgumentNullException(nameof(searchText));
            }

            var images = this.imageManager
                .GetImages()
                .Where(i => i.Name.IndexOf(searchText, StringComparison.CurrentCultureIgnoreCase) >= 0);

            return images;
        }

        public void DeleteImage(Image image)
        {
            this.imageManager.DeleteImage(image);
        }
    }
}
