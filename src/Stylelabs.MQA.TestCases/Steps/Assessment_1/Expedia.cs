using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Stylelabs.MQA.Core;
using Stylelabs.MQA.PageElements.Pages;
using System;
using TechTalk.SpecFlow;

namespace Stylelabs.MQA.TestCases.Steps
{
    [Binding]
    public class Expedia
    {
        private IWebDriver _driver = Base.Driver;
        private ExpediaPage _expediaPage = new ExpediaPage();


        [Given(@"I navigate to the Expedia website")]
        public void GivenINavigateToTheExpediaWebsite()
        {
            //I navigate to the google page URL
            _expediaPage.NavigateTo();

            //And I verify that I'm on the correct page checking the page title
            string pageTitle = _driver.Title;
            Assert.AreEqual("Expedia Travel: Search Hotels, Cheap Flights, Car Rentals & Vacations", pageTitle);
        }

        [When(@"I look for a flight-accomadation from Brussels to New York")]
        public void WhenILookForAFlightAccomadationFromBrusselsToNewYork()
        {
            _expediaPage.flightAccomadation("Brussels, Belgium (BRU-All Airports)", "New York, New York");
        }

        [When(@"I click on the key Search")]
        public void WhenIClickOnTheKeySearch()
        {
            _expediaPage.clickSearchBtn();
        }

        [Then(@"the result page contains travel option from the chosen destination")]
        public void ThenTheResultPageContainsTravelOptionFromTheChosenDestination()
        {
            _expediaPage.assertResultDisplayed();
        }

    }
}
