using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Sheets
{
    public partial class SheetLibrary
    {
        /// <summary>
        /// Spreadsheet List
        /// </summary>
        /// <typeparam name="SheetEntities">Sheet</typeparam>
        public class SheetListEntities : IDisposable
        {
            ICollection<SheetEntities> _items;
            private bool disposedValue;

            public SheetListEntities() => _items = new List<SheetEntities>();
            public int Count => _items.Count;
            
            /// <summary>
            /// Add a Worksheet to the list.
            /// </summary>
            /// <param name="item">The Sheet</param>
            /// <exception cref="ArgumentNullException"></exception>
            public void Add(SheetEntities item)
            {
                if (item == null) throw new ArgumentNullException("Item not found");
                if(!Find(item)) _items.Add(item);
            }
            /// <summary>
            /// Remove a Worksheet to the List
            /// </summary>
            /// <param name="item">The Shhet</param>
            /// <exception cref="ArgumentNullException"></exception>
            public void Remove(SheetEntities item)
            {
                if (item == null) throw new ArgumentNullException("item not found");
                _items.Remove(this._items.First(t => t.Equals(item)));
            }
            
            /// <summary>
            /// Find worksheet
            /// </summary>
            /// <param name="item">The Shhet</param>
            /// <returns>Returns true or false if found.</returns>
            public bool Find(SheetEntities item)
            {
                return _items.Contains(item);
            }
            public SheetEntities Find(int Id)
            {
                SheetEntities item = null;
                foreach (SheetEntities it in _items)
                {
                    if(it.Id == Id) { item = it; break; }
                };
                return item;
            }
            public SheetEntities Find(string directory)
            {
                SheetEntities item = null;
                foreach (SheetEntities it in _items)
                {
                    if (it.Name == directory) { item = it; break; }
                };
                return item;
            }

            public List<SheetEntities> GetList() => _items.ToList();

            public void Clear()
            {
                _items.Clear();
            }
            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        this._items.Clear();
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
