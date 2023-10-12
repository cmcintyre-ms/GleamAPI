using GleamAPI.Entities;
using GleamAPI.Repositories;

namespace GleamAPI.GraphQL.Reviews
{
    [ExtendObjectType("Mutation")]
    public class ReviewMutations
    {
        public record AddReviewPayload(Review Review);

        public async Task<AddReviewPayload> CreateNewReview([Service] ReviewRepository reviewRepository,    
             string description, string reviewerEmail, Guid venueID)
        {
            var review = new Review
            {
                Id = Guid.NewGuid(),
                Description = description,
                ReviewersEmail = reviewerEmail,
                GleamVenueId = venueID
            };

            await reviewRepository.AddReview(review, venueID);

            return new AddReviewPayload(review);
        }
    }
}
