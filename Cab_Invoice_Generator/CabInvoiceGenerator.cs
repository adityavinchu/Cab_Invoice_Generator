using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab_Invoice_Generator
{
    public class CabInvoiceGenerator
    {
        const int COST_PER_KM = 10;
        const int COST_PER_MINUTE = 1;
        const double MINIMUM_FARE = 5;
        List<Ride> rides = new List<Ride>();
        RideRepository rideRepository = new RideRepository();
        public double CalculateFare(double distance, double time, RIDE_TYPE type)
        {
            double result = (distance * COST_PER_KM) + (time * COST_PER_MINUTE);
            if (result < MINIMUM_FARE)
                return MINIMUM_FARE;
            else
                return result;
        }
        public void Add_Ride(string name, int distance, int time, RIDE_TYPE rideType)
        {
            var userRides = rideRepository.GetRideByUserId(name);
            if (userRides == null)
            {
                var userRide = new List<Ride>();
                userRide.Add(new Ride()
                {
                    distance = distance,
                    time = time,
                    type = rideType
                });
                rideRepository.AddRideInRepository(name, userRide);
            }
            else
            {
                userRides.Add(new Ride()
                {
                    distance = distance,
                    time = time,
                    type = rideType
                });
                rideRepository.AddRideInRepository(name, userRides);
            }
        }
        public InvoiceSummary CalculateAggregate(string user)
        {
            var userRides = rideRepository.GetRideByUserId(user);
            double fare = 0;
            foreach (Ride ride in userRides)
            {
                fare += CalculateFare(ride.distance, ride.time, ride.type);
            }
            var summary = new InvoiceSummary()
            {
                no_of_rides = userRides.Count,
                avgFare = fare / userRides.Count,
                totalFare = fare
            };
            return summary;
        }

    }
}
