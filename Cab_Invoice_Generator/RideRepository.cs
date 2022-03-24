using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab_Invoice_Generator
{
    public class RideRepository
    {
        public Dictionary<string, List<Ride>> UserRides = new Dictionary<string, List<Ride>>();
        public void AddRideInRepository(string user, List<Ride> rides)
        {
            UserRides[user] = rides;
        }
        public List<Ride> GetRideByUserId(string user)
        {
            try
            {
                return UserRides[user];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
