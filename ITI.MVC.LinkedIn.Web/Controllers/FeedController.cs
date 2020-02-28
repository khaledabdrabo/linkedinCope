// <author>Ibrahim Farhan</author>

using ITI.MVC.LinkedIn.DbLayer.Entities;
using ITI.MVC.LinkedIn.DbLayer.Enums;
using ITI.MVC.LinkedIn.Store;
using ITI.MVC.LinkedIn.Web.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITI.MVC.LinkedIn.Web.Controllers
{
    [Authorize]
    public class FeedController : Controller
    {
        private DbStore store;
        private ApplicationUser user;

        public DbStore Store
        {
            get => store ?? HttpContext.GetOwinContext().Get<DbStore>();

            private set => store = value;
        }

        public ApplicationUser CurrentUser
        {
            get => user ?? Store.ApplicationUserManager.FindById(User.Identity.GetUserId());

            private set => user = value;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Post> posts = Store.PostManager.GetByUserId(CurrentUser.Id);
            List<SharedPost> sharedPosts = Store.SharedPostManager.GetByUserId(CurrentUser.Id);

            return View(new PostsVM { User = CurrentUser, Posts = posts, SharedPosts = sharedPosts });
        }

        [HttpPost]
        public bool CreatePost(PostVM model)
        {
            if (!ModelState.IsValid || (model.PostContent == null && model.File == null))
            {
                return false;
            }

            try
            {
                string userId = CurrentUser.Id;

                Text text = new Text { Content = model.PostContent, Time = DateTime.Now, UserId = userId };
                text = Store.TextManager.Add(text);

                if (model.File != null)
                {
                    string targetPath = Path.Combine(HttpContext.Server.MapPath("~/Uploads"), model.File.FileName);
                    model.File.SaveAs(targetPath);

                    Image image = new Image { ImageRole = ImageRole.Post, Url = targetPath, UserId = userId };
                    image = Store.ImageManager.Add(image);

                    text.Images = new List<Image> { image };
                }

                Post post = new Post { TextId = text.Id, UserId = userId };
                Store.PostManager.Add(post);
            }

            catch
            {
                return false;
            }

            return true;
        }

        [HttpPost]
        public bool CreateComment(CommentVM model)
        {
            if (!ModelState.IsValid || (model.CommentContent == null && model.File == null))
            {
                return false;
            }

            try
            {
                string userId = CurrentUser.Id;

                Text text = new Text { Content = model.CommentContent, Time = DateTime.Now, UserId = userId };
                text = Store.TextManager.Add(text);

                if (model.File != null)
                {
                    string targetPath = Path.Combine(HttpContext.Server.MapPath("~/Uploads"), model.File.FileName);
                    model.File.SaveAs(targetPath);

                    Image image = new Image { ImageRole = ImageRole.Post, Url = targetPath, UserId = userId };
                    image = Store.ImageManager.Add(image);

                    text.Images = new List<Image> { image };
                }

                Comment comment = new Comment { TextId = text.Id, UserId = userId, PostId = model.PostId };
                Store.CommentManager.Add(comment);
            }

            catch
            {
                return false;
            }

            return true;
        }

        [HttpPost]
        public bool ToggleLike(int id, string entityType)
        {
            try
            {
                switch (entityType)
                {
                    case "post":

                        PostLike like = Store.PostLikeManager.GetById(id, CurrentUser.Id);

                        if (like != null)
                        {
                            Store.PostLikeManager.Remove(like);
                        }

                        else
                        {
                            Store.PostLikeManager.Add(new PostLike { PostId = id, UserId = CurrentUser.Id });
                        }

                        break;

                    case "comment":

                        CommentLike commentLike = Store.CommentLikeManager.GetById(id, CurrentUser.Id);

                        if (commentLike != null)
                        {
                            Store.CommentLikeManager.Remove(commentLike);
                        }

                        else
                        {
                            Store.CommentLikeManager.Add(new CommentLike { CommentId = id, UserId = CurrentUser.Id });
                        }

                        break;

                    case "reply":

                        ReplyLike replyLike = Store.ReplyLikeManager.GetById(id, CurrentUser.Id);

                        if (replyLike != null)
                        {
                            Store.ReplyLikeManager.Remove(replyLike);
                        }

                        else
                        {
                            Store.ReplyLikeManager.Add(new ReplyLike { ReplyId = id, UserId = CurrentUser.Id });
                        }

                        break;

                    default:
                        break;
                }
            }

            catch
            {
                return false;
            }

            return true;
        }
    }
}