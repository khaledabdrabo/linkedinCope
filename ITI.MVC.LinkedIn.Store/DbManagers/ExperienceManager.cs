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
        public int MyProperty { get; set; }
        public ExperienceManager(DbContext ctx) : base(ctx)
        {

            public Work GetByeperienceId(int id) { 
            return Set.WorkExperiences.Where(w => w.ExperienceId == id).Include(w => w.Organization).Include(w => w.Experience).FirstOrDefault();
        }
    }
}
