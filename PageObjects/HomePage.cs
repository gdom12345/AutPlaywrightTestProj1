using AutPlaywrightTestProj.Framework;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutPlaywrightTestProj.PageObjects
{
    public class HomePage
    {
        [LocatorProperties(LocatorType = LocatorType.Text, Using = "Login")]
        public ILocator LoginButton;


        private IPage Page;
        public HomePage(IPage page) 
        { 
            this.Page = page; 
            ReflectionUtils.InitLocators(this, page);
        } 
    }
}
