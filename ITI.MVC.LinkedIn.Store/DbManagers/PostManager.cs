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
    public class PostManager : DbManager<Post>
    {
        ApplicationDbContext ctx;

        public PostManager(DbContext ctx) : base(ctx)
        {
            this.ctx = (ApplicationDbContext)ctx;
        }

        public List<Post> GetByUserId(string userId)
        {
            return ctx.Posts.Where(p => p.UserId == userId).ToList();
        }
    }
}
