using ITI.MVC.LinkedIn.DbLayer;
using ITI.MVC.LinkedIn.DbManager;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbManager
{
    public class DbManager<TEntity> : IDbManager<TEntity> where TEntity : class
       
    {
        DbContext ctx;
        DbSet<TEntity> set;

        public DbManager(DbContext ctx)
        {
            this.ctx = ctx;
            set = ctx.Set<TEntity>();
        }

        public DbSet<TEntity> Set { get {return set; } }
        public DbContext Ctx { get { return this.ctx; } }

        public TEntity Add(TEntity entity)
        {
            TEntity e = Set.Add(entity);

            return ctx.SaveChanges() > 0 ? e : null;
        }

        public IQueryable<TEntity> GetAll()
        {
            return Set;
        }

        public IEnumerable<TEntity> GetAllBind()
        {
            return Set.ToList();
        }

        public TEntity GetById(params object[] id)
        {
            return Set.Find(id);
        }

        public bool Remove(TEntity entity)
        {
            Set.Attach(entity);
            ctx.Entry(entity).State = EntityState.Deleted;

            return ctx.SaveChanges() > 0;
        }

        public bool Update(TEntity entity)
        {
            set.AddOrUpdate(entity);
            //set.AsNoTracking();
            //set.n.Attach(entity);
            //ctx.Entry(entity).State = EntityState.Modified;

            return ctx.SaveChanges() > 0;
        }
    }
}
