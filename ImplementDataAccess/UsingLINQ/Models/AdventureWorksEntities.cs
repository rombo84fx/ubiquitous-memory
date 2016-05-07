using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingLINQ.Models
{
    public partial class AdventureWorksEntities 
    {
        public AdventureWorksEntities(string password)
            : base("name=AdventureWorksEntities")
        {
            this.Database.Connection.ConnectionString += $";Password={password}";
        }
    }
}
