using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Entities.Sheets.SheetLibrary;

namespace Methods.Sheet
{
    public partial class SheetLibrary
    {
        public class SheetMethods : IDisposable
        {
            static SheetListEntities _list;
            private bool disposedValue;
            /// <summary>
            /// Creates a class to manage the list of Sheets.
            /// </summary>
            /// <param name="sheetList">Your spreadsheet list</param>
            public SheetMethods(ref SheetListEntities sheetList)
            {
                _list = sheetList;
            }
            /// <summary>
            /// Add new sheet to application sheet list.
            /// </summary>
            /// <param name="filename">File Directory</param>
            /// <returns>Returns true if added.</returns>
            public bool IncludeSpreadsheet(string filename)
            {
                try
                {
                    SheetEntities sheetEntities = new SheetEntities();
                    sheetEntities.Id = _list.Count + 1;
                    sheetEntities.Name = Path.GetFileNameWithoutExtension(filename);
                    sheetEntities.Directory = filename;
                    _list.Add(sheetEntities);
                    return _list.Find(sheetEntities);
                }
                catch (Exception err)
                {
                    throw err;
                }
            }
            /// <summary>
            /// Load the TreeView component with the Sheets list.
            /// </summary>
            /// <returns></returns>
            public void LoadTreeView(ref TreeView component)
            {
                try
                {
                    component.Nodes.Clear();
                    foreach (SheetEntities sheetentitie in _list.GetList())
                    {
                        sheetentitie.ListTabs.Clear();
                        TreeNode sheetsNames = component.Nodes.Add(sheetentitie.Id.ToString(), sheetentitie.Name, 1);
                        var xls = new XLWorkbook(sheetentitie.Directory);
                        foreach (IXLWorksheet sheet in xls.Worksheets)
                        {
                            sheetsNames.Nodes.Add(sheetentitie.Id.ToString(), sheet.Name);
                            if (!sheetentitie.ListTabs.Exists(t => t.Name == sheet.Name))
                                sheetentitie.ListTabs.Add(new SheetTabsEntities(sheet.Position, sheet.Name));
                        }
                        xls.Dispose();
                    }
                }
                catch (Exception err)
                {
                    throw err;
                }
            }
            /// <summary>
            /// According to the choice in the tree, it returns a datatable.
            /// </summary>
            /// <param name="sheetCode">Spreadsheet code.</param>
            /// <param name="nameSheet">Worksheet table name.</param>
            /// <returns>Returns a datatable object.</returns>
            public DataTable LoadSheet(int sheetCode, string nameSheet)
            {
                try
                {
                    SheetEntities sheetEntities = _list.Find(sheetCode);
                    DataTable table = new DataTable();
                    var xls = new XLWorkbook(sheetEntities.Directory);
                    IXLWorksheet xLWorksheet = null;
                    foreach (IXLWorksheet xlsheet in xls.Worksheets)
                    {
                        if (xlsheet.Name == nameSheet)
                            xLWorksheet = xlsheet;
                    }

                    IXLRow row = xLWorksheet.FirstRow();
                    foreach (IXLCell cell in row.Cells())
                    {
                        if (!string.IsNullOrEmpty(cell.Value.ToString()))
                            table.Columns.Add(new DataColumn(cell.Value.ToString(), typeof(string)));

                        if (sheetEntities.ListTabs.Exists(t => t.Name.Equals(xLWorksheet.Name)))
                        {
                            SheetTabsEntities ste = sheetEntities.ListTabs.Find(t => t.Name.Equals(xLWorksheet.Name));
                            if (!ste.Columns.Exists(t => t == cell.Value.ToString()))
                            {
                                ste.Columns.Add(cell.Value.ToString().Trim());
                            }
                        }
                    }

                    for (int i = 2; i < xLWorksheet.Rows().Count(); i++)
                    {
                        IXLRow rw = xLWorksheet.Row(i);
                        DataRow trow = table.NewRow();
                        foreach (IXLCell cell in rw.Cells())
                            trow[cell.Address.ColumnNumber - 1] = cell.Value.ToString();
                        table.Rows.Add(trow);
                    }

                    return table;

                }
                catch (Exception err)
                {
                    throw err;
                }
            }
            /// <summary>
            /// Load table columns
            /// </summary>
            /// <param name="table">The table</param>
            /// <returns>Returns the list of table columns</returns>
            public List<string> LoadColumns(DataTable table)
            {
                try
                {
                    List<string> lst = new List<string>();
                    foreach (DataColumn col in table.Columns)
                        lst.Add(col.ColumnName);
                    return lst;
                }
                catch (Exception err)
                {
                    throw err;
                }
            }
            /// <summary>
            /// Load table columns
            /// </summary>
            /// <param name="sheetCode">Spreadsheet code.</param>
            /// <param name="nameSheet">Worksheet table name.</param>
            /// <returns>Returns the list of table columns</returns>
            public List<string> LoadColumns(int sheetCode, string nameSheet)
            {
                try
                {
                    return LoadColumns(LoadSheet(sheetCode, nameSheet));
                }
                catch (Exception err)
                {
                    throw err;
                }
            }
            /// <summary>
            /// Load names Tables
            /// </summary>
            /// <param name="sheetCode">Code a Sheet</param>
            /// <returns>Returns the list of names the seets</returns>
            public IEnumerable<string> LoadTabs(int sheetCode)
            {
                SheetEntities sheetentitie = _list.Find(sheetCode);
                foreach (SheetTabsEntities ste in sheetentitie.ListTabs)
                    yield return ste.Name;
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: dispose managed state (managed objects)
                    }

                    disposedValue = true;
                }
            }
            public void Dispose()
            {
                Dispose(disposing: true);
                GC.SuppressFinalize(this);
            }
        }
    }
}
