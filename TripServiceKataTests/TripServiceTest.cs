using System;
using TripServiceKata.Exception;
using TripServiceKata.Trip;
using Xunit;

namespace TripServiceKataTests
{
    public class TripServiceTestShould
    {
        [Fact]
        public void Raise_error_when_user_is_not_logged_in()
        {
            var tripService = new TripService();

            Assert.Throws<UserNotLoggedInException>(() => tripService.GetTripsByUser(null));
        }
    }
}