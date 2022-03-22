using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab_Invoice_Generator
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> user = null;
        public RideRepository()
        {
            this.user = new Dictionary<string, List<Ride>>();
        }
        public void AddRide(string userid, Ride[] ride)
        {
            bool contains = this.user.ContainsKey(userid);
            try
            {
                if (contains)
                {

                    List<Ride> list = new List<Ride>();
                    list.AddRange(ride);
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are NUll");
            }
        }
        public Ride[] GetRide(string userid)
        {
            try
            {
                return this.user[userid].ToArray();
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "User id is invalid");

            }
        }
    }
}
