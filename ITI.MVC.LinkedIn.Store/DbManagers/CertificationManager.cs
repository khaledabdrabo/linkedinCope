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
    public class CertificationManager : DbManager<Certification>
    {
        ApplicationDbContext dbc;
        public CertificationManager(ApplicationDbContext ctx) : base(ctx)
        {
            dbc = ctx;
        }

        public Certification checkIfExist(string name)
        {
            return dbc.Certifications.Where(o => o.Name == name).FirstOrDefault();
        }

        public Certification GetuserCirtificates(int id)
        {
            return dbc.Certifications.Include(c => c.UserCertifications).Where(c=>c.Id==id).FirstOrDefault();
        }
    }
}
