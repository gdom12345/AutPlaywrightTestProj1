
using AutPlaywrightTestProj.PageObjects;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework.Legacy;

namespace AutPlaywrightTestProj
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests2 : PageTest
    
    {
        [SetUp]
        public async Task Setup()
        {
            await Page.GotoAsync("http://www.eaapp.somee.com"
                , new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded});
            Page.SetDefaultTimeout(2000);
        }
        //to use click and record feature
        //run powershell as admin
        //cd C:\Users\domGi\source\repos\AutPlaywrightTestProj\AutPlaywrightTestProj\bin\Debug\net10.0
        //Set-ExecutionPolicy -ExecutionPolicy RemoteSigned
        //./playwright.ps1 codegen http://eaapp.somee.com


        [Test]
        public async Task Test1()
        {

            var homePage = new HomePage(Page);
            await homePage.LoginButton.ClickAsync();

            var loginPage = new LoginPage(Page);
            await loginPage.Login("admin", "password");

            await Expect(homePage.EmployeeDetailsTab).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions { Timeout = 10000 });

            await homePage.EmployeeListTab.ClickAsync();
            var employeeListPage = new EmployeeListPage(Page);
            var tableData = employeeListPage.EmployeeList;
            ClassicAssert.IsTrue(tableData.Count() > 0);
            //can add more assertions, just completed parsing for this portion
        }
    }
}
