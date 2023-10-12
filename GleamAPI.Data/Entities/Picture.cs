using GleamAPI.Entities.Venue;

namespace GleamAPI.Entities
{
    public class Picture
    {
        public Guid PictureId { get; set; }

        public GleamVenue GleamVenue { get; set; }

        public Guid GleamVenueId { get; set; }




    }
}
