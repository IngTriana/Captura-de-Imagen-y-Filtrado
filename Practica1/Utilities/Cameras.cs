using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using DirectShowLib;
using Practica1.Models;

namespace Practica1.Utilities
{
    internal class Cameras
    {
        static public List<DsDevice> GetCameras()
        {
            try
            {
                DsDevice[] cameras = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
                return cameras.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        static public List<Resolution> GetSupportedResolutions(IMoniker moniker)
        {
            List<Resolution> resolutions = new List<Resolution>();
            try
            {
                //Bind the moniker to the filter
                object obj;
                moniker.BindToObject(null, null, typeof(IBaseFilter).GUID, out obj);
                IBaseFilter baseFilter = (IBaseFilter)obj;

                //Get the pin
                IPin pin = GetPin(baseFilter, PinDirection.Output);

                if(pin != null)
                {
                    //Enumerate the media types
                    IEnumMediaTypes mediaTypeEnum;
                    pin.EnumMediaTypes(out mediaTypeEnum);

                    AMMediaType[] mediaTypes = new AMMediaType[1];
                    IntPtr fetched = IntPtr.Zero;
                    while(mediaTypeEnum.Next(1,mediaTypes,fetched)==0)
                    {
                        VideoInfoHeader videoInfo = new VideoInfoHeader();
                        Marshal.PtrToStructure(mediaTypes[0].formatPtr, videoInfo);
                        if (videoInfo.BmiHeader.Width != 0 && videoInfo.BmiHeader.Height != 0)
                            resolutions.Add(new Resolution(videoInfo.BmiHeader.Width, videoInfo.BmiHeader.Height, videoInfo.BmiHeader.Compression));
                        DsUtils.FreeAMMediaType(mediaTypes[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return resolutions;
        }

        static private IPin GetPin(IBaseFilter filter, PinDirection direction)
        {
            IEnumPins enumPins;
            filter.EnumPins(out enumPins);
            IPin[] pins = new IPin[1];
            IntPtr fetched = IntPtr.Zero;

            while (enumPins.Next(1, pins, fetched) == 0)
            {
                PinDirection pinDir;
                pins[0].QueryDirection(out pinDir);
                if(pinDir == direction)
                {
                    return pins[0];
                }
            }
            return null;
        }
    }
}
