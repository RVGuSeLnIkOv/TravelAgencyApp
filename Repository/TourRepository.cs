﻿using Microsoft.EntityFrameworkCore;
using TravelAgencyApp.Data;
using TravelAgencyApp.Helper;
using TravelAgencyApp.Interfaces;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.Repository
{
    public class TourRepository : ITourRepository
    {
        private readonly DataContext _context;

        public TourRepository(DataContext context)
        {
            _context = context;
        }

        public bool ArchiveTour(Tour tour)
        {
            tour.IsArchive = true;
            _context.Update(tour);

            return Save();
        }

        public bool CheckingTour(Tour tour)
        {
            //проверка вводимых данных
            if (!string.IsNullOrEmpty(tour.CheckinDate.ToString())
                && tour.CheckinDate != DateTime.MinValue
                && !string.IsNullOrEmpty(tour.CheckoutDate.ToString())
                && tour.CheckoutDate != DateTime.MinValue
                && Checking.CheckingInt(tour.Duration.ToString(), 1, 365) != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckingTourists(List<int> tourists)
        {
            foreach (int touristId in tourists)
            {
                Tourist tourist = _context.Tourists.Find(touristId);

                if (tourist == null)
                    return false;
            }

            return true;
        }

        public string CreateTour(Tour tour, List<int> tourists)
        {
            if (!CheckingTourists(tourists))
                return "-1";

            string idStr = "tour_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");

            tour.IdTour = idStr;
            tour.IsArchive = false;

            _context.Tours.Add(tour);

            if (!Save())
                return "-1";

            foreach (int touristId in tourists)
            {
                Tourist tourist = _context.Tourists.Find(touristId);
                if (tourist != null)
                {
                    TouristTour touristTour = new TouristTour()
                    {
                        IdTour = tour.IdTour,
                        IdTourist = touristId
                    };
                    _context.TouristsTours.Add(touristTour);
                }
            }

            if (!Save())
                return "-1";

            return tour.IdTour;
        }

        public ICollection<Tour> GetActiveTours()
        {
            return _context.Tours.Where(t => t.IsArchive == false).OrderBy(t => t.IdTour).ToList();
        }

        public ICollection<Tour> GetArchiveTours()
        {
            return _context.Tours.Where(t => t.IsArchive == true).OrderBy(t => t.IdTour).ToList();
        }

        public Tour GetTour(string id)
        {
            return _context.Tours.Where(t => t.IdTour == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool TourExists(string id)
        {
            return _context.Tours.Any(t => t.IdTour == id);
        }

        public bool UnarchiveTour(Tour tour)
        {
            tour.IsArchive = false;
            _context.Update(tour);

            return Save();
        }

        public bool UpdateTour(Tour tour)
        {
            _context.Update(tour);
            return Save();
        }

        public ICollection<Tourist> GetTouristsOnTour(string id)
        {
            var touristsId = _context.TouristsTours.Where(tt => tt.IdTour == id).Select(tt => tt.IdTourist).ToList();

            List<Tourist> tourists = new();

            foreach (var touristId in touristsId)
            {
                var tourist = _context.Tourists.Where(t => t.IdTourist == touristId).FirstOrDefault();
                
                if (tourist != null)
                    tourists.Add(tourist);
            }

            //ICollection<Tourist> touristsRes = tourists;

            return tourists;
        }
    }
}