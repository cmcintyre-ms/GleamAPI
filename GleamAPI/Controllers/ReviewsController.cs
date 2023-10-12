using GleamAPI.Entities;
using GleamAPI.Interfaces;
using GleamAPI.Models.Requests;
using GleamAPI.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GleamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewsController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        // GET: api/<ReviewsController>
        [HttpGet]
        public async Task<IActionResult> GetAllReviews(Guid venueId)
        {
            var response = await _reviewRepository.GetAllReviews(venueId);

            var reviews = response.Select(x => new ReviewResponseModel
            {
                Id = x.Id,
                Description = x.Description,
                ReviewersEmail = x.ReviewersEmail
            });

            return new OkObjectResult(reviews);
        }

        // GET api/<ReviewsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ReviewsController>

        [HttpPost("{id}", Name = "PostNewReview")]
        public async Task<IActionResult> PostNewReview(
           [FromBody][Required] ReviewRequestModel reviewRequestModel, [FromRoute][Required] Guid id)
        {
            // Convert into entity
            // TODO: Replace with AutoMapper
            var gleamVenueReview = new Review
            {                 
                Description = reviewRequestModel.Description,
               ReviewersEmail = reviewRequestModel.ReviewersEmail
            };

            var newGleamVenueReview = await _reviewRepository.AddReview(gleamVenueReview, id);

            var location = $"/api/gleamvenues/{newGleamVenueReview.Id}";
            var createdResult = new CreatedResult(location, new ReviewResponseModel
            {
                Id = newGleamVenueReview.Id,            
                Description = newGleamVenueReview.Description,
               ReviewersEmail = newGleamVenueReview.ReviewersEmail
            });

            return createdResult;
        }


        //[HttpPost("{id}")]
        //public async Task<IActionResult> PostNewReview([FromRoute][Required] Guid id)

        //{
            

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var newReview = new Review();

        //    var revResp = new ReviewResponseModel();

        //    newReview = await _reviewRepository.AddReview(revResp, id);

        //    var response = new ReviewRequestModel
        //    {
        //        Description = newReview.Description,
        //        ReviewersEmail = newReview.ReviewersEmail
        //    };

        //    return new OkObjectResult(response);

        //}

        // PUT api/<ReviewsController>/5
        //[HttpPost("{id}")]
        //public void Post(int id, [FromBody] string value)
        //{

        //}

        // DELETE api/<ReviewsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
