using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Selenium;
using TechTalk.SpecFlow;

namespace Garcom.Test.Support
{
    public class SeleniumServer
    {
        private static Process _seleniumServer;
        private static ISelenium _driver;
        private static bool _started = false;

        public static void Start()
        {
            if(_started) { return; }

            _seleniumServer = new Process
                                  {
                                      StartInfo =
                                          {
                                              FileName = "startSelenium.bat"
                                          }
                                  };
            if (!_seleniumServer.Start())
                throw new Exception("selenium not started");

            _started = true;
            //wait for java to start
            Thread.Sleep(10000);
        }


        public static void Initialize()
        {
            Start();
            if (_driver == null)
            {
                _driver = new DefaultSelenium("localhost", 4444, @"C:\Program Files (x86)\Mozilla Firefox 4.0 Beta 6\firefox.exe", "localhost");
                _driver.Start();
            }
            ScenarioContext.Current["selenium"] = _driver;
            ScenarioContext.Current["selenium-errors"] = new StringBuilder();
            ScenarioContext.Current["StepCounter"] = 0;
        }
    }
}