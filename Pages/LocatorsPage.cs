using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V136.DOM;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AssessmentSpecsLounge.Pages
{
    public class LocatorsPage
    {

        private readonly IWebDriver driver;

        public LocatorsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Locators
        // Shop now button in landing page.
        public IWebElement shopNowButton => driver.FindElement(By.XPath("//button[contains(@class,'button--primary')]"));

        // Accept all button in the cookies popup.
        public IWebElement acceptAllButton => driver.FindElement(By.Id("onetrust-accept-btn-handler"));

        // Order now button in frame-detail page.
        public IWebElement selectLensesButton => driver.FindElement(By.XPath("//app-button[@class='order-now-button']/ion-button"));

        // Checkout button in lens-selector page.
        public IWebElement checkoutNowButton => driver.FindElement(By.XPath("//ion-button[@data-name='cta_gotobaskets']"));

        // First Name field in the delivery address form.
        public IWebElement firstNameField => driver.FindElement(By.XPath("//div/input[@id='ion-input-0']"));

        // Last Name field in the delivery address form.
        public IWebElement lastNameField => driver.FindElement(By.XPath("//div/input[@id='ion-input-4']"));

        // Email field in the delivery address form.
        public IWebElement emailNameField => driver.FindElement(By.XPath("//div/input[@id='ion-input-1']"));

        // Phone Number field in the delivery address form.
        public IWebElement phoneField => driver.FindElement(By.XPath("//div/input[@id='ion-input-2']"));

        // Postal Code Number field in the delivery address form.
        public IWebElement postalCodeField => driver.FindElement(By.XPath("//div/input[@id='ion-input-5']"));

        
        // Address field in the delivery address form.
        public IWebElement addressField => driver.FindElement(By.XPath("//div/input[@id='ion-input-8']"));

        // street field in the delivery address form.
        public IWebElement streetField => driver.FindElement(By.XPath("//div/input[@id='ion-input-10']"));


        #endregion Locators

        #region Methods

        // This Method to click the shop now button
        public void ClickOnShopNowButton()
        {
            shopNowButton.Click();
        }

        // This Method is to click on accept all button in the popup.
        public void ClickOnAcceptAllButtonInThePopup()
        {
            acceptAllButton.Click();
        }

        // This Method is to click on Try me button.
        public void ClickOnTryMeButton()
        {
            // Click on the Try Me button for the nth specs.
            IWebElement tryMeButton = driver.FindElement(By.XPath("(//div[@data-name='img_viewproductdetail'])[12]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView({behavior:'smooth',block:'center'});", tryMeButton);
            tryMeButton.Click();
        }

        // This Method is to click on Order now button.
        public void ClickOnSelectLensesButton()
        {
            Thread.Sleep(5000);
            // Click on the Try Me button for the nth specs.
            ((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].scrollIntoView();",
                selectLensesButton);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3000));
            wait.Until(ExpectedConditions.ElementToBeClickable(selectLensesButton));
            selectLensesButton.Click();
        }

        // This Method is to click on checkout now button.
        public void ClickOnCheckoutNowButton()
        {
            Thread.Sleep(5000);
            ((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].scrollIntoView();",
                checkoutNowButton);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3000));
            wait.Until(ExpectedConditions.ElementToBeClickable(checkoutNowButton));
            checkoutNowButton.Click();
        }

        #endregion Methods
    }
}
    
