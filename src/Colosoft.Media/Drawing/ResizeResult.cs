namespace Colosoft.Media.Drawing
{
    public struct ResizeResult
    {
        [System.ComponentModel.Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                return (this.Width == 0) && (this.Height == 0);
            }
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public ResizeResult(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
