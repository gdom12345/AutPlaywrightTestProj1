using AutPlaywrightTestProj.Framework;
using Microsoft.Playwright;

namespace AutPlaywrightTestProj.PageObjects
{
    
    public class BasePage
    {
        private IPage Page;

        [LocatorProperties(LocatorType = LocatorType.Text, Using = "Employee List")]
        public ILocator EmployeeListTab;

        [LocatorProperties(LocatorType = LocatorType.Text, Using = "Employee Details")]
        public ILocator EmployeeDetailsTab;



        public BasePage(IPage page) 
        { 
            this.Page = page; 
            ReflectionUtils.InitLocators(this, page);
        } 
    }
}
