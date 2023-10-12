using GleamAPI.Entities.Venue;

namespace GleamAPI.Entities
{
    public class VenueType
    {
        public Guid VenueTypeId { get; set; }

        public string VenueTypeName { get; set; } = String.Empty;

        public List<GleamVenue> GleamVenues { get; set; }
        //public Guid GleamVenueId { get; set; }
    }
}
