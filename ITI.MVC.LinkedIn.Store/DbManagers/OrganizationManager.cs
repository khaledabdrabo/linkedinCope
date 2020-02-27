using ITI.MVC.LinkedIn.DbLayer;
using ITI.MVC.LinkedIn.DbLayer.Entities;
using ITI.MVC.LinkedIn.DbManager;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.Store.DbManagers
{
    public class OrganizationManager : DbManager<Organization>
    {
        ApplicationDbContext dbc;
        public OrganizationManager(ApplicationDbContext ctx) : base(ctx)
        {
            dbc = ctx;
        }

        public Organization checkIfExist(string organization_name)
        {
            return dbc.Organizations.Where(o => o.Name == organization_name).FirstOrDefault();
        }
    }
}
