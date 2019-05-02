using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;
using static Stylelabs.MQA.Core.Constants;

namespace Stylelabs.MQA.Core.Utilities
{
    public static class Installer
    {
        private static string _url = null;
        private static string _driver = null;
        private static string _runner = null;
        private static string _defaultEnv = Base.GetEnvironmentUrl(AvEnvironment.Google);
        private static AvDriver _defaultDriver = AvDriver.Chrome;

        public static void SetUpEnv()
        {
            /*
            If we run our tests from command line, we can specify env, driver and runner as parameters. If not - default values are used.

            Note: if we are using BrowserStack runner, driver parameter represents a browser to use. 
            Available values: CHROME, IE, FIREFOX, SAFARI, EDGE, IPAD. (chrome is used by default)
            */

            _url = TestContext.Parameters["url"];
            _driver = TestContext.Parameters["driver"];
            _runner = TestContext.Parameters["runner"];

            if (_url == null)
            {
                Base.EnvironmentUrl = _defaultEnv;
            }
            else
            {
                Base.EnvironmentUrl = _url;
            }

            if (_runner == null)
            {
                SetupLocal();
            }
            else
            {
                switch (_runner)
                {
                    case "LOCAL":
                        SetupLocal();
                        break;
                    default:
                        SetupLocal();
                        break;
                }
            }
        }

        public static void SetupLocal()
        {
            if (_driver == null)
            {
                Base.Driver = Base.StartDriver(_defaultDriver);
            }
            else
            {
                switch (_driver)
                {
                    case "CHROME":
                        Base.Driver = Base.StartDriver(AvDriver.Chrome);
                        break;
                    case "FIREFOX":
                        Base.Driver = Base.StartDriver(AvDriver.Firefox);
                        break;
                    case "EDGE":
                        Base.Driver = Base.StartDriver(AvDriver.Edge);
                        break;
                    case "SAFARI":
                        Base.Driver = Base.StartDriver(AvDriver.Safari);
                        break;
                    default:
                        Base.Driver = Base.StartDriver(AvDriver.Chrome);
                        break;
                }
            }
        }

        public static void CleanUpEnv()
        {
            Base.QuitDriver();
        }
    }
}
