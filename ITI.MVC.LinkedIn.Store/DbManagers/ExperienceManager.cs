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
    { ApplicationDbContext db;
        public ExperienceManager(DbContext ctx) : base(ctx)
        {
            db = (ApplicationDbContext)ctx;
        }
            public Work GetByeperienceId(int id) {
            return db.WorkExperiences.Where(w => w.ExperienceId == id).Include(w => w.Organization).Include(w => w.Experience).FirstOrDefault();
        }
        public List<Experience> GetAllBindByUserID(string id)
        {

            List<Experience> experiences = this.Set.Where(e => e.UserId == id).Include(e => e.EducationExperience).Include(e => e.WorkExperience).ToList();
            return experiences;
        }
    }
}
