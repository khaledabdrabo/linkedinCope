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
    public class ConnectionRequestManager : DbManager<ConnectionRequest>
    {
        ApplicationDbContext db;
        public ConnectionRequestManager(ApplicationDbContext ctx) : base(ctx)
        {
            db = ctx;
        }

        public int getConnectionRequestNum(string v)
        {
           return db.ConnectionRequests.Where(c => c.ReceiverId == v).ToList().Count;
        }

        public List<ConnectionRequest> getConnectionRequest(string v)
        {
            return db.ConnectionRequests.Include(c=>c.Sender).Include(c=>c.Sender.Images).Where(c => c.ReceiverId == v).ToList();
        }

        public ConnectionRequest getRecieverRequest(string id)
        {
           return db.ConnectionRequests.Where(c => c.SenderId == id).FirstOrDefault();
        }
    }
}
