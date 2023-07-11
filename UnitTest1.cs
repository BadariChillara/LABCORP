using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.DevTools.V112.Overlay;
using OpenQA.Selenium.Interactions;
using Assert = NUnit.Framework.Assert;

namespace SeleniumTestOne
{
    [TestClass]
    public class Progam
    {
        [TestMethod]
        static void Main(string[] args)
        {

            // Create a new ChromeDriver instance.
            IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();

            // Navigate to the LabCorp website.
            driver.Navigate().GoToUrl("https://www.labcorp.com");

            // Wait for the page to load.
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            
            //Find the Element
            IWebElement logo = driver.FindElement(By.XPath("//a[@class='logo hide-for-print']"));

        

            // Find the Careers link.
            IWebElement careersLink = driver.FindElement(By.XPath("//a[@href='https://careers.labcorp.com/global/en']"));

            // Click the Careers link.
            careersLink.Click();

            // Wait for the page to load.
            Thread.Sleep(2000);
           

            //Find the Element
            IWebElement welcomeback = driver.FindElement(By.XPath("//span[text()='Get tailored job recommendations based on your interests.']"));

            if (welcomeback != null)
            {
                Console.WriteLine("welcomeback  is present.");
            }
            else
            {
                Console.WriteLine("welcomeback  is not present.");
            }


            // Find the search input field.
            IWebElement searchInput = driver.FindElement(By.XPath("//input[contains(@class, 'ph-a11y-search-box') and @id='typehead' and @name='typehead' and @placeholder='Search job title or location']"));

            // Enter the search term.
            searchInput.SendKeys("QA Test Automation Developer");
            Thread.Sleep(5000);

            // Click the search button.
            IWebElement searchButton = driver.FindElement(By.XPath("//[@class='icon icon-search-icon']"));
            searchButton.Click();
            //Actions searchbutton = new Actions(driver);
            // searchbutton.SendKeys(Keys.Enter);
            //searchButton.SendKeys(Keys.Enter);

            // Wait for the search results page to load.
            Thread.Sleep(5000);

            //Search for QA Test Automation Developer on web page
            
            IWebElement Test = driver.FindElement(By.XPath("//span[contains(text(),'QA Test Automation Developer')]"));

            Assert.IsNull(Test, "The Element with Text QA Test Automation Developer is not found on the search results page");

            Console.WriteLine("QA Test Automation Developer is not present in the search page");

            if (Test != null)
            {
                Console.WriteLine("QA Test Automation Developer  is present.");
            }
            else
            {
                Console.WriteLine("QA Test Automation Developer  is not present.");
            }

            //Call the highlighterMethod and pass webdriver and WebElement which you want to highlight as arguments.
            //HighlightElementInAction(element, driver);
            Thread.Sleep(2000);
            driver.Quit();


        }


        private IWebElement HighlightElementInAction(IWebElement element, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px dotted blue'", element);
            return element;
        }




    }
    
}
