using ITI.MVC.LinkedIn.DbLayer.Entities;
using ITI.MVC.LinkedIn.Store;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITI.MVC.LinkedIn.Web.Controllers
{
    public class FriendsController : Controller
    {
        private DbStore store;

        public DbStore Store
        {
            get { return store ?? HttpContext.GetOwinContext().Get<DbStore>(); }

            set { store = value; }
        }
        // GET: Friends
        public JsonResult getUsers(string Prefix)
       {

            List<ApplicationUser> users;
            Store.DbContext.Configuration.ProxyCreationEnabled = false;
            var customeUser = new List<object>();
     if (Prefix != null)
            {
                users = Store.ApplicationUserManager.Users.Include(u => u.Images).Include(u=>u.Connections).Where(u => (u.FirstName+u.LastName).Contains(Prefix)).ToList();

                if (users.Count != 0)
       {
                    bool isFriend=false;
                    
                    foreach (var item in users)
                    {
                        if (item.Connections.ToList().Where(u=>u.ReceiverId == User.Identity.GetUserId()).FirstOrDefault()!=null) { isFriend = true; }
                        
                        if (item.Images.Count != 0)
                        {
                            var cc = (item.Images.ToList()[0].Url).Replace("C:\\Users\\khaled abdrabo\\Desktop\\LatestVersion\\newversion\\iti-mvc-linkedin\\ITI.MVC.LinkedIn.Web\\Images\\", "");
                            customeUser.Add(new { url = cc, id = item.Id, name = (item.FirstName + item.LastName),friend=isFriend });
                        }
                        else
                        {
                            //var cc = (item.Images.ToList()[0].Url).Replace("Images\\", " ");
                            customeUser.Add(new { url = "img_184513204708457.png", id = item.Id, name = (item.FirstName + item.LastName), friend = isFriend });

                        }
                    }
                }
                else
                {
                    customeUser.Add(new { url = "nnnnnn", id ="dummy", name = "name not found" });

                }


                //return Languages;
                return Json(customeUser, JsonRequestBehavior.AllowGet);
            }
            else
            {
                users = null;
               return Json(users, JsonRequestBehavior.AllowGet);
            }
            
        }

        public ActionResult search()
        {
            return View();
        }
        public void AddFriendRequest(string FriendID)
        {
            if (FriendID != null)
            {
                string SenderID = User.Identity.GetUserId();
                Store.ConnectionRequestManager.Add(new ConnectionRequest() { ReceiverId = FriendID, SenderId = SenderID });
                
            }

        }
        public int getFriendRequest()
        {
            return (Store.ConnectionRequestManager.getConnectionRequestNum(User.Identity.GetUserId()));
             
        }
        public JsonResult getAllFriendRequest()
        {
            //List<ApplicationUser> senders=null;
            Store.DbContext.Configuration.ProxyCreationEnabled = false;
            var list=  Store.ConnectionRequestManager.getConnectionRequest(User.Identity.GetUserId());
            var customeUser = new List<object>();
            foreach (var item in list)
            {
                if (item.Sender.Images.Count != 0)
                {
                    var cc = item.Sender.Images.ToList()[0].Url.Replace("C:\\Users\\khaled abdrabo\\Desktop\\LatestVersion\\newversion\\iti-mvc-linkedin\\ITI.MVC.LinkedIn.Web\\Images\\", "");
                    customeUser.Add(new { url = cc, id = item.Sender.Id, name = (item.Sender.FirstName + item.Sender.LastName) });
                }
                else
                {
                    //var cc = (item.Images.ToList()[0].Url).Replace("Images\\", " ");
                    customeUser.Add(new { url = "img_184513204708457.png", id = item.Sender.Id, name = (item.Sender.FirstName + item.Sender.LastName) });

                }
            }

            return Json(customeUser, JsonRequestBehavior.AllowGet);



        }
        public void AcceptRequest(string SenderId)
        {
            Store.ConnectionManager.Add(new Connection { ReceiverId = User.Identity.GetUserId(), SenderId = SenderId, StartDate = DateTime.Now });
            Store.ConnectionRequestManager.Remove(Store.ConnectionRequestManager.getRecieverRequest(SenderId));
        }


    }
}