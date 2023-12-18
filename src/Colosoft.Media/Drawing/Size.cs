using System;

namespace Colosoft.Media.Drawing
{
    [Serializable]
    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    [System.Runtime.InteropServices.ComVisible(true)]
    public struct Size : IEquatable<Size>
    {
        [System.ComponentModel.Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                return (this.Width == 0) && (this.Height == 0);
            }
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public Size(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public static Size operator +(Size sz1, Size sz2)
        {
            return Add(sz1, sz2);
        }

        public static Size operator -(Size sz1, Size sz2)
        {
            return Subtract(sz1, sz2);
        }

        public static bool operator ==(Size sz1, Size sz2)
        {
            return (sz1.Width == sz2.Width) && (sz1.Height == sz2.Height);
        }

        public static bool operator !=(Size sz1, Size sz2)
        {
            return !(sz1 == sz2);
        }

        public static Size Add(Size sz1, Size sz2)
        {
            return new Size(sz1.Width + sz2.Width, sz1.Height + sz2.Height);
        }

        public static Size Subtract(Size sz1, Size sz2)
        {
            return new Size(sz1.Width - sz2.Width, sz1.Height - sz2.Height);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Size))
            {
                return false;
            }

            var size = (Size)obj;
            return (size.Width == this.Width) && (size.Height == this.Height);
        }

        public bool Equals(Size other)
        {
            return (other.Width == this.Width) && (other.Height == this.Height);
        }

        public override int GetHashCode()
        {
            return this.Width ^ this.Height;
        }

        public override string ToString()
        {
            return $"{{Width={this.Width.ToString(System.Globalization.CultureInfo.CurrentCulture)}, Height={this.Height.ToString(System.Globalization.CultureInfo.CurrentCulture)}}}";
        }
    }
}
