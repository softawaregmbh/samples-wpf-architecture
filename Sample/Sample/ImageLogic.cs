using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample
{
    public class ImageLogic
    {
        private FileSystemImageManager imageManager;

        public ImageLogic()
        {
            this.imageManager = new FileSystemImageManager("Images");
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
