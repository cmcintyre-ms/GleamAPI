using GleamAPI.Entities.Venue;

namespace GleamAPI.Interfaces
{
    public interface IGleamVenueRepository
    {
        public Task<IEnumerable<GleamVenue>> GetGleamVenues();

        public Task<GleamVenue> GetGleamVenueById(Guid id);

        // public Task<List<GleamVenue>> GetGleamVenuesByName(string venueName);

        public Task<GleamVenue> CreateGleamVenue(GleamVenue gleamvenue);//DTO to add

        Task<bool> DeleteGleamVenue(Guid id);

    }
}
