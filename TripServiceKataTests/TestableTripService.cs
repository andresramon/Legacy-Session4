using System.Collections.Generic;
using TripServiceKata.Trip;
using TripServiceKata.User;

namespace TripServiceKataTests
{
    public class TestableTripService : TripService
    {
        private readonly User user = null; 
        public TestableTripService(User user)
        {
            this.user = user;
        }
        protected override User GetLoggedUser()
        {
            return user;
        }

        protected override List<Trip> FindTripsByUser(User user)
        {
            return user.Trips();
        }
    }
}