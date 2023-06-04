using TravelAgencyApp.Dto;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.Interfaces
{
    public interface IBookingRepository
    {
        ICollection<Booking> GetBookings(string idTour);
        Booking GetBooking(int id);
        bool CreateBooking(Booking booking);
        bool CheckingBooking(Booking booking);
        bool UpdateBooking(Booking booking);
        bool DeleteBooking(Booking booking);
        bool BookingExists(int id);
        bool Save();
    }
}
