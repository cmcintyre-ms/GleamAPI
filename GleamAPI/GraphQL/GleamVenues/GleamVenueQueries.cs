using GleamAPI.Data;
using GleamAPI.Entities.Venue;
using Microsoft.EntityFrameworkCore;
using HotChocolate;
using System.Threading.Tasks;
using GleamAPI.Repositories;
using HotChocolate.Subscriptions;
using System;
using HotChocolate.Resolvers;

namespace GleamAPI.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class GleamVenueQueries
    {
        
        public async Task<IEnumerable<GleamVenue>> GetAllGleamVenues([SchemaService] IResolverContext context, [Service] GleamVenueRepository venueRepository)
        {
            return await venueRepository.GetGleamVenues();
        }

        public async Task<GleamVenue?> GetVenueById([Service] GleamVenueRepository venueRepository, [Service] ITopicEventSender eventSender,
            Guid id)
        {
            GleamVenue? venue = await venueRepository.GetGleamVenueById(id);
            await eventSender.SendAsync("ReturnedVenue", venue);
            return venue;
        }

        public async Task<IEnumerable<GleamVenue>> FilterByCity([Service] GleamVenueRepository venueRepository, string city)
        {
            return await venueRepository.GetVenuesByCity(city);
            
        }
    }
}
