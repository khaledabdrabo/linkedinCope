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
    public class CourseManager : DbManager<Course>
    {
        public CourseManager(DbContext ctx) : base(ctx)
        {
        }

        public List<Course> GetAllBindByUserID(string id)
        {

            List<Course> Courses = this.Set.Where(e => e.UserId == id).ToList();
            return Courses;
        }
    }
}
