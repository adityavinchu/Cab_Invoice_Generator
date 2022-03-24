using NUnit.Framework;
using Cab_Invoice_Generator;

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
        public void Check_TotalFare()
        {

            invoiceGenerator.Add_Ride("ABC", 12, 15, new RIDE_TYPE().Normal);
            invoiceGenerator.Add_Ride("ABC", 12, 5, new RIDE_TYPE().Normal);
            var fare = invoiceGenerator.CalculateAggregate("ABC");
            Assert.AreEqual(135, fare.totalFare);
        }

        [Test]
        public void Check_AverageFare()
        {
            invoiceGenerator.Add_Ride("XYZ", 12, 15, new RIDE_TYPE().Normal);
            invoiceGenerator.Add_Ride("XYZ", 15, 19, new RIDE_TYPE().Normal);
            var fare = invoiceGenerator.CalculateAggregate("XYZ");
            Assert.AreEqual(25, fare.avgFare);
        }
        [Test]
        public void Check_NoOfRides()
        {
            invoiceGenerator.Add_Ride("XYZ", 82, 50, new RIDE_TYPE().Normal);
            invoiceGenerator.Add_Ride("XYZ", 2, 5, new RIDE_TYPE().Normal);
            var fare = invoiceGenerator.CalculateAggregate("XYZ");
            Assert.AreEqual(1, fare.no_of_rides);
        }

    }
}