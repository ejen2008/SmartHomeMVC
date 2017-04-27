using SmartHome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class MainController : Controller
    {
        DeviceDataView deviceDataView = new DeviceDataView(new Views.ViewData.DeviceIconLink());
        Factory factory = new Factory();

        //
        // GET: /Main/
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["Device"] == null)
            {
                List<IDevicable> devicesList = new List<IDevicable>();
                devicesList.Add(factory.CreatorTV("Samsung"));
                devicesList.Add(factory.CreatorSound("Sony"));
                devicesList.Add(factory.CreatorHeater("HotHeater"));
                devicesList.Add(factory.CreatorConditioner("Panasonic"));
                devicesList.Add(factory.CreatorBlower("DaysonBlower"));
                deviceDataView.DeviceList = devicesList;
                Session["Device"] = deviceDataView;
            }
            else
            {
                deviceDataView = DeviceData();
                //devicesList = deviceDataView.DeviceList;
            }
            //.......................Test.............................
            deviceDataView.DeviceActive = deviceDataView.DeviceList[0];
            //.......................Test.............................
            return View(deviceDataView);
        }
        [HttpGet]
        public ActionResult CreateDevice()
        {
            return View();
        }
        [HttpPost]
        public string CreateDevice(string buttonSubmit, string nameDevice)
        {
            return "name: " + buttonSubmit + " nameDev: " + nameDevice;
        }

        public ActionResult DeleteDevice()
        {
            List<IDevicable> devicesList = deviceDataView.DeviceList;
            devicesList.Remove(deviceDataView.DeviceActive);
            deviceDataView.DeviceActive = null;
            return RedirectToAction("Index");
        }
        public ActionResult OnOffDevice()
        {
            deviceDataView = DeviceData();
            IDevicable device = deviceDataView.DeviceActive;
            if (device.State == true)
            {
                device.Off();
            }
            else
            {
                device.On();
            }
            return RedirectToAction("Index");
        }


        public ActionResult Volume(string parametr)
        {
            deviceDataView = DeviceData();
            IDevicable device = deviceDataView.DeviceActive;
            if (device != null && device.State == true)
            {
                switch (parametr)
                {
                    case "Down":
                        {
                            ((IVolumenable)device).VolumeDown();
                            break;
                        }
                    case "Up":
                        {
                            ((IVolumenable)device).VolumeUp();
                            break;
                        }
                    case "Mute":
                        {
                            ((IVolumenable)device).Volume = 0;
                            break;
                        }
                    default:
                        {
                            byte volume;
                            byte.TryParse(parametr, out volume);
                            ((IVolumenable)device).Volume = volume;
                            break;
                        }
                }
                deviceDataView.Message = null;
            }
            else
            {
                deviceDataView.Message = device.Name + " выкл.";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Chanel(string parametr)
        {
            deviceDataView = DeviceData();
            IDevicable device = deviceDataView.DeviceActive;
            if (device != null && device.State == true)
            {
                switch (parametr)
                {
                    case "Previos":
                        {
                            ((ISwitchable)device).Previous();
                            break;
                        }
                    case "Next":
                        {
                            ((ISwitchable)device).Next();
                            break;
                        }
                    default:
                        {
                            int chanel;
                            Int32.TryParse(parametr, out chanel);
                            ((ISwitchable)device).Current = chanel;
                            break;
                        }
                }
                deviceDataView.Message = null;
            }
            else
            {
                deviceDataView.Message = device.Name + " выкл.";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Temperature(string parametr)
        {
            deviceDataView = DeviceData();
            IDevicable device = deviceDataView.DeviceActive;
            if (device != null && device.State == true)
            {
                switch (parametr)
                {
                    case "Down":
                        {
                            ((ITemperaturable)device).TemperatureDown();
                            break;
                        }
                    case "Up":
                        {
                            ((ITemperaturable)device).TemperatureUp();
                            break;
                        }
                    default:
                        {
                            byte temper;
                            byte.TryParse(parametr, out temper);
                            ((ITemperaturable)device).Temperature = temper;
                            break;
                        }
                }
                deviceDataView.Message = null;
            }
            else
            {
                deviceDataView.Message = device.Name + " выкл.";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Bass(string parametr)
        {
            deviceDataView = DeviceData();
            IDevicable device = deviceDataView.DeviceActive;
            if (device != null && device.State == true)
            {
                switch (parametr)
                {
                    case "Down":
                        {
                            ((IBassable)device).BassDown();
                            break;
                        }
                    case "Up":
                        {
                            ((IBassable)device).BassUp();
                            break;
                        }
                    default:
                        {
                            byte bass;
                            byte.TryParse(parametr, out bass);
                            ((IBassable)device).BassLevel = bass;
                            break;
                        }
                }
                deviceDataView.Message = null;
            }
            else
            {
                deviceDataView.Message = device.Name + " выкл.";
            }
            return RedirectToAction("Index");
        }

        public ActionResult SpeedAir(string parametr)
        {
            deviceDataView = DeviceData();
            IDevicable device = deviceDataView.DeviceActive;
            if (device != null && device.State == true)
            {
                switch (parametr)
                {
                    case "Low":
                        {
                            ((ISpeedAirable)device).SpeedAirLow();
                            break;
                        }
                    case "Medium":
                        {
                            ((ISpeedAirable)device).SpeedAirMedium();
                            break;
                        }
                    default://Hight
                        {
                            ((ISpeedAirable)device).SpeedAirHight();
                            break;
                        }
                }
                deviceDataView.Message = null;
            }
            else
            {
                deviceDataView.Message = device.Name + " выкл.";
            }
            return RedirectToAction("Index");
        }
        private DeviceDataView DeviceData()
        {
            return (DeviceDataView)Session["Device"];
        }
    }
}