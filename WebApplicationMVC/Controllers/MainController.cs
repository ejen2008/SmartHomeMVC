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
        Factory factory;
        List<IDevicable> devicesList;
        //
        // GET: /Main/
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["Device"] == null)
            {
                factory = new Factory();
                devicesList = new List<IDevicable>();
                devicesList.Add(factory.CreatorTV("Samsung"));
                devicesList.Add(factory.CreatorSound("Sony"));
                devicesList.Add(factory.CreatorHeater("HotHeater"));
                devicesList.Add(factory.CreatorConditioner("Panasonic"));
                devicesList.Add(factory.CreatorBlower("DaysonBlower"));
                deviceDataView.DeviceList = devicesList;
                Session["Device"] = deviceDataView;
                //.......................Test.............................
                deviceDataView.DeviceActive = deviceDataView.DeviceList[0];
                //.......................Test.............................
            }
            else
            {
                deviceDataView = DeviceData();
                //devicesList = deviceDataView.DeviceList;
            }

            return View(deviceDataView);
        }
        [HttpGet]
        public ActionResult CreateDevice()
        {
            deviceDataView = DeviceData();
            return View(deviceDataView);
        }
        [HttpPost]
        public ActionResult CreateDevice(string buttonSubmit, string nameDevice)
        {
            deviceDataView = DeviceData();
            devicesList = deviceDataView.DeviceList;
            factory = new Factory();
            bool nameDouble = devicesList.Exists(device => device.Name == nameDevice);

            if (string.IsNullOrEmpty(nameDevice) == false && nameDouble == false)
            {
                switch (buttonSubmit)
                {
                    case "TV":
                        {
                            devicesList.Add(factory.CreatorTV(nameDevice));
                            break;
                        }
                    case "SD":
                        {
                            devicesList.Add(factory.CreatorSound(nameDevice));
                            break;
                        }
                    case "condit":
                        {
                            devicesList.Add(factory.CreatorConditioner(nameDevice));
                            break;
                        }
                    case "heater":
                        {
                            devicesList.Add(factory.CreatorHeater(nameDevice));
                            break;
                        }
                    default://blower
                        {
                            devicesList.Add(factory.CreatorBlower(nameDevice));
                            break;
                        }
                }
                deviceDataView.Message = null;
                return RedirectToAction("Index");
            }
            else
            {
                deviceDataView.Message = "Устройство с таким именем уже имеется, введите другое имя.";
                return View(deviceDataView);
            }
        }

        public ActionResult ActiveDevice(string parametr)
        {
            deviceDataView = DeviceData();
            List<IDevicable> deviceList = deviceDataView.DeviceList;
            IDevicable activDevice = deviceList.Find(device => device.Name == parametr);
            deviceDataView.DeviceActive = activDevice;
            return RedirectToAction("Index");
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
                deviceDataView.Message = null;
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