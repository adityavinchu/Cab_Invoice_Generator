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
        const int MINIMUM_FARE = 5;

        public double TotalFare_SingleRide(double distance, double time)
        {
            double singleRideFare = distance * COST_PER_KM + time * COST_PER_MINUTE;
            if (singleRideFare < MINIMUM_FARE)
            {
                return MINIMUM_FARE;
            }

            return singleRideFare;
        }

        public double TotalFare_MultipleRide(Ride[] rides)
        {
            double multipleRideFare = 0;
            foreach (Ride ride in rides)
            {
                multipleRideFare += TotalFare_SingleRide(ride.distance, ride.time);
            }
            return multipleRideFare;
        }
    }
}
