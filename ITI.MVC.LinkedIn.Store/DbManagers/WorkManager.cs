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
    public class WorkManager : DbManager<Work>
    {
        public WorkManager(DbContext ctx) : base(ctx)
        {
        }

        public List<Work> GetAllBindByUserID(string id)
        {

            List<Work> Workexperiences = this.Set.Where(e => e.UserId == id).Include(e=> e.Experience).ToList();
            return Workexperiences;
        }
    }
}
