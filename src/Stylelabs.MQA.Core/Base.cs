using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System;
using System.IO;
using static Stylelabs.MQA.Core.Constants;

namespace Stylelabs.MQA.Core
{
    public static class Base
    {
        public static IWebDriver Driver;
        public static string EnvironmentUrl;
        private static string _driversPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Drivers";

        public static IWebDriver StartDriver(AvDriver chosenDriver)
        {
            switch (chosenDriver)
            {
                case AvDriver.Chrome:
                    Driver = new ChromeDriver(_driversPath);
                    break;
                case AvDriver.Firefox:
                    Driver = new FirefoxDriver(FirefoxDriverService.CreateDefaultService(_driversPath));
                    break;
                case AvDriver.Edge:
                    Driver = new EdgeDriver(_driversPath);
                    break;
                case AvDriver.Safari:
                    //This one will only work when ran on a MAC as Safari doesn't have a downloadable driver for windows
                    Driver = new SafariDriver();
                    break;
            }
            return Driver;
        }

        public static void QuitDriver()
        {
            Driver.Quit();
        }

        public static string GetEnvironmentUrl(AvEnvironment env)
        {
            string envUrl;
            switch (env)
            {
                case AvEnvironment.Google:
                    envUrl = "https://www.google.com";
                    break;
                default:
                    envUrl = "https://www.google.com";
                    break;
            }
            return envUrl;
        }
    }
}