using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Sheets
{
    public partial class SheetLibrary
    {
        public class SheetTabsEntities : IDisposable
        {
            private int _id;
            private string _name;
            private List<string> _columns;

            public SheetTabsEntities()
            {
                this._columns = new List<string>();
            }
            public SheetTabsEntities(int id, string name) : this()
            {
                _id = id;
                _name = name;
            }
            public SheetTabsEntities(int id, string name, List<string> columns) : this()
            {
                _id = id;
                _name = name;
                _columns = columns;
            }

            public int Id { get => _id; set => _id = value; }
            public string Name { get => _name; set => _name = value; }
            public List<string> Columns { get => _columns; set => _columns = value; }

            public void Dispose() => GC.SuppressFinalize(this);
            public override bool Equals(object obj)
            {
                return obj is SheetTabsEntities entities &&
                       _name == entities._name;
            }
            public override int GetHashCode()
            {
                return 1969571243 + _id.GetHashCode();
            }
        }
    }
}
