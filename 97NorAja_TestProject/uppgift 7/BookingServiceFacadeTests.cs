using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace _97NorAja_TestProject.uppgift_7
{
    [TestClass]
    public class BookingServiceFacadeTests
    {
        [TestMethod]
        public void BookSlot_ShouldAddBooking_WhenSlotIsAvailable()
        {
            // ARRANGE
            var bookingSystem = new BookingSystem();
            var facade = new BookingServiceFacade(bookingSystem);
            var startTime = DateTime.Now.AddHours(1);
            var endTime = startTime.AddHours(1);

            //bookingSystem.BookTimeSlot(startTime, endTime).Returns(true);

            // ACT
            var result = facade.BookSlot(startTime, endTime);

            // ASSERT
            Assert.IsTrue(result);
            // bookingSystem.Received(1).BookTimeSlot(startTime, endTime);
            Assert.AreEqual(1, bookingSystem.Bookings.Count);
            Assert.AreEqual(startTime, bookingSystem.Bookings[0].StartTime);
            Assert.AreEqual(endTime, bookingSystem.Bookings[0].EndTime);
        }

        [TestMethod]
        public void BookSlot_ShouldNotAddBooking_WhenSlotIsUnavailable()
        {
            // ARRANGE
            var bookingSystem = new BookingSystem();
            var facade = new BookingServiceFacade(bookingSystem);

            var startTime = DateTime.Now.AddHours(1);
            var endTime = startTime.AddHours(1);

            //bookingSystem.BookTimeSlot(startTime, endTime).Returns(false);

            // Första bokningen
            facade.BookSlot(startTime, endTime);

            // ACT
            var result = facade.BookSlot(startTime.AddMinutes(30), endTime.AddMinutes(30));

            // ASSERT
            Assert.IsFalse(result);
            Assert.AreEqual(1, bookingSystem.Bookings.Count);
        }

        [TestMethod]
        public void GetAvailableSlots_ShouldReturnAvailableTimeSlots()
        {
            // ARRANGE
            var bookingSystem = new BookingSystem();
            var facade = new BookingServiceFacade(bookingSystem);


            var availableSlots = facade.GetAvailableSlots();
            /* {
                 DateTime.Now.AddHours(1),
                 DateTime.Now.AddHours(2)
             }; 
            */

            //bookingSystem.GetAvailableTimeSlots().Returns(availableSlots);


            //var result = facade.GetAvailableSlots();

            // ASSERT

            Assert.IsTrue(availableSlots.Count > 0); // Kontrollera att det finns tillgängliga tidsluckor

            //CollectionAssert.AreEqual(availableSlots, result);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BookSlot_ShouldThrowException_WhenStartTimeIsAfterEndTime()
        {
            // ARRANGE
            var bookingSystem = new BookingSystem();
            var facade = new BookingServiceFacade(bookingSystem);

            var startTime = DateTime.Now.AddHours(2);
            var endTime = DateTime.Now.AddHours(1);

            // ACT
            facade.BookSlot(startTime, endTime);
        }
    }
}
