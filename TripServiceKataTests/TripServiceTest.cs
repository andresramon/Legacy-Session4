using System;
using TripServiceKata.Exception;
using TripServiceKata.Trip;
using TripServiceKata.User;
using Xunit;

namespace TripServiceKataTests
{
    public class TripServiceTestShould
    {
        [Fact]
        public void Raise_error_when_user_is_not_logged_in()
        {
            var tripService = new TestableTripService(null);

            Assert.Throws<UserNotLoggedInException>(() => tripService.GetTripsByUser(null));
        }
        
        [Fact]
        public void Given_a_Logged_User_With_No_Friends_return_none_trips()
        {
            var tripService = new TestableTripService(new User());

            Assert.Empty(tripService.GetTripsByUser(new User()));
        }
        
        [Fact]
        public void Given_a_Requested_User_With_Friends_but_logged_user_is_not_friend()
        {
            var requestedUser = new User();
            var loggedUser = new User();
            var tripService = new TestableTripService(loggedUser);
            requestedUser.AddFriend(new User());
            
            Assert.Empty(tripService.GetTripsByUser(requestedUser));
        }
        [Fact]
        public void Given_a_Requested_User_With_Friends_but_logged_user_is_friend()
        {
            var requestedUser = new User();
            var loggedUser = new User();
            var tripService = new TestableTripService(loggedUser);
            requestedUser.AddFriend(loggedUser);
            
            Assert.Equal(tripService.GetTripsByUser(requestedUser), requestedUser.Trips());
        }
    }
}