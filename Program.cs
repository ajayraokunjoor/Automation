using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
namespace Automation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\n");
            System.Console.WriteLine("Ajay Rao Kunjoor\n");

            /*ChromeBinary binary = new ChromeBinary();
            options.BrowserExecutableLocation = @"/Users/ajayraokunjoor/Code/Python/Drivers/chromeDriver/chromedriver";*/

            IWebDriver driver = new ChromeDriver("/Users/ajayraokunjoor/Code/Python/Drivers/chromeDriver/");
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.FindElement(By.Name("q")).SendKeys("Ajay Rao Kunjoor"+ Keys.Return);
            Thread.Sleep(2000);
            driver.Quit();
        }
    }
}
