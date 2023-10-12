using GleamAPI.Data;
using GleamAPI.Data.ValueObjects;
using GleamAPI.Entities.Venue;
using GleamAPI.Repositories;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace GleamAPI.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class GleamVenueMutations
    {
        public record AddVenuePayload(GleamVenue Venue);

        public async Task<AddVenuePayload> CreateNewVenue([Service] GleamVenueRepository VenueRepository,
            [Service] ITopicEventSender eventSender, GleamVenue venue)
        {
            await VenueRepository.CreateGleamVenue(venue);

            return new AddVenuePayload(venue);
        }
                
    }
}
