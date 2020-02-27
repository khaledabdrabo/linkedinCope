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
    public class LanguageManager : DbManager<Language>
    {
        public LanguageManager(DbContext ctx) : base(ctx)
        {
        }

        public IQueryable<Language> GetAllByPrefix(string Prefix)
        {

            var Languages = this.Set.Where(e => e.Name.Contains(Prefix));
            return Languages;
        }
        public Language GetByName(string name)
        {
            Language language = Set.FirstOrDefault(e => e.Name == name);

            return language != null  ? language : null;
        }
    }
}
