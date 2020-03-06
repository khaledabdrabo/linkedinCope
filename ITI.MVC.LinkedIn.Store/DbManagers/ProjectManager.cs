using ITI.MVC.LinkedIn.DbLayer.Entities;
using ITI.MVC.LinkedIn.DbManager;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.Store.DbManagers
{
    public class ProjectManager : DbManager<Project>
    {
        DbContext context;
        public ProjectManager(DbContext ctx) : base(ctx)
        {
            context = ctx;
        }

        public List<Project> GetAllBindByUserID(string id)
        {

            List<Project> Projects = this.Set.Where(e => e.UserId == id).ToList();
            return Projects;
        }

        public bool UpdateProject(Project entity)
        {
            //Set.Attach(entity);
            //ctx.Entry(entity).State = EntityState.Modified;

            using (var sqlLogFile = new StreamWriter("D:\\log.txt"))
            {
                Ctx.Database.Log = sqlLogFile.Write; 
                Set.AddOrUpdate(e => e.Id, entity);
                return Ctx.SaveChanges() > 0;
            }
        }
    }
}
