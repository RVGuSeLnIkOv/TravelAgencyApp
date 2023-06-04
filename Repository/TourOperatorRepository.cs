using TravelAgencyApp.Data;
using TravelAgencyApp.Interfaces;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.Repository
{
    public class TourOperatorRepository : ITourOperatorRepository
    {
        private readonly DataContext _context;

        public TourOperatorRepository(DataContext context)
        {
            _context = context;
        }

        public int GetIdTourOperator(string tourOperatorName)
        {
            var tourOperator = _context.TourOperators.Where(to => to.TourOperatorName == tourOperatorName).FirstOrDefault();

            if (tourOperator == null)
                return -1;

            return tourOperator.IdTourOperator;
        }

        public ICollection<TourOperator> GetTourOperators()
        {
            return _context.TourOperators.OrderBy(to => to.TourOperatorName).ToList();
        }
    }
}
