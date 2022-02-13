using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Users
{
    /// <summary>
    /// System Users Library.
    /// </summary>
    public partial class UsersLibrary
    {
        public class UsersEntities : IEquatable<UsersEntities>, IDisposable
        {
            private int _id;
            private string _name;
            private string _email;
            private string _username;
            private string _password;
            private string _phone;

            //Parameters Idisposable
            private bool _disposedValue;

            public UsersEntities() { }
            public UsersEntities(int id, string name, string username, string password):this()
            {
                _id = id;
                _name = name;
                _username = username;
                _password = password;
            }
            ~UsersEntities() => Dispose(false);

            public int Id { get => _id; set => _id = value; }
            public string Name { get => _name; set => _name = value; }
            public string Email { get => _email; set => _email = value; }
            public string Username { get => _username; set => _username = value; }
            public string Password { get => _password; set => _password = value; }
            public string Phone { get => _phone; set => _phone = value; }

            public override bool Equals(object obj)
            {
                return Equals(obj as UsersEntities);
            }
            public bool Equals(UsersEntities obj)
            {
                return obj != null &&
                       obj == this &&
                       obj.Id == this._id;
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
            public override string ToString()
            {
                return String.Format("[{0}] - {1}",this._username,this._name); 
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            protected virtual void Dispose(bool disposing)
            {
                if (!_disposedValue)
                {
                    if (disposing)
                    {

                    }

                    _disposedValue = true;
                }
            }

        }
    }
}
