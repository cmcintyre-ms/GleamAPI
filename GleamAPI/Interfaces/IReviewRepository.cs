using GleamAPI.Entities;
using GleamAPI.Models.Requests;
using GleamAPI.Models.Responses;

namespace GleamAPI.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllReviews(Guid gleamVenueId);

        Task<Review?> GetReviewById(Guid id);

        Task<Review> AddReview(Review review, Guid venueId);

        Task<bool> DeleteReview(Guid id);
    }
}
