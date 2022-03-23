using Cab_Invoice_Generator;
using NUnit.Framework;

namespace Cab_Invoice_Testing
{
    public class Tests
    {
        public CabInvoiceGenerator invoiceGenerator;
        [SetUp]
        public void Setup()
        {
            invoiceGenerator = new CabInvoiceGenerator();
        }
        [Test]
        public void Test1()
        {
            double fare = invoiceGenerator.CalculateFare(2, 5, new RIDE_TYPE().Normal);
            Assert.AreEqual(25, fare);
        }

        [Test]
        public void CheckForTotalFare()
        {

            invoiceGenerator.AddRide("ABC", 2, 5, new RIDE_TYPE().Normal);
            invoiceGenerator.AddRide("ABC", 12, 15, new RIDE_TYPE().Normal);
            var fare = invoiceGenerator.CalculateAggregate("ABC");
            Assert.AreEqual(135, fare.totalFare);
        }
        [Test]
        public void CheckForNoOfRides()
        {
            invoiceGenerator.AddRide("XYZ", 2, 5, new RIDE_TYPE().Normal);
            invoiceGenerator.AddRide("XYZ", 12, 15, new RIDE_TYPE().Normal);
            var fare = invoiceGenerator.CalculateAggregate("XYZ");
            Assert.AreEqual(1, fare.no_of_rides);
        }
        [Test]
        public void CheckForAverageFare()
        {
            invoiceGenerator.AddRide("XYZ", 2, 5, new RIDE_TYPE().Normal);
            invoiceGenerator.AddRide("XYZ", 12, 15, new RIDE_TYPE().Normal);
            var fare = invoiceGenerator.CalculateAggregate("XYZ");
            Assert.AreEqual(25, fare.avgFare);
        }
    }
}