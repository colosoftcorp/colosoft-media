namespace Colosoft.Media.Drawing
{
    public interface IImage
    {
        double Width { get; }

        double Height { get; }

        void Save(System.IO.Stream stream, Imaging.ImageFormat imageFormat);
    }
}
