using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutPlaywrightTestProj.Framework
{
    public class TableParser
    {
        private IPage page;

        public TableParser(IPage page)
        {
            this.page = page;
        }

        public async Task<List<Dictionary<string, object>>> ParseTableAsync(ILocator cellsLocator, ILocator headersLocator)
        {
            var headerLookups = await headersLocator.AllAsync();
            List<string> headers = new List<string>();
            foreach (var header in headerLookups)
            {
                headers.Add(await header.InnerTextAsync());
            }

            return await ParseTableAsync(cellsLocator, headers.ToArray());
        }

        public async Task<List<Dictionary<string, object>>> ParseTableAsync(ILocator cellsLookup, string[] headers)
        {
            var cellsLocator = await cellsLookup.AllAsync();
            return await ParseTableAsync(cellsLocator, headers);

        }

        public async Task<List<Dictionary<string, object>>> ParseTableAsync(
            IReadOnlyList<ILocator> tableCells, string[] headers)
        {
            List<string> cells = new List<string>();
            foreach (var cell in tableCells)
            {
                cells.Add(await cell.InnerTextAsync());
            }


            List<Dictionary<string, object>> table = new List<Dictionary<string, object>>();
            for (int i = 0; i < cells.Count;)
            {
                Dictionary<string, object> tableRow = null;
                for (int j = 0; j < headers.Length; j++, i++)
                {
                    if (j == 0)
                    {
                        tableRow = new Dictionary<string, object>();
                        table.Add(tableRow);
                    }
                    tableRow.Add(headers[j], cells[i]);
                }
            }

            return table;
        }

    }
}
