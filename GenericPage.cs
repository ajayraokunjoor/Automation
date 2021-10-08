using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;


namespace Automation
{
    public class GenericPage
    {
        public readonly IWebDriver Driver;
        public string PageUrl;

        public enum SelectorType
        {
            Id,
            Xpath
        }

        public enum ValidateType
        {
            Equal,
            NotEqual,
            Contains,
            URL
        }

        public GenericPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public void NavigateTo(string PageUrl)
        {
            this.PageUrl = PageUrl;
            Driver.Navigate().GoToUrl(PageUrl);
        }

        public void ClearText(SelectorType type, string method, string value)
        {
            switch (type)
            {
                case SelectorType.Id:
                    Driver.FindElement(By.Id(method)).Clear();
                    break;
                case SelectorType.Xpath:
                    Driver.FindElement(By.XPath(method)).Clear();
                    break;
                default:
                    break;
            }
        }
        public void EnterText(SelectorType type, string method, string value)
        {
            switch (type)
            {
                case SelectorType.Id:
                    Driver.FindElement(By.Id(method)).SendKeys(value);
                    break;
                case SelectorType.Xpath:
                    Driver.FindElement(By.XPath(method)).SendKeys(value);
                    break;
                default:
                    break;
            }
        }

        public void FindElementByClick(SelectorType type, string method, string value)
        {
            switch (type)
            {
                case SelectorType.Id:
                    Driver.FindElement(By.Id(value)).Click();
                    break;
                case SelectorType.Xpath:
                    Driver.FindElement(By.XPath(value)).Click();
                    break;
                default:
                break;
            }
        }

        public void SelectValueFromDropdown(SelectorType type, string method, string value)
        {
            IWebElement dropDownElement = Driver.FindElement(By.Id(method));
            SelectElement selectElement = new SelectElement(dropDownElement);
            selectElement.SelectByText(value);
        }
        
        public void SwitchWindow(SelectorType type, string method, string value)
        {
            ReadOnlyCollection<string> allTabs = Driver.WindowHandles;
            for (int i = 0; i < allTabs.Count; i++)
            {
                if (i == Int32.Parse(value))
                {
                    Driver.SwitchTo().Window(allTabs[i]);
                }
            }
        }

        public void ScrollToElement(SelectorType type, string method, string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            IWebElement Element = Driver.FindElement(By.XPath(method));
            js.ExecuteScript("arguments[0].scrollIntoView();", Element);
        }

        public void WaitForDemo(int secondsToPause = 5)
        {
            Thread.Sleep(secondsToPause * 1000);
        }

        public void WaitFor(SelectorType xpath, string method)
        {
            int time_in_seconds = 3;
            time_in_seconds = Int16.Parse(method);
            try
            {
                 Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time_in_seconds);
            }
            catch (ElementNotVisibleException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void WaitUntil(ValidateType type, string method, string value)
        {
            switch (type)
            {
                case ValidateType.Equal:
                    if (method.Contains("//"))
                    {
                        String.Equals(method, Driver.FindElement(By.XPath(value)).Text);
                        break;
                    }
                    else
                    {
                        String.Equals(method, Driver.FindElement(By.Id(value)).Text);
                        break;
                    }
                case ValidateType.NotEqual:
                    if (method.Contains("//"))
                    {
                        String.Equals(method, Driver.FindElement(By.XPath(value)).Text);
                        break;
                    }
                    else
                    {
                        String.Equals(method, Driver.FindElement(By.Id(value)).Text);
                        break;
                    }
                    case ValidateType.Contains:
                    if (method.Contains("//"))
                    {
                        String.Compare(method, Driver.FindElement(By.XPath(value)).Text);
                        break;
                    }
                    else
                    {
                        String.Compare(method, Driver.FindElement(By.Id(value)).Text);
                        break;
                    }
                    case ValidateType.URL:
                    if (method.Contains("https"))
                    {
                        String.Equals(method, Driver.Url);
                        break;
                    }
                    else
                    {
                        break;
                    }
                default:
                    break;
            }
        }
    }
}