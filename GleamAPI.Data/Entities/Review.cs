using GleamAPI.Entities.Venue;
using System.Text.Json.Serialization;

namespace GleamAPI.Entities
{
    public class Review
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Description { get; set; }

        public string ReviewersEmail { get; set; }

        // Foreign Key to GleamVenue parent entity
        public Guid GleamVenueId { get; set; }

      //  [JsonIgnore]
       // Reference to entity - this won't be stored in the database
        //public GleamVenue GleamVenue { get; set; }

        #region Original
        //public Guid ReviewId { get; set; }     

        //public string Title { get; set; } = String.Empty;

        //public string Body { get; set; } = String.Empty;

        //public DateTime Date { get; set; }

        //public int Rating { get; set; } // need to make sure this is only between one and five
        ////use data annotations

        //public GleamVenue GleamVenue { get; set; }

        //public Guid GleamVenueId { get; set; }

        #endregion

    }


}


