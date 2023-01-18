using Microsoft.AspNet.Identity;
using SocialMedia.Models.PostModels;
using SocialMedia.Services.PostService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace SocialMedia.WebMVC.Controllers.PostController
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            var service = CreatePostService();
            var model = service.GetAllPosts();
            return View(model);
        }

        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userId);
            return service;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreate model, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.UserId = User.Identity.GetUserId();

            string rootedPath;
            string path = " ";
            string fileName;

            var service = CreatePostService();

            if (file != null)
            {
                fileName = Path.GetFileName(file.FileName);
                path = "/Content/img/" + fileName;

                rootedPath = Path.Combine(Server.MapPath("~/Content/img"), fileName);
                file.SaveAs(rootedPath);
            }

            if (service.CreatePost(model, path))
            {

                TempData["SaveResult"] = "The post was added successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The post could not be added... Try again later.");
            return View(model);
            //if (!ModelState.IsValid)
            //    return View(model);

            //var service = CreatePostService();

            //if (service.CreatePost(model))
            //{
            //    TempData["SaveResult"] = "Your post was created successfully.";
            //    return RedirectToAction("Index");
            //}

            //ModelState.AddModelError("", "Your post could not be created... Try again later.");
            //return View(model);
        }
    }
}