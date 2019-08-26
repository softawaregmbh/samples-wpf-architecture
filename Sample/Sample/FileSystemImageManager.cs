using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sample
{
    public class FileSystemImageManager
    {
        private readonly string path;

        public FileSystemImageManager(string path)
        {
            this.path = path;
        }

        public IEnumerable<Image> GetImages()
        {
            return Directory
                .EnumerateFiles(this.path, "*.jpg")
                .Select(p => new Image() { Path = Path.GetFullPath(p) });
        }

        public void DeleteImage(Image image)
        {
            File.Delete(image.Path);
        }
    }
}
