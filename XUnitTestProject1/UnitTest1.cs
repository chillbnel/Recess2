using LetsPlay.Models;
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
    }
}

