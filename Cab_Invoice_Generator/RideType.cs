using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab_Invoice_Generator
{
    public class RIDE_TYPE
    {
        public int COST_PER_KM = 0;
        public int COST_PER_MINUTE = 0;
        public double MINIMUM_FAIR = 0;
        public RIDE_TYPE Normal = new RIDE_TYPE()
        {
            COST_PER_KM = 10,
            COST_PER_MINUTE = 1,
            MINIMUM_FAIR = 5,
        };
        public RIDE_TYPE Premium = new RIDE_TYPE()
        {
            COST_PER_KM = 15,
            COST_PER_MINUTE = 2,
            MINIMUM_FAIR = 20,
        };
    }
}
