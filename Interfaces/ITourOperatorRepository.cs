using TravelAgencyApp.Models;

namespace TravelAgencyApp.Interfaces
{
    public interface ITourOperatorRepository
    {
        ICollection<TourOperator> GetTourOperators();
        int GetIdTourOperator(string tourOperatorName);
        TourOperator GetTourOperator(int id);
    }
}
