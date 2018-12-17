using LetsPlay.Data;
using LetsPlay.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        /// <summary>
        /// Tests get on ApplicationUser model
        /// </summary>
        [Fact]
        public void CanGetApplicationNameTest()
        {
            ApplicationUser user = new ApplicationUser();
            user.Name = "Brian";

            Assert.Equal("Brian", user.Name);
        }

        /// <summary>
        /// Tests set on ApplicationUser model
        /// </summary>
        [Fact]
        public void CanSetApplicationNameTest()
        {
            ApplicationUser user = new ApplicationUser();
            user.Name = "Brian";
            user.Name = "Jeff";

            Assert.Equal("Jeff", user.Name);
        }

        /// <summary>
        /// Tests get on Comments model
        /// </summary>
        [Fact]
        public void CanGetCommentsMessageTest()
        {
            Comments comment = new Comments();
            comment.Message = "Brian rocks!";

            Assert.Equal("Brian rocks!", comment.Message);
        }

        /// <summary>
        /// Tests set on Comments model
        /// </summary>
        [Fact]
        public void CanSetCommentsMessageTest()
        {
            Comments comment = new Comments();
            comment.Message = "Brian rocks!";

            comment.Message = "Richard rocks more!";

            Assert.Equal("Richard rocks more!", comment.Message);
        }

        /// <summary>
        /// Tests get on Friendship model
        /// </summary>
        [Fact]
        public void CanGetFriendshipMessageTest()
        {
            Friendships friendship = new Friendships();
            friendship.User1 = "chillbel";

            Assert.Equal("chillbel", friendship.User1);
        }

        /// <summary>
        /// Tests set on Friendship model
        /// </summary>
        [Fact]
        public void CanSetFriendshipMessageTest()
        {
            Friendships friendship = new Friendships();
            friendship.User1 = "chillbel";

            friendship.User1 = "jeffrowtell";

            Assert.Equal("jeffrowtell", friendship.User1);
        }
    }

    /// <summary>
    /// Tests CR operations on Post table
    /// </summary>
    [Fact]
    public async void PostCRTest()
    {
        DbContextOptions<LetsPlayDbContext> options =
            new DbContextOptionsBuilder<LetsPlayDbContext>()
            .UseInMemoryDatabase("Posts")
            .Options;

        using (LetsPlayDbContext context = new LetsPlayDbContext(options))
        {

            //CREATE
            //Arrange
            Post post = new Post();
            post.Title = "basketball game";

            context.Posts.Add(post);
            context.SaveChanges();

            //READ
            var myPost = await context.Posts.FirstOrDefaultAsync(a => a.Title == post.Title);

            Assert.Equal("basketball game ", myPost.Title);
        }
    }

    /// <summary>
    /// Tests CRD operations on Friendships table
    /// </summary>
    [Fact]
    public async void FriendshipCRUDTest()
    {
        DbContextOptions<LetsPlayDbContext> options =
            new DbContextOptionsBuilder<LetsPlayDbContext>()
            .UseInMemoryDatabase("Friendships")
            .Options;

        using (LetsPlayDbContext context = new LetsPlayDbContext(options))
        {

            //CREATE
            //Arrange
            Friendships friendship = new Friendships();
            friendship.User1 = "jeff";
            friendship.User2 = "brian";

            context.Friendships.Add(friendship);
            context.SaveChanges();

            //READ
            var myFriendship = await context.Friendships.FirstOrDefaultAsync(a => a.User1 == friendship.User1);

            Assert.Equal("jeff", myFriendship.User1);

            //DELETE
            context.Friendships.Remove(myFriendship);
            context.SaveChanges();

            var deletedAmenity = await context.Friendships.FirstOrDefaultAsync(a => a.User1 == myFriendship.User1);

            Assert.True(deletedAmenity == null);
        }
    }

    /// <summary>
    /// Tests CR operations on Comments table
    /// </summary>
    [Fact]
    public async void CommentsCRTest()
    {
        DbContextOptions<LetsPlayDbContext> options =
            new DbContextOptionsBuilder<LetsPlayDbContext>()
            .UseInMemoryDatabase("Comments")
            .Options;

        using (LetsPlayDbContext context = new LetsPlayDbContext(options))
        {

            //CREATE
            //Arrange
            Comments comment = new Comments();
            comment.Message = "writing tests are a necessary evil!";

            context.Comments.Add(comment);
            context.SaveChanges();

            //READ
            var myComment = await context.Comments.FirstOrDefaultAsync(a => a.Message == comment.Message);

            Assert.Equal("writing tests are a necessary evil!", myComment.Message);
        }
    }


    /// <summary>
    /// Tests CR operations on Messages table
    /// </summary>
    [Fact]
    public async void MessagesCRTest()
    {
        DbContextOptions<LetsPlayDbContext> options =
            new DbContextOptionsBuilder<LetsPlayDbContext>()
            .UseInMemoryDatabase("Messages")
            .Options;

        using (LetsPlayDbContext context = new LetsPlayDbContext(options))
        {

            //CREATE
            //Arrange
            Messages message = new Messages();
            message.Body = "writing tests are a necessary evil!";

            context.Messages.Add(message);
            context.SaveChanges();

            //READ
            var myMessage = await context.Messages.FirstOrDefaultAsync(a => a.Body == message.Body);

            Assert.Equal("writing tests are a necessary evil!", myMessage.Body);
        }
    }

}

