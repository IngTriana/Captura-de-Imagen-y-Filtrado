using System;
using OpenCvSharp;

namespace Practica1.Models
{
    public class Resolution : IComparable<Resolution>
    {
        public int FrameWidth { get; set; }
        public int FrameHeight { get; set; }
        public FourCC Compression { get; set; }
        public string CompressionType => FormatCompressions.GetFormat(Compression);

        public string Caption => $"{FrameWidth}x{FrameHeight} ({CompressionType})";

        public Resolution(int framewidth, int frameheight, int compression)
        {
            FrameWidth = framewidth;
            FrameHeight = frameheight;
            Compression = compression;
        }

        public Resolution()
        {
        }

        public int CompareTo(Resolution other)
        {
            if(FrameWidth != other.FrameWidth)
                return FrameWidth.CompareTo(other.FrameWidth);
            else if(FrameHeight != other.FrameHeight)
                return FrameHeight.CompareTo(other.FrameHeight);
            return 0;
        }
    }
}
