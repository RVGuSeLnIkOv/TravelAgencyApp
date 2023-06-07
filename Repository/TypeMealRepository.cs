using TravelAgencyApp.Data;
using TravelAgencyApp.Interfaces;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.Repository
{
    public class TypeMealRepository : ITypeMealRepository
    {
        private readonly DataContext _context;

        public TypeMealRepository(DataContext context)
        {
            _context = context;
        }

        public int GetIdTypeMeal(string typeMealName)
        {
            var typeMeal = _context.TypesMeal.Where(tm => tm.TypeMealName == typeMealName).FirstOrDefault();

            if (typeMeal == null)
                return -1;

            return typeMeal.IdTypeMeal;
        }

        public TypeMeal GetTypeMeal(int id)
        {
            return _context.TypesMeal.Where(tm => tm.IdTypeMeal == id).FirstOrDefault();
        }

        public ICollection<TypeMeal> GetTypesMeal()
        {
            return _context.TypesMeal.OrderBy(tm => tm.IdTypeMeal).ToList();
        }
    }
}
