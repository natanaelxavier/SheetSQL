using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Users.UsersLibrary;

namespace SheetSQL.Entities
{
    /// <summary>
    /// Global System Internal Class
    /// </summary>
    internal class Global
    {
        /// <summary>
        /// Active System User
        /// </summary>
        public UsersEntities User {get;set;}
    }
}
