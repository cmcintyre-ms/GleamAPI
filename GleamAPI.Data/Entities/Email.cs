namespace GleamAPI.Entities.Venue
{
    public class Email
    {
        public Guid EmailId { get; set; }

        public string EmailAddress { get; set; }

        public Guid GleamVenueId { get; set; }

        public GleamVenue GleamVenue { get; set; }
        
    }
}