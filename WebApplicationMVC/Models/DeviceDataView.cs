using SmartHome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationMVC.Views.ViewData;

namespace WebApplicationMVC.Models
{
    public class DeviceDataView
    {
        DeviceIconLink objectIconLink;
        public DeviceDataView(DeviceIconLink ObjectIconLink)
        {
            this.objectIconLink = ObjectIconLink;
        }
        public List<IDevicable> DeviceList { get; set; }
        public IDevicable DeviceActive { get; set; }
        public string Message { get; set; }
        //public DeviceIconLink ObjectIconLink { private get; set; }
        public string LinkIconDevice(IDevicable device)
        {
            return objectIconLink.LinkIconDevice(device);

        }
    }
}