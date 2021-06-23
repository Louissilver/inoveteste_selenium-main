using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace InoveTeste.PageObject
{
    class SeatSelectionPageObject
    {
        [FindsBy(How = How.Id, Using = "next-button")]
        public IWebElement NextButton { get; set; }
        
        [FindsBy(How = How.Id, Using = "select-seat")]
        public IWebElement SelectSeat { get; set; }
    }
}
