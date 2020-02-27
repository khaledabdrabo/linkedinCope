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
    public class SharedPostManager : DbManager<SharedPost>
    {
        ApplicationDbContext ctx;

        public SharedPostManager(DbContext ctx) : base(ctx)
        {
            this.ctx = (ApplicationDbContext)ctx;
        }

        public List<SharedPost> GetByUserId(string userId)
        {
            return ctx.SharedPosts.Where(p => p.UserId == userId).ToList();
        }
    }
}
