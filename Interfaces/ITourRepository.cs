using TravelAgencyApp.Dto;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.Interfaces
{
    public interface ITourRepository
    {
        ICollection<Tour> GetArchiveTours();
        ICollection<Tour> GetActiveTours();
        ICollection<Tourist> GetTouristsOnTour(string id);
        Tour GetTour(string id);
        string CreateTour(Tour tour, List<int> tourists);
        bool CheckingTour(Tour tour);
        bool CheckingTourists(List<int> tourists);
        bool UpdateTour(Tour tour);
        bool ArchiveTour(Tour tour);
        bool UnarchiveTour(Tour tour);
        bool TourExists(string id);
        bool Save();
    }
}
