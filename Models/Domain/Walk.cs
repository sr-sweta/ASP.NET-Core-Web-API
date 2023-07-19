namespace NZWalks.API.Models.Domain
{
    public class Walk
    {
        // Type prop and enter tab twice to get property directly

        public Guid Id { get; set; }     //Guid is Globally Unique Identity 

        public string Name { get; set; }

        public string Description { get; set; }

        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }   // '?' in 'string?' signifies that WalkImageUrl value can be null.

        public Guid DifficultyId { get; set; }

        public Guid RegionId { get; set; }



        // Navigation Properties

        public Difficulty Difficulty { get; set; }

        public Region Region { get; set; }
    }
}
