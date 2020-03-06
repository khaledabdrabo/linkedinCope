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
    public class AwardManager : DbManager<Award>
    {
        public AwardManager(DbContext ctx) : base(ctx)
        {
        }
        public List<Award> GetAllBindByUserID(string id)
        {

            List<Award> Awards = this.Set.Where(e => e.UserId == id).ToList();
            return Awards;
        }
    }
}
