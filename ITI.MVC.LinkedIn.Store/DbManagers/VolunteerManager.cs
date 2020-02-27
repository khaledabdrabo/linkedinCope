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
    public class VolunteerManager : DbManager<Volunteer>
    {
        ApplicationDbContext db;
        public VolunteerManager(ApplicationDbContext ctx) : base(ctx)
        {
            db = ctx;
        }

        public Volunteer  GetSpecificRecord(int id)
        {
            return db.VolunteerExperiences.Where(w => w.ExperienceId == id).FirstOrDefault();
        }
    }
}
