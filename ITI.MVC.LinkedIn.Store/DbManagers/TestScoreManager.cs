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
    public class TestScoreManager : DbManager<TestScore>
    {
        public TestScoreManager(DbContext ctx) : base(ctx)
        {
        }
        public List<TestScore> GetAllBindByUserID(string id)
        {

            List<TestScore> TestScores = this.Set.Where(e => e.UserId == id).ToList();
            return TestScores;
        }
    }
}
