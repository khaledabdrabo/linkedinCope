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
    public class ExperienceManager : DbManager<Experience>
    {
        ApplicationDbContext dbc;
        public ExperienceManager(ApplicationDbContext ctx) : base(ctx)
        {
            this.dbc = ctx;
        }

        public Work GetByeperienceId(int id)
        {
            return dbc.WorkExperiences.Where(w => w.ExperienceId == id).Include(w => w.Organization).Include(w => w.Experience).FirstOrDefault();
        }
    }
}
