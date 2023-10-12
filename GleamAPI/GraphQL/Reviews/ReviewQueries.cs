using GleamAPI.Entities;
using GleamAPI.Repositories;

namespace GleamAPI.GraphQL.Reviews
{
    [ExtendObjectType("Query")]
    public class ReviewQueries
    {
        public async Task<IEnumerable<Review>> GetReviewsAsync([Service] ReviewRepository reviewRepository, Guid gleamVenueId)
        {
            return await reviewRepository.GetAllReviews(gleamVenueId);
        }
    }
}
