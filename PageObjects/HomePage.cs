using AutPlaywrightTestProj.Framework;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutPlaywrightTestProj.PageObjects
{
    //homne page has 2 states, one logged in, one logged off.  Different elements will appear, might split this up later
    public class HomePage : BasePage
    {
        [LocatorProperties(LocatorType = LocatorType.Text, Using = "Login")]
        public ILocator LoginButton;


        private IPage Page;
        public HomePage(IPage page) : base(page)
        { 
        } 
    }
}
