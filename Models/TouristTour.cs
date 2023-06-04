using System.ComponentModel.DataAnnotations;

namespace TravelAgencyApp.Models
{
    public class TouristTour
    {
        [Key]
        public int IdTouristTour { get; set; }
        public string IdTour { get; set; }
        public int IdTourist { get; set; }

        public virtual Tour Tour { get; set; }
        public virtual Tourist Tourist { get; set; }
    }
}
