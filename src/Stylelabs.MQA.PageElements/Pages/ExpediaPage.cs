using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Stylelabs.MQA.Core;
using System;


namespace Stylelabs.MQA.PageElements.Pages
{
    public class ExpediaPage : PageBase
    {
        private static string _inputOrigin = "package-origin-hp-package";
        private static string _inputDest = "package-destination-hp-package";
        private static string _dateDep = "package-departing-hp-package";
        private static string _dateRet = "package-returning-hp-package";
        private static string _travelers = "traveler-selector-hp-package";
        private static string _room = "/html/body/section[1]/div/div/div[1]/section/div/div[2]/div[2]/section[3]/form/section/div[4]/div[8]/div/div/ul/li/div/div/div[1]/div[1]";
        private static string _numberOfAdults = "/html/body/section[1]/div/div/div[1]/section/div/div[2]/div[2]/section[3]/form/section/div[4]/div[8]/div/div/ul/li/div/div/div[1]/div[2]/div[2]/button";
        private static string _numberOfChildren = "/html/body/section[1]/div/div/div[1]/section/div/div[2]/div[2]/section[3]/form/section/div[4]/div[8]/div/div/ul/li/div/div/div[1]/div[3]/div[1]/div[4]/button";
        private static string _childAge = "/html/body/section[1]/div/div/div[1]/section/div/div[2]/div[2]/section[3]/form/section/div[4]/div[8]/div/div/ul/li/div/div/div[1]/div[3]/div[2]/label[1]/select";
        private static string _closeBtn = "/html/body/section[1]/div/div/div[1]/section/div/div[2]/div[2]/section[3]/form/section/div[4]/div[8]/div/div/ul/li/div/footer/div/div[2]/button";
        private static string _searchBtn = "search-button-hp-package";
        private static string _result = "/html/body/div[4]/form/div[13]/div[2]/div[8]/div/header/h1";

        private IWebDriver _driver = Base.Driver;

        private static readonly string _homePageUrl = "https://www.expedia.com/";

        public ExpediaPage() : base(_homePageUrl) { }

        //Select flight page from Brussles to New York
        public void flightAccomadation(string from, string to)
        {
            IWebElement _inputLocatorOrigin = Base.Driver.FindElement(By.Id(_inputOrigin));
            IWebElement _inputLocatorDest = Base.Driver.FindElement(By.Id(_inputDest));
            _inputLocatorOrigin.SendKeys(from);
            _inputLocatorDest.SendKeys(to);

            IWebElement _dateLocatorDeparture = Base.Driver.FindElement(By.Id(_dateDep));
            _dateLocatorDeparture.SendKeys("11/28/2018");
            //_dateLocatorReturning.SendKeys("01/19/2019");

            IWebElement _travelersSelector = Base.Driver.FindElement(By.Id(_travelers));
            _travelersSelector.Click();

            //Explicitly wait till the element is visible
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IWebElement _roomSelector = wait.Until(
                    ExpectedConditions.ElementIsVisible(By.XPath(_room)));

            IWebElement _numberOfAdultsLocator = Base.Driver.FindElement(By.XPath(_numberOfAdults));
            _numberOfAdultsLocator.Click();

            IWebElement _numberOfChildrenLocator = Base.Driver.FindElement(By.XPath(_numberOfChildren));
            _numberOfChildrenLocator.Click();

            //Select value=3 from Drop down menu
            SelectElement _childAgeLocator = new SelectElement(Base.Driver.FindElement(By.XPath(_childAge)));
            _childAgeLocator.SelectByValue("3");

            //Close the drop down menu
            IWebElement _closeBtnLocator = Base.Driver.FindElement(By.XPath(_closeBtn));
            _closeBtnLocator.Click();    
        }

        //Hit the search button and wait some minutes
        public void clickSearchBtn()
        {
            IWebElement _searchBtnLocator = Base.Driver.FindElement(By.Id(_searchBtn));
            _searchBtnLocator.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        //Check the results are whether true.
        public void assertResultDisplayed()
        {
            IWebElement _resultLocator = Base.Driver.FindElement(By.XPath(_result));
            Assert.IsTrue(_resultLocator.Displayed, "Result Stats is Displayed");
        }
    }
}
