using System.Collections.Generic;

namespace Sample
{
    public interface IImageManager
    {
        IEnumerable<Image> GetImages();
        void DeleteImage(Image image);
    }
}
