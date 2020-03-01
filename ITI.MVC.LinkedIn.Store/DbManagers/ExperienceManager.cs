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
        }
        public List<Experience> GetAllBindByUserID(string id)
        {
            List<Experience> experiences = this.Set.Where(e => e.UserId == id).Include(e => e.EducationExperience).Include(e => e.WorkExperience).ToList();
            return experiences;
        }
    }
}
