using LetsPlay.Models;
using LetsPlay.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPost _posts;

        public PostController(IPost context)
        {
            _posts = context;
        }

        /// <summary>
        /// Get all posts and display on Index page
        /// </summary>
        /// <returns>Index View</returns>
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _posts.GetAllPosts());
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            Post post = await _posts.GetPost(id);
            if (post == null) return NotFound();
            return View(post);
        }

        /// <summary>
        /// Create view for new posts
        /// </summary>
        /// <returns>View with form</returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            if (ModelState.IsValid)
            {
                await _posts.CreatePost(post);
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> SignUpForEvent(string userName, int postID)
        {
            PlayerSignups playerSignUpForEvent = new PlayerSignups()
            {
                Username = userName,
                PostID = postID
            };

            await _posts.CreateASignUp(playerSignUpForEvent);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveSignUpForEvent(string userName, int postID)
        {
            await _posts.DeleteASignUp(userName, postID);

            return RedirectToAction(nameof(Index));
        }
    }
}
