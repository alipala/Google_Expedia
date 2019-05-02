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
    public class Google
    {
        private IWebDriver _driver = Base.Driver;
        private GooglePage _googlePage = new GooglePage();

        [Given(@"I navigate to Google")]
        public void GivenINavigateToGoogle()
        {
            //I navigate to the google page URL
            _googlePage.NavigateTo();
            
            //And I verify that I'm on the correct page checking the page title
            string pageTitle = _driver.Title;
            Assert.AreEqual("Google", pageTitle);
        }

        [When(@"I insert the text '(.*)' in the search box")]
        public void WhenIInsertTheTextInTheSearchBox(string table)
        {
            _googlePage.insertTextInSearchBox(table);
        }


        [When(@"I click on the key Enter")]
        public void WhenIClickOnTheKeyEnter()
        {
            _googlePage.clickEnterKeyInSearchBox();
        }

        [When(@"I am on the search result page")]
        public void ThenIAmOnTheSearchResultPage()
        {
            //I verify that I am on the result page checking if the resultStats contains an expected text
            _googlePage.assertResultStatIsDisplayed();
        }

        [Then(@"I would like to take screenshot '(.*)'")]
        public void ThenITakeScreenShot(string country)
        {
            //I take screenshot to verify the results
            _googlePage.takeScreenShot(country);
        }
    }
}
