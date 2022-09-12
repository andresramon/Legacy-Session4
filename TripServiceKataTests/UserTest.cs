using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripServiceKata.Trip;
using TripServiceKata.User;
using Xunit;

namespace TripServiceKataTests
{
    public class UserTest
    {
        [Fact]
        public void UserShouldGetAFriend()
        {
            User user = new User();
            User friend = new User();

            user.AddFriend(friend);

            Assert.Equal(friend, user.GetFriends()[0]);
        }

        [Fact]
        public void UserShouldGetTrips()
        {
            User user = new User();
            Trip trip = new Trip();

            user.AddTrip(trip);

            Assert.Equal(trip, user.Trips()[0]);
        }

        [Fact]
        public void GivenAUserCheckIfIsMyFriend()
        {
            User user = new User();
            User friend = new User();

            user.AddFriend(friend);

            Assert.True(user.IsFriendOf(friend));
        }

        [Fact]
        public void GivenAUserCheckIfIsNotMyFriend()
        {
            User user = new User();

            Assert.False(user.IsFriendOf(new User()));
        }

    }
}
