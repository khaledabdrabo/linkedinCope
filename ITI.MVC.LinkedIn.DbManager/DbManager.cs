using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public TEntity Add(TEntity entity)
        {
            TEntity e = set.Add(entity);

            return ctx.SaveChanges() > 0 ? e : null;
        }

        public IQueryable<TEntity> GetAll()
        {
            return set;
        }

        public IEnumerable<TEntity> GetAllBind()
        {
            return set.ToList();
        }

        public TEntity GetById(params object[] id)
        {
            return set.Find(id);
        }

        public bool Remove(TEntity entity)
        {
            set.Attach(entity);
            ctx.Entry(entity).State = EntityState.Deleted;

            return ctx.SaveChanges() > 0;
        }

        public bool Update(TEntity entity)
        {
            set.Attach(entity);
            ctx.Entry(entity).State = EntityState.Modified;

            return ctx.SaveChanges() > 0;
        }
    }
}
