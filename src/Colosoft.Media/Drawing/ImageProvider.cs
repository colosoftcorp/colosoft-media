using System.Collections.Generic;

namespace Colosoft.Media.Drawing
{
    public class ImageProvider
    {
        private static readonly ImageProvider InstanceValue = new ImageProvider();

        private readonly object objLock = new object();
        private readonly List<IImageConverter> converters = new List<IImageConverter>();

        public static ImageProvider Instance
        {
            get { return InstanceValue; }
        }

        public IEnumerable<IImageConverter> Converters
        {
            get { return this.converters.ToArray(); }
        }

        private ImageProvider()
        {
        }

        public static Imaging.ImageFormat GetImageFormat(string fileExtension)
        {
            if (string.IsNullOrEmpty(fileExtension))
            {
                throw new System.ArgumentException($"'{nameof(fileExtension)}' cannot be null or empty.", nameof(fileExtension));
            }

#pragma warning disable CA1308 // Normalize strings to uppercase
            fileExtension = fileExtension.ToLowerInvariant();
#pragma warning restore CA1308 // Normalize strings to uppercase

            switch (fileExtension)
            {
                case ".bmp": return Imaging.ImageFormat.Bmp;
                case ".jpeg":
                case ".jpg": return Imaging.ImageFormat.Jpeg;
                case ".gif": return Imaging.ImageFormat.Gif;
                case ".png": return Imaging.ImageFormat.Png;
                case ".tiff": return Imaging.ImageFormat.Tiff;
                case ".Wmp": return Imaging.ImageFormat.Wmp;
            }

            return Imaging.ImageFormat.Jpeg;
        }

        public void Add(IImageConverter converter)
        {
            lock (this.objLock)
            {
                this.converters.Add(converter);
            }
        }

        public bool Remove(IImageConverter converter)
        {
            lock (this.objLock)
            {
                return this.converters.Remove(converter);
            }
        }

        public IImage Convert(object value)
        {
            foreach (var converter in this.converters)
            {
                if (converter.IsCompatible(value))
                {
                    return converter.Convert(value);
                }
            }

            return null;
        }
    }
}
