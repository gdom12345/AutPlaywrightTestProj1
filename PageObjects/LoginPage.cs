using AutPlaywrightTestProj.Framework;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutPlaywrightTestProj.PageObjects
{
    public class LoginPage
    {
        [LocatorProperties(LocatorType = LocatorType.Id, Using = "UserName")]
        private ILocator UserNameTextbox;

        [LocatorProperties(LocatorType = LocatorType.Id, Using = "Password")]
        private ILocator PasswordTextbox;

        [LocatorProperties(LocatorType = LocatorType.Text, Using = "Log in")]
        private ILocator LoginButton;

        public async Task Login(string username, string password)
        {
            await UserNameTextbox.FillAsync(username);
            await PasswordTextbox.FillAsync(password);
            await LoginButton.ClickAsync();
        }


        private IPage Page;
        public LoginPage(IPage page) 
        { 
            this.Page = page; 
            ReflectionUtils.InitLocators(this, page);
        } 
    }
}
