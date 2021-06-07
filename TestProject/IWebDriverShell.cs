using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TechTalk.SpecFlow;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace DemoWebShopAutomationHW
{
    public class IWebDriverShell : IWebDriver
    {
        IWebDriver driver;
        WebDriverWait wait;

        public string Url { get => driver.Url; set => driver.Url = value; }
        public string Title => driver.Title;
        public string PageSource => driver.PageSource;
        public string CurrentWindowHandle => driver.CurrentWindowHandle;
        public ReadOnlyCollection<string> WindowHandles => driver.WindowHandles;

        public IWebDriver CreateDriver()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            ScenarioContext.Current["driver"] = driver;
            return (IWebDriver)ScenarioContext.Current["driver"];
        }
        public IWebDriver GetDriver()
        {
            if (!ScenarioContext.Current.ContainsKey("driver"))
            {
                ScenarioContext.Current["driver"] = CreateDriver();
                return (IWebDriver)ScenarioContext.Current["driver"];
            }
            return (IWebDriver)ScenarioContext.Current["driver"];
        }
        public WebDriverWait CreateWaiter()
        {
            wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(30));
            return wait;
        }
        public WebDriverWait GetWaiter()
        {
            GetDriver();
            if (wait == null)
            {
                wait = CreateWaiter();
                return wait;
            }
            return wait;
        }
        public By WaitElementClickability(By by)
        {
            GetWaiter().Until(ExpectedConditions.ElementToBeClickable(by));
            return by;
        }
        public By WaitElementsClickability(By by)
        {
            foreach (var item in GetWaiter().Until(ExpectedConditions.ElementExists(by)).FindElements(by).ToList())
                WaitElementClickability((By)item);
            return by;
        }
        public By WaitElementVisibility(By by)
        {
            GetWaiter().Until(ExpectedConditions.ElementIsVisible(by));
            return by;
        }
        public By WaitElementsVisibility(By by)
        {
            foreach (var item in GetWaiter().Until(ExpectedConditions.ElementExists(by)).FindElements(by).ToList())
                WaitElementVisibility((By)item);
            return by;
        }

        public void Close() => GetDriver().Close();

        public void Dispose() => GetDriver().Dispose();

        public IWebElement FindElement(By by)
        {
            try
            {
                return GetDriver().FindElement(WaitElementClickability(by));
            }
            catch
            {
                return GetDriver().FindElement(WaitElementClickability(by));
            }
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            try
            {
                return GetDriver().FindElements(WaitElementsClickability(by));
            }
            catch
            {
                return GetDriver().FindElements(WaitElementsVisibility(by));
            }
        }

        public IOptions Manage() => GetDriver().Manage();

        public INavigation Navigate() => GetDriver().Navigate();

        public void Quit() => GetDriver().Quit();

        public ITargetLocator SwitchTo() => GetDriver().SwitchTo();
    }
}
