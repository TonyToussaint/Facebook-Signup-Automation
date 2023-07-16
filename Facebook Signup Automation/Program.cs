using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Facebook_Signup_Automation
{
    class Program
    {
        // Create a reference for Chrome Browser
        IWebDriver driver = new ChromeDriver();
        static void Main(string[] args)
        {
            
        }

        [SetUp]
        public void Initialize()
        {
            // Go to Facebook page 
            driver.Navigate().GoToUrl("https://www.facebook.com/");
        }

        [Test]
        public void ExecuteTest()
        {
            // Make browser full screen 
            driver.Manage().Window.Maximize();

            // Find the sign up button and then click it - Had to use Xpath because the ID is dynamic
            IWebElement signUpButton = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[1]/div/div/div/div[2]/div/div[1]/form/div[5]/a"));
            // Click the sign in button 
            signUpButton.Click();
            
            // Forcing a sleep here so the page can load the elements needed for the below portions
            Thread.Sleep(2000);

            // Find First name field 
            IWebElement firstName = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div[2]/div/div/div[1]/form/div[1]/div[1]/div[1]/div[1]/div/input"));
            // Send first name keys to field 
            firstName.SendKeys("Tony");

            // Find last name field 
            IWebElement lastName = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div[2]/div/div/div[1]/form/div[1]/div[1]/div[1]/div[2]/div/div[1]/input"));
            // Send last name keys to field 
            lastName.SendKeys("Bologna");

            // Find Email name field 
            IWebElement emailName = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div[2]/div/div/div[1]/form/div[1]/div[2]/div/div[1]/input"));
            // Send email name keys to field 
            emailName.SendKeys("asada@gmox.co");

            // Find Re-enter email name
            IWebElement emailName2 = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div[2]/div/div/div[1]/form/div[1]/div[3]/div/div/div[1]/input"));
            // Send email name keys to field 
            emailName2.SendKeys("asada@gmox.co");

            // Find Pass field 
            IWebElement passwordField = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div[2]/div/div/div[1]/form/div[1]/div[4]/div/div[1]/input"));
            // Send password keys to field 
            passwordField.SendKeys("testertester123");

            // Find month field 
            IWebElement birthMonth = driver.FindElement(By.Id("month"));
            // Create variable using select element to help us select from the dropdown list
            var selectElementMonth = new SelectElement(birthMonth);
            // For this test we are selecting a value which corresponds to a month. (4 = april) 
            selectElementMonth.SelectByValue("4");

            // Find day field 
            IWebElement birthDay = driver.FindElement(By.Id("day"));
            // Create variable using select element to help us select from the dropdown list
            var selectElementDay = new SelectElement(birthDay);
            // For this test we are selecting a value that corresponds to a day 
            selectElementDay.SelectByValue("30");

            // Find year field 
            IWebElement birthYear = driver.FindElement(By.Id("year"));
            // Create variable using select element to help us select from the dropdown list
            var selectElementYear = new SelectElement(birthYear);
            // For this test we are selecting a value that corresponds to a birth year
            selectElementYear.SelectByValue("1998");

            // Select Male Gender button 
            IWebElement gender = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div[2]/div/div/div[1]/form/div[1]/div[7]/span/span[2]/input"));
            // Click gender button
            gender.Click();

            // Find Sign up button again
            IWebElement signUpFinal = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div[2]/div/div/div[1]/form/div[1]/div[11]/button"));
            // CLick sign up button again 
            signUpFinal.Click();

            // Forcing a sleep here so the page can load the elements needed for the below portions
            Thread.Sleep(3000);

            // Error message assert - to test if its working
            IWebElement errorMessage = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div"));
            // Forcing a sleep here so the page can load the elements needed for the below portions
            Thread.Sleep(2000);
            // Compare text 
            Assert.That(errorMessage.Text.Contains("It looks like you may have entered an incorrect email address. Please correct it if necessary, then click to continue."));


        }

        [TearDown]
        public void CloseTest()
        {
            // Close the browser
            driver.Quit();
        }

    }
}
