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
    public class CountryManager : DbManager<Country>
    {
        ApplicationDbContext dbc;
        public CountryManager(ApplicationDbContext ctx) : base(ctx)
        {
            dbc = ctx;
        }

        public Country checkIfExist(string countryName)
        {
            return dbc.Countries.Where(o => o.Name == countryName).FirstOrDefault();
        }

        public List<string> GetAllCountry()
        {
            return Set.Select(e => e.Name).ToList();
        }
    }
}
