using GleamAPI.Entities.Venue;

namespace GleamAPI.Entities
{
    public class City
    {
        
        public Guid CityId { get; set; }

        public string CityName { get; set; }

        public List<GleamVenue> GleamVeuues { get; set; }

        //public List<GleamVenue> GleamVenues { get; set; } = new List<GleamVenue>();



    }


}
