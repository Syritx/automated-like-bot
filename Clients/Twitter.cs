using System;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace LIKE_BOT.Clients
{
    public class Twitter
    {
        FirefoxDriver driver;
        string username,password,search;

        public Twitter(string username, string password, string search)
        {
            driver = new FirefoxDriver();

            this.username = username;
            this.password = password;
            this.search = search;

            loadTwitter();
        }

        void loadTwitter()
        {
            driver.Url = "https://www.twitter.com/login";
            Thread.Sleep(3000);

            IWebElement usernameForm = driver.FindElement(By.Name("session[username_or_email]"));
            IWebElement passwordForm = driver.FindElement(By.Name("session[password]"));

            usernameForm.SendKeys(username);
            passwordForm.SendKeys(password);
            Thread.Sleep(1000);
            passwordForm.SendKeys(Keys.Enter);

            Thread.Sleep(3000);
            driver.Url = "https://twitter.com/search?q=" + search;

            // scrolling
            for (int i = 0; i < 5; i++)
            {
                IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
                executor.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
                Thread.Sleep(2000);
            }

            // liking tweets
            for (int heart = 0; heart < 100; heart++)
            {
                try {

                    IWebElement heartButton = driver.FindElement(
                        By.XPath("//*[@id='react-root']/div/div/div[2]/main/div/div/div/div/div/div[2]/div/div/section/div/div/div/div[" + (heart+1).ToString() + "]/div/div/article/div/div/div/div[2]/div[2]/div[2]/div[3]/div[3]/div/div"));

                    heartButton.Click();
                    Console.WriteLine("successfully liked the tweet");

                }catch (Exception e) {}
                Thread.Sleep(1000);
            }
        }
    }
}
