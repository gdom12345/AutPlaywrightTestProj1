using AutPlaywrightTestProj.PageObjects;
using Microsoft.Playwright;
using NUnit.Framework.Legacy;


namespace AutPlaywrightTestProj.OLD
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests
    {
 

        [Test]
        public async Task Test1()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = false });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("http://www.eaapp.somee.com");
            await page.ClickAsync("text=Login");
            await page.ScreenshotAsync(new PageScreenshotOptions() { Path = "something.jpg" });

            await page.FillAsync("#UserName", "admin");
            await page.FillAsync("#Password", "password");
            await page.ClickAsync("text='Log in'");
            var doesExist = page.Locator("xpath=//*[contains(text(),'Employee Details')]").IsVisibleAsync();
            ClassicAssert.IsTrue(doesExist.Result);
        }
    }
}
