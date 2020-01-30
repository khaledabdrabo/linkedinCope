using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbManager
{
    public interface IDbManager<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllBind();
        TEntity GetById(params object[] id);
        TEntity Add(TEntity entity);
        bool Remove(TEntity entity);
        bool Update(TEntity entity);
    }
}
