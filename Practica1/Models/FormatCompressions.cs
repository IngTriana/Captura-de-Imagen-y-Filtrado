using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Practica1.Models
{
    public class FormatCompressions
    {
        public const string Unsopported = "Formato no soportado";
        static private SortedList<int, string> Formats = new SortedList<int, string>
        {
            {0x00000000, "BI_RGB"},
            {0x00000001, "BI_RLE8"},
            {0x00000002, "BI_RLE4"},
            {0x00000003, "BI_BITFIELDS"},
            {0x00000004, "BI_JPEG"},
            {0x00000005, "BI_PNG"},
            {FourCC.AVC, nameof(FourCC.AVC)},
            {FourCC.CVID, nameof(FourCC.CVID)},
            {FourCC.DIB, nameof(FourCC.DIB)},
            {FourCC.DIV3, nameof(FourCC.DIV3)},
            {FourCC.DIVX, nameof(FourCC.DIVX)},
            {FourCC.DV25, nameof(FourCC.DV25)},
            {FourCC.DV50, nameof(FourCC.DV50)},
            {FourCC.DVC, nameof(FourCC.DVC)},
            {FourCC.DVH1, nameof(FourCC.DVH1)},
            {FourCC.DVHD, nameof(FourCC.DVHD)},
            {FourCC.DVSD, nameof(FourCC.DVSD)},
            {FourCC.DVSL, nameof(FourCC.DVSL)},
            {FourCC.H261, nameof(FourCC.H261)},
            {FourCC.H263, nameof(FourCC.H263)},
            {FourCC.H264, nameof(FourCC.H264)},
            {FourCC.H265, nameof(FourCC.H265)},
            {FourCC.HEVC, nameof(FourCC.HEVC)},
            {FourCC.I420, nameof(FourCC.I420)},
            {FourCC.IV32, nameof(FourCC.IV32)},
            {FourCC.IV41, nameof(FourCC.IV41)},
            {FourCC.IV50, nameof(FourCC.IV50)},
            {FourCC.IYUB, nameof(FourCC.IYUB)},
            {FourCC.JPEG, nameof(FourCC.JPEG)},
            {FourCC.M4S2, nameof(FourCC.M4S2)},
            {FourCC.MJPG, nameof(FourCC.MJPG)},
            {FourCC.MP42, nameof(FourCC.MP42)},
            {FourCC.MP43, nameof(FourCC.MP43)},
            {FourCC.MP4S, nameof(FourCC.MP4S)},
            {FourCC.MP4V, nameof(FourCC.MP4V)},
            {FourCC.MPG1, nameof(FourCC.MPG1)},
            {FourCC.MPG2, nameof(FourCC.MPG2)},
            {FourCC.MPG4, nameof(FourCC.MPG4)},
            {FourCC.MSS1, nameof(FourCC.MSS1)},
            {FourCC.MSS2, nameof(FourCC.MSS2)},
            {FourCC.MSVC, nameof(FourCC.MSVC)},
            {FourCC.PIM1, nameof(FourCC.PIM1)},
            {FourCC.WMV1, nameof(FourCC.WMV1)},
            {FourCC.WMV2, nameof(FourCC.WMV2)},
            {FourCC.WMV3, nameof(FourCC.WMV3)},
            {FourCC.WVC1, nameof(FourCC.WVC1)},
            {FourCC.XVID, nameof(FourCC.XVID)},
        };

        static public string GetFormat(int compression) => Formats.ContainsKey(compression) ? Formats[compression] : FourCCToString(compression);

        static private string FourCCToString(int fourcc)
        {
            //Comprobar si el valor es imprimible como caracteres ASCII
            if(fourcc >= 0x20202020 && fourcc <= 0x7E7E7E7E)
            {
                char[] chars = new char[4];
                chars[0] = (char)(fourcc & 0xFF);
                chars[1] = (char)((fourcc >> 8) & 0xFF);
                chars[2] = (char)((fourcc >> 16) & 0xFF);
                chars[3] = (char)((fourcc >> 24) & 0xFF);
                return new string(chars);
            }
            return FormatCompressions.Unsopported;
        }
    }
}
