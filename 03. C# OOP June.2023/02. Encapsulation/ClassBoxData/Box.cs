using System.ComponentModel.DataAnnotations;

namespace ClassBoxData
{
    public class Box
    {
        private const string PropertyValueExceptionMessage = "{0} cannnot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length 
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PropertyValueExceptionMessage, "Length"));
                }
                else
                {
                    this.length = value;
                }
            } 
        
        }
        public double Width 
        {
            get 
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException((string.Format(PropertyValueExceptionMessage, "Width")));
                }
                else
                {
                    this.width = value;
                }
            } 
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PropertyValueExceptionMessage, "Height"));
                }
                else
                {
                    this.height = value;
                }
            }
        }


        public double Volume()
        => Width * Length * Height;
        public double LateralSurfaceArea()
        => (2 * (Length * Height) + 2 * (Width * Height));
        public double SurfaceArea()
        => 2 * ((Length * Height) + (Width * Height) + (Width * Length));
    }
}
