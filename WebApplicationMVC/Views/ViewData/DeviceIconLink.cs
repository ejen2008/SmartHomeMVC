using SmartHome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationMVC.Views.ViewData
{
    public class DeviceIconLink
    {
        //public string IconLink
        //{
        //    get
        //    {
        //        return Link();
        //    }
        //}
        //public IDevicable Device { private get; set; }
        public string LinkIconDevice(IDevicable device)
        {
            string urlImage = "";
            if (device is IVolumenable && device is ISwitchable && device is IColorRedable)
            {
                if (device.State && ((ISwitchable)device).Current == 1)
                {
                    urlImage = "~/Content/TVCats.gif";
                }
                else if (device.State && ((ISwitchable)device).Current == 2)
                {
                    urlImage = "~/Content/TVDogs.gif";
                }
                else if (device.State)
                {
                    urlImage = "~/Content/TVMontains.gif";
                }
                else
                {
                    urlImage = "~/Content/tvOff.png";
                }
            }
            else if (device is IVolumenable && device is ISwitchable && device is IBassable)
            {
                if (device.State)
                {
                    urlImage = "~/Content/SoundDeviceOn.gif";
                }
                else
                {
                    urlImage = "~/Content/SoundDeviceOff.png";
                }
            }
            else if (device is ITemperaturable && device is ISpeedAirable)
            {
                if (device.State && ((ISpeedAirable)device).LevelSpeed == Speed.Low)
                {
                    urlImage = "~/Content/conditionerOnLow.gif";
                }
                else if (device.State && ((ISpeedAirable)device).LevelSpeed == Speed.Medium)
                {
                    urlImage = "~/Content/conditionerOnMedium.gif";
                }
                else if (device.State && ((ISpeedAirable)device).LevelSpeed == Speed.Hight)
                {
                    urlImage = "~/Content/conditionerOnHight.gif";
                }
                else
                {
                    urlImage = "~/Content/conditionerOff.png";
                }
            }
            else if (device is ITemperaturable)
            {
                if (device.State)
                {
                    urlImage = "~/Content/heaterOn.gif";
                }
                else
                {
                    urlImage = "~/Content/heaterOff.png";
                }
            }
            else if (device is ISpeedAirable)
            {
                if (device.State && ((ISpeedAirable)device).LevelSpeed == Speed.Low)
                {
                    urlImage = "~/Content/blowerOnLow.gif";
                }
                else if (device.State && ((ISpeedAirable)device).LevelSpeed == Speed.Medium)
                {
                    urlImage = "~/Content/blowerOnMedium.gif";
                }
                else if (device.State && ((ISpeedAirable)device).LevelSpeed == Speed.Hight)
                {
                    urlImage = "~/Content/blowerOnHight.gif";
                }
                else
                {
                    urlImage = "~/Content/blowerOff.png";
                }
            }
            return urlImage;

        }
    }
}