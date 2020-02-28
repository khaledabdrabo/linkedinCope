using ITI.MVC.LinkedIn.DbLayer.Entities;
using ITI.MVC.LinkedIn;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.MVC.LinkedIn.DbManager;

namespace ITI.MVC.LinkedIn.Store.DbManagers
{
    public class ConnectionManager : DbManager<Connection>
    {
        public ConnectionManager(DbContext ctx) : base(ctx)
        {
        }
    }
}
