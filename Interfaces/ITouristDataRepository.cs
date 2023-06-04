using Microsoft.AspNetCore.Mvc.ModelBinding;
using TravelAgencyApp.Dto;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.Interfaces
{
    public interface ITouristDataRepository
    {
        bool CreateTouristData(TouristData touristData);
        bool CheckingTouristData(TouristData touristData);
        bool UpdateTouristData(TouristData touristData);
        bool Save();
        bool TouristDataExists(int id);
        bool TouristHaveData(int idTourist);
    }
}
