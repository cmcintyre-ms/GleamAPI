using GleamAPI.Data;
using GleamAPI.Entities;
using GleamAPI.Interfaces;
using GleamAPI.Models.Requests;
using GleamAPI.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace GleamAPI.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _dbContext;

        public ReviewRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Review>> GetAllReviews(Guid gleamvenueId)
        {
            return await _dbContext!.Reviews!.Where(x => x.GleamVenueId.Equals(gleamvenueId)).ToListAsync();
        }

        public async Task<Review?> GetReviewById(Guid id)
        {
            return await _dbContext!.Reviews!.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Review> AddReview(Review review, Guid venueId)
        {
            //var venue = await _dbContext.Reviews.FirstOrDefaultAsync(x => x.GleamVenueId == venueId);

            var response = new Review
            {
                //Id = new Guid(),
                Description = review.Description,
                ReviewersEmail = review.ReviewersEmail,
                GleamVenueId = venueId
            };

            await _dbContext!.Reviews!.AddAsync(response);

            await _dbContext!.SaveChangesAsync();

            return response;
        }

        public async Task<bool> DeleteReview(Guid id)
        {
            var reviewToRemove = await GetReviewById(id);

            if (reviewToRemove == null)
                throw new Exception($"Entity {id} cannot be found");

            _dbContext!.Reviews!.Remove(reviewToRemove);

            var result = await _dbContext.SaveChangesAsync();

            return result == 1;
        }
    }
}
