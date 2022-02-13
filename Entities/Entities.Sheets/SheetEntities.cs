using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Sheets
{
    /// <summary>
    /// System Sheet Library
    /// </summary>
    public partial class SheetLibrary
    {
        public class SheetEntities : IDisposable
        {
            private int _id;
            private string _name;
            private string _directory;
            private List<string> _listColumns;
            private List<string> _listTabs;
            private bool disposedValue;

            public SheetEntities() 
            { 
                this.ListColumns = new List<string>();
                this._listTabs = new List<string>();
            }
            public SheetEntities(int id,string name, string directory):this()
            {
                _id = id;
                _name = name;
                _directory = directory;
            }

            public int Id { get => _id; set => _id = value; }
            public string Name { get => _name; set => _name = value; }
            public string Directory { get => _directory; set => _directory = value; }
            public List<string> ListTabs { get => _listTabs; set => _listTabs = value; }
            public List<string> ListColumns { get => _listColumns; set => _listColumns = value; }

            public override bool Equals(object obj)
            {
                return obj is SheetEntities entities &&
                       _directory == entities._directory;
            }
            public override int GetHashCode()
            {
                return 76087901 + EqualityComparer<string>.Default.GetHashCode(_directory);
            }
            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
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
