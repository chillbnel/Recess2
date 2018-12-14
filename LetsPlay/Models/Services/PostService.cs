using LetsPlay.Data;
using LetsPlay.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Models.Services
{
    public class PostService : IPost
    {
        private LetsPlayDbContext _context;

        public PostService(LetsPlayDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create a new Post
        /// </summary>
        /// <param name="post">Post to post</param>
        /// <returns>Post that has been created</returns>
        public async Task CreatePost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete a specic post
        /// </summary>
        /// <param name="id">The ID of the post to be deleted.</param>
        /// <returns></returns>
        public async Task DeletePost(int id)
        {
            Post post = await GetPost(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        ///  Get all the posts from the Database
        /// </summary>
        /// <returns>A list of posts</returns>
        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        /// <summary>
        ///  Get last 10 posts from the Database
        /// </summary>
        /// <returns>A list of posts</returns>
        public async Task<IEnumerable<Post>> GetLastTenPosts()
        {
            return await _context.Posts.OrderByDescending(p => p.ID).Take(10).ToListAsync();
        }

        /// <summary>
        ///  Get a single post from the database
        /// </summary>
        /// <param name="id">the post id to be displayed</param>
        /// <returns>a single post</returns>
        public async Task<Post> GetPost(int? id)
        {
            var result = await _context.Posts.FindAsync(id);
            return result;
        }

        /// <summary>
        /// Update a post's details
        /// </summary>
        /// <param name="post">The post to be updated</param>
        /// <returns>Returns the updated post</returns>
        public async Task UpdatePost(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task CreateASignUp(PlayerSignups paplayerSignUpForEvent)
        {
            _context.Signups.Add(paplayerSignUpForEvent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteASignUp(string userName, int postID)
        {
            var eventSignedUp = await _context.Signups.FindAsync(postID, userName);
            _context.Signups.Remove(eventSignedUp);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<PlayerSignups> GetAllPlayersSignedUp(int postID)
        {
            var allSignUps = _context.Signups.Where(x => x.PostID == postID);

            return allSignUps;
        }

        public IEnumerable<Comments> GetAllCommentsForPost(int postID)
        {
            var allComments = _context.Comments.Where(c => c.PostNumber == postID);

            return allComments;
        }

        public async Task<List<Post>> GetAllSignedupEventsForPlayer(string username)
        {
            var signups = _context.Signups.Where(x => x.Username == username);

            List<Post> events = new List<Post>();

            foreach (var signup in signups)
            {
                var eventID = signup.PostID;
                Post temp = await GetPost(eventID);
                events.Add(temp);
            }

            return events;
        }
    }
}
