namespace Colosoft.Media.Drawing
{
    public static class Resizer
    {
        public static ResizeResult Resize(double width, double height, double maxWidth, double maxHeight, float percentual = 1f)
        {
            maxHeight = maxHeight > 0 ? maxHeight : height;
            maxWidth = maxWidth > 0 ? maxWidth : width;

            if (width > height)
            {
                if (width <= maxWidth)
                {
                    maxWidth = width * percentual;
                    maxHeight = height * percentual;
                }
                else
                {
                    maxHeight = (maxWidth / width) * height;
                }
            }
            else
            {
                if (height <= maxHeight)
                {
                    maxHeight = height * percentual;
                    maxWidth = width * percentual;
                }
                else
                {
                    maxWidth = (maxHeight / height) * width;
                }
            }

            return new ResizeResult(maxWidth, maxHeight);
        }
    }
}
