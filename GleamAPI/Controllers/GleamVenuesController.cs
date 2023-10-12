using GleamAPI.Data.ValueObjects;
using GleamAPI.Entities;
using GleamAPI.Entities.Venue;
using GleamAPI.Interfaces;
using GleamAPI.Models.Requests;
using GleamAPI.Models.Responses;
using GleamAPI.Models.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GleamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GleamVenuesController : ControllerBase
    {
        private readonly IGleamVenueRepository _gleamVenueRepository;
        private readonly IReviewRepository _reviewRepository;

        public GleamVenuesController(IGleamVenueRepository gleamVenueRepository, IReviewRepository reviewRepository)
        {
            _gleamVenueRepository = gleamVenueRepository;
            _reviewRepository = reviewRepository;
        }

        [HttpGet(Name = "GetAllGleamVenues")]
        public async Task<IActionResult> GetAllGleamVenues()
        {
            // Get gleam venue entities from DB
            var gleamvenues = await _gleamVenueRepository.GetGleamVenues();

            // Convert into response models
            // TODO: Replace with AutoMapper
            var response = gleamvenues.Select(x => new GleamVenueResponseModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Address = new AddressModel
                {
                    Street = x.Address.Street,
                    City = x.Address.City,
                    Latitude = x.Address.Latitude,
                    Longitude = x.Address.Longitude
                },
                SocialMedia = new SocialMediaModel
                {
                    FacebookLink = x.SocialMedia.FacebookLink,
                    InstagramHandle = x.SocialMedia.InstagramHandle,
                    TwitterHandle = x.SocialMedia.TwitterHandle,
                },

               

                //Reviews = new ReviewResponseModel
                //{
                //    Description = x.Description
                                                        
                //}
                PicturePath = x.PicturePath,

                Reviews = (from r in x.Reviews.OfType<Review>() where r.GleamVenueId == x.Id select r).ToList()

           
            });
             

            return new OkObjectResult(response);
        }


        [HttpGet("{id}", Name = "GetGleamVenueById")]
        public async Task<IActionResult> GetGleamVenueById([FromRoute][Required] Guid id)
        {
            if (id == Guid.Empty)
                return new BadRequestResult();

            // Get restaurant entity from DB
            var gleamvenues = await _gleamVenueRepository.GetGleamVenueById(id);

            if (gleamvenues == null)
                return new NotFoundResult();

            // Convert into response models
            // TODO: Replace with AutoMapper
            var response = new GleamVenueResponseModel
            {
                Id = gleamvenues.Id,
                Name = gleamvenues.Name,
                Description = gleamvenues.Description,
                Address = new AddressModel
                {
                    Street = gleamvenues.Address.Street,
                    City = gleamvenues.Address.City,
                    Latitude = gleamvenues.Address.Latitude,
                    Longitude = gleamvenues.Address.Longitude
                },
                SocialMedia = new SocialMediaModel
                {
                    FacebookLink = gleamvenues.SocialMedia.FacebookLink,
                    InstagramHandle = gleamvenues.SocialMedia.InstagramHandle,
                    TwitterHandle = gleamvenues.SocialMedia.TwitterHandle,
                },

                PicturePath = gleamvenues.PicturePath,
                Reviews = (from r in gleamvenues.Reviews.OfType<Review>() where r.GleamVenueId == gleamvenues.Id select r).ToList()
            };

            return new OkObjectResult(response);
        }


        [HttpPost(Name = "CreateGleamVenue")]
        public async Task<IActionResult> CreateGleamVenue(
            [FromBody][Required] GleamVenueRequestModel gleamVenueRequestModel)
        {
            // Convert into entity
            // TODO: Replace with AutoMapper
            var gleamVenue = new GleamVenue
            {
                Name = gleamVenueRequestModel.Name,
                Description = gleamVenueRequestModel.Description,
                Address = new Address
                {
                    Street = gleamVenueRequestModel.Address.Street,
                    Latitude = gleamVenueRequestModel.Address.Latitude,
                    Longitude = gleamVenueRequestModel.Address.Longitude
                },

                PicturePath = gleamVenueRequestModel.PicturePath
            };

            var newGleamVenue = await _gleamVenueRepository.CreateGleamVenue(gleamVenue);

            var location = $"/api/gleamvenues/{newGleamVenue.Id}";
            var createdResult = new CreatedResult(location, new GleamVenueResponseModel
            {
                Id = newGleamVenue.Id,
                Name = newGleamVenue.Name,
                Description = newGleamVenue.Description,
                Address = new AddressModel
                {
                    Street = newGleamVenue.Address.Street,
                    Longitude = newGleamVenue.Address.Longitude,
                    Latitude = newGleamVenue.Address.Latitude
                },

                PicturePath = newGleamVenue.PicturePath
               // Reviews = null
            });

            return createdResult;
        }

        [HttpDelete("{id}", Name = "DeleteGleamVenue")]
        public async Task<IActionResult> DeleteGleamVenue([FromRoute][Required] Guid id)
        {
            if (id == Guid.Empty)
                return new BadRequestResult();

            try
            {
                var result = await _gleamVenueRepository.DeleteGleamVenue(id);

                return
                    !result
                        ? new BadRequestResult()
                        : new NoContentResult();
            }
            catch
            {
                return new NotFoundResult();
            }
        }
    }
}
