using AssessmentSpecsLounge.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AssessmentSpecsLounge.Test
{
    [TestFixture]
    public class SpecsLoungesTest
    {
        private IWebDriver driver;
        private LocatorsPage locatorsPage;
        
        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoUser:demoUser%4012345@specslounge-test.centralindia.cloudapp.azure.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3000));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString() == "complete");
            locatorsPage = new LocatorsPage(driver);
            locatorsPage.ClickOnAcceptAllButtonInThePopup();
        }
        [Test]
        // This Test Navigates till the delivery address page.
        public void VerifyCheckOutNowFlow()
        {
            locatorsPage.ClickOnShopNowButton();
            Assert.IsTrue(driver.Url.Contains("frame-catalogue"), "User is not navigated to frame catalogue page.");  
            locatorsPage.ClickOnTryMeButton();
            Assert.IsTrue(driver.Url.Contains("frame-detail"),"User is not navigated to frame-detail page.");
            locatorsPage.ClickOnSelectLensesButton();
            Thread.Sleep(5000);
            Assert.IsTrue(driver.Url.Contains("lens-selector"), "User is not check out page.");
            locatorsPage.ClickOnCheckoutNowButton();
            Thread.Sleep(5000);
            Assert.IsTrue(driver.Url.Contains("your-contact-details"), "User is not navigated to enter delivery address page.");
            this.FillDeliveryAddressDetails("Rukmini", "Prakash", "rukmini1310@gmail.com", "9663656435","560001", "Ban", "Ecity");
        }

        public void FillDeliveryAddressDetails(string firstName, string lastName, string email, string phoneNumber, string postalCode, string address, string streetName)
        {
            
            locatorsPage.firstNameField.SendKeys(firstName);
            locatorsPage.lastNameField.SendKeys(lastName);
            locatorsPage.emailNameField.SendKeys(email);
            locatorsPage.phoneField.SendKeys(phoneNumber);
            // this.EnterPostalCodeAndSelectFirst(postalCode);
            this.EnterAddressAndSelectFirst(address);
            locatorsPage.streetField.SendKeys(streetName); 
        }

        public void EnterPostalCodeAndSelectFirst(string postalCode)
        {
            locatorsPage.postalCodeField.SendKeys(postalCode);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            By firstSuggestion = By.XPath("//ul/li[1]");

            IWebElement option = wait.Until(ExpectedConditions.ElementToBeClickable(firstSuggestion));
            option.Click();
        }

        public void EnterAddressAndSelectFirst(string address)
        {
            locatorsPage.addressField.SendKeys(address);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            By firstSuggestion = By.XPath("//ul/li[1]");

            IWebElement option = wait.Until(ExpectedConditions.ElementToBeClickable(firstSuggestion));
            option.Click();
        }


        [TearDown]
        public void CloseBrowser()
        {
            // This will close the browser after the test is completed.
            driver.Quit();
            driver.Dispose();
        }


    }
}
