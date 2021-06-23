using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using InoveTeste.PageObject;
using InoveTeste.Comandos;

namespace CasosDeTeste
{
    [TestFixture]
    public class SelectSeatTest
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;

        [SetUp]
        public void SetUp()
        {
            driver = Comandos.Navegador(driver, ConfigurationManager.AppSettings["navegador"]);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void EnviarMensagemTeste()
        {
            SeatSelectionPageObject seatSelection = new SeatSelectionPageObject();
            PageFactory.InitElements(driver, seatSelection);
            Thread.Sleep(1000);
            SelectSeat("18", "B");
            Thread.Sleep(1000);
            seatSelection.SelectSeat.Click();
            Thread.Sleep(1000);
            seatSelection.NextButton.Click();
            Thread.Sleep(1000);
            seatSelection.NextButton.Click();
            Thread.Sleep(3000);


            List<string> expectedSeatSelection = new List<string>();
            expectedSeatSelection.Add("P1 Seat: 18B, CQ 777");

            var encounteredSeatSelection = ReturnSeatSelection();

            Assert.AreEqual(expectedSeatSelection, encounteredSeatSelection);
        }

        #region Helpers
        public List<string> ReturnSeatSelection()
        {
            List<string> SeatSelection = new List<string>();
            var elements = driver.FindElements(By.XPath("//div[@id='trigger']/section[2]//p"));
            foreach (var element in elements)
            {
                SeatSelection.Add(element.Text);
            }
            return SeatSelection;
        }

        public void SelectSeat(string line, string letter)
        {
            string seat = string.Empty;
            string div = string.Empty;
            switch (letter)
            {
                case "A":
                    {
                        div = "1";
                        seat = "1";
                        break;
                    }
                case "B":
                    {
                        div = "1";
                        seat = "2";
                        break;
                    }
                case "C":
                    {
                        div = "1";
                        seat = "3";
                        break;
                    }
                case "D":
                    {
                        div = "2";
                        seat = "1";
                        break;
                    }
                case "E":
                    {
                        div = "2";
                        seat = "2";
                        break;
                    }
                case "F":
                    {
                        div = "2";
                        seat = "3";
                        break;
                    }
                case "G":
                    {
                        div = "2";
                        seat = "4";
                        break;
                    }
                case "H":
                    {
                        div = "3";
                        seat = "1";
                        break;
                    }
                case "J":
                    {
                        div = "3";
                        seat = "2";
                        break;
                    }
                case "K":
                    {
                        div = "3";
                        seat = "3";
                        break;
                    }
            }
            driver.FindElement(By.XPath($"//div[contains(@class, 'row-{line}')]/div[contains(@class,'row-group')][{div}]/button[{seat}]")).Click();
        }
        #endregion
    }
}
