using TravelAgencyApp.Models;

namespace TravelAgencyApp.Interfaces
{
    public interface ITypeMealRepository
    {
        ICollection<TypeMeal> GetTypesMeal();
        int GetIdTypeMeal(string typeMealName);
        TypeMeal GetTypeMeal(int id);
    }
}
