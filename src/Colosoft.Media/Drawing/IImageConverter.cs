namespace Colosoft.Media.Drawing
{
    public interface IImageConverter
    {
        bool IsCompatible(object value);

        IImage Convert(object value);
    }
}
