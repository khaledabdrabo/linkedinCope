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
        public EducationManager(DbContext ctx) : base(ctx)
        {
        }
        public List<Education> GetAllBindByUserID(string id)
        {

            List<Education> Educationexperiences = this.Set.Where(e => e.UserId == id).Include(e => e.Experience).ToList();
            return Educationexperiences;
        }
    }
}
