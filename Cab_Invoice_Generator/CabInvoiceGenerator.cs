using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab_Invoice_Generator
{
    public class Cabinvoicegenerator
    {
        
        RIDE_TYPE type;
        private readonly Double COST_PER_KM;
        private readonly Double COST_PER_MINUTE;
        private readonly Double MINIMUM_FARE;


        public Cabinvoicegenerator(RIDE_TYPE ridetype)
        {
            this.type = ridetype;
            try
            {
                if (ridetype.Equals(RIDE_TYPE.NORMAL))
                {
                    COST_PER_KM = 10;
                    MINIMUM_FARE = 5;
                    COST_PER_MINUTE = 1;
                }
                if (ridetype.Equals(RIDE_TYPE.PREMIUM))
                {
                    COST_PER_KM = 15;
                    COST_PER_MINUTE = 2;
                    MINIMUM_FARE= 20;
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
            }

        }

        public Double CalculateFair(double distance, int time)
        {
            double fair = 0;
            try
            {
                fair = distance * COST_PER_KM + time * COST_PER_MINUTE;
            }
            catch (CabInvoiceException)
            {
                if (time < 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Time cannot be negative");
                }
                if (distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Distance should be greater than Zero");
                }
                if (type.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");

                }
            }
            return Math.Max(fair, MINIMUM_FARE);
        }
        public Invoicesummary FairMultipleRides(Ride[] rides)
        {
            double Totalfair = 0;
            try
            {
                foreach (Ride ride in rides)
                {
                    Totalfair += this.CalculateFair(ride.distance, ride.time);
                }
            }
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are Null");
                }

            }
            return new Invoicesummary(rides.Length, Totalfair);
        }

    }
}
