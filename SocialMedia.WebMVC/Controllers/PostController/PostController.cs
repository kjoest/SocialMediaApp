using Microsoft.AspNet.Identity;
using SocialMedia.Models.PostModels;
using SocialMedia.Services.PostService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = CreatePostService();

            if (service.CreatePost(model))
            {
                TempData["SaveResult"] = "Your post was created successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your post could not be created... Try again later.");
            return View(model);
        }
    }
}