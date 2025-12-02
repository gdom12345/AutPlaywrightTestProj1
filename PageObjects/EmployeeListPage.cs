using AutPlaywrightTestProj.Framework;
using AutPlaywrightTestProj.Models;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutPlaywrightTestProj.PageObjects
{
    public class EmployeeListPage : BasePage
    {
        [LocatorProperties(LocatorType = LocatorType.Text, Using = "Login")]
        public ILocator LoginButton;

        //there wasn't a good identifier for table, I tied it to a preceding element
        [LocatorProperties(LocatorType = LocatorType.XPath, Using = "//table[./preceding-sibling::form[./a[@href='/Employee/Create']]]//tr[1]/th[text()]")]
        private ILocator EmployeeTableHeaders;

        [LocatorProperties(LocatorType = LocatorType.XPath, Using = "//table[./preceding-sibling::form[./a[@href='/Employee/Create']]]//tr[position() > 1]/td[not(position() = last())]")]
        private ILocator EmployeeTableCells;

        private IPage Page;

        public List<EmployeeListRow> EmployeeList
        {
            get
            {
                var initialDataScrape = new TableParser(Page).ParseTableAsync(EmployeeTableCells, EmployeeTableHeaders).Result;
                return ReflectionUtils.GetList<EmployeeListRow>(initialDataScrape);
            }
        }



        public EmployeeListPage(IPage page) : base(page)
        { 
        } 
    }
}
