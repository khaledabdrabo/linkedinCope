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
    public class UserLanguageManager : DbManager<UserLanguage>
    {
        public UserLanguageManager(DbContext ctx) : base(ctx)
        {
        }
        public List<UserLanguage> GetAllBindByUserID(string id)
        {

            List<UserLanguage> UserLanguages = this.Set.Where(e => e.UserId == id).ToList();
            return UserLanguages;
        }
    }
}
