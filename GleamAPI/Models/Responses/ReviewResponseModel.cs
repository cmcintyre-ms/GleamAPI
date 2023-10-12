namespace GleamAPI.Models.Responses
{
    using AutoMapper;
    using GleamAPI.Entities;
    using GleamAPI.Mappings;


    public class ReviewResponseModel 
        //: IMapFrom<Review>
    {
        public Guid Id { get; set; }

        public Guid GleamVenueId { get; set; }

        public string Description { get; set; }

        public string ReviewersEmail { get; set; }

        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<Review, ReviewResponseModel>()
        //        .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
        //        .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
        //        .ForMember(d => d.ReviewersEmail, opt => opt.MapFrom(s => s.ReviewersEmail));
        //}
    }
}

