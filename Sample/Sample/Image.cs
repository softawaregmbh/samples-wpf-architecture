namespace Sample
{
    public class Image
    {
        public string Path { get; set; }
        public string Name => System.IO.Path.GetFileName(this.Path);
    }
}
