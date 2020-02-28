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
    public class EducationManager : DbManager<Education>
    {
        ApplicationDbContext db;
        public EducationManager(ApplicationDbContext ctx) : base(ctx)
        {
            db = ctx;
        }

        public Education getEducationData(int id)
        {
            return db.EducationExperiences.Include(e => e.Experience).Where(e => e.ExperienceId == id).FirstOrDefault();
        }

        public Education GetSpecificRecord(int id)
        {
           return db.EducationExperiences.Where(w => w.ExperienceId == id).FirstOrDefault();
        }
        public List<Education> GetAllBindByUserID(string id)
        {

            List<Education> Educationexperiences = this.Set.Where(e => e.UserId == id).Include(e => e.Experience).ToList();
            return Educationexperiences;
        }
    }
}
