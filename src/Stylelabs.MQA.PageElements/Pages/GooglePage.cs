using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Stylelabs.MQA.Core;
using System;
using System.IO;


namespace Stylelabs.MQA.PageElements.Pages
{
    public class GooglePage : PageBase
    {
        private IWebDriver _driver = Base.Driver;

        private static readonly string _homePageUrl = "https://www.google.com";
        private static string _searchtxtID = "lst-ib";
        private static string _resultStatsID = "resultStats";
        private static string _searchtxtName = "q";
        private static string _screenShotPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)))) + @"\Test_Output\";

        public GooglePage() : base(_homePageUrl) { }
        
        //Type Bahamas and New York in Google respectively
        public void insertTextInSearchBox(string table)
        {
            IWebElement _searchBoxLocator = Base.Driver.FindElement(By.Name(_searchtxtName));
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _searchBoxLocator.SendKeys(table);
        }

        //Hit enter key and wait till the results appear
        public void clickEnterKeyInSearchBox ()
        {
            IWebElement _searchBoxLocator = Base.Driver.FindElement(By.Name(_searchtxtName));
            _searchBoxLocator.SendKeys(Keys.Enter);
            Base.Driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(2);
         }

        //Check the results are whether true
        public void assertResultStatIsDisplayed()
        {
            IWebElement _resultStatsLocator = Base.Driver.FindElement(By.Id(_resultStatsID));
            Console.WriteLine(_resultStatsLocator.Text);
            Assert.IsTrue(_resultStatsLocator.Displayed, "Result Stats is Displayed");
        }

        //Take the screenshot of result page and store
        public void takeScreenShot(string country)
        {
            //Remove the "file:\ from screenshot path"
            var screenShot = _screenShotPath.Substring(6);

            Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
            ss.SaveAsFile(screenShot + country + ".jpg");
        }


    }

}
