using System.Collections.Generic;

namespace Sample
{
    public interface IImageLogic
    {
        void DeleteImage(Image image);
        IEnumerable<Image> SearchImages(string searchText);
    }
}