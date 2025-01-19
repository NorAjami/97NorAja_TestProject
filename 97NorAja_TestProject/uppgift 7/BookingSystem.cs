using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _97NorAja_TestProject.uppgift_7
{

    public class BookingSystem // klass för att boka en tidslucka och returnera en lista över tillgängliga tidsluckor
    {
        public List<Booking> Bookings { get; private set; } = new List<Booking>();

        // Bokar en tidslucka
        public bool BookTimeSlot(DateTime startTime, DateTime endTime)
        {
            if (startTime >= endTime)
                throw new ArgumentException("Start time must be before end time.");

            if (Bookings.Exists(b => !(b.EndTime <= startTime || b.StartTime >= endTime)))
            {
                return false; // Överlappande tidslucka
            }

            Bookings.Add(new Booking { StartTime = startTime, EndTime = endTime });
            return true; // Bokning lyckades
        }

        // Returnerar en lista över tillgängliga tidsluckor
        public List<DateTime> GetAvailableTimeSlots()
        {
            var availableSlots = new List<DateTime>();
            var now = DateTime.Now;
            var endOfDay = now.Date.AddDays(1);

            var currentTime = now;
            while (currentTime < endOfDay)
            {
                if (!Bookings.Any(b => b.StartTime <= currentTime && b.EndTime > currentTime))
                {
                    availableSlots.Add(currentTime);
                }

                currentTime = currentTime.AddMinutes(30); // Exempel: 30-minuters intervaller
            }

            return availableSlots;
        }

        public class Booking // klass för att boka en tidslucka med start- och sluttid
        {
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
        }
    }

}
