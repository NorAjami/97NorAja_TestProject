using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _97NorAja_TestProject.uppgift_7
{
    public class BookingServiceFacade
    {
        private readonly BookingSystem _bookingSystem;

        public BookingServiceFacade(BookingSystem bookingSystem)
        {
            _bookingSystem = bookingSystem;
        }

        public bool BookSlot(DateTime startTime, DateTime endTime)
        {
            return _bookingSystem.BookTimeSlot(startTime, endTime);
        }

        public List<DateTime> GetAvailableSlots()
        {
            return _bookingSystem.GetAvailableTimeSlots();
        }

    }
}
