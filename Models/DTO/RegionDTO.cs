namespace NZWalks.API.Models.DTO
{
    public class RegionDTO
    {
        public Guid Id { get; set; }   //Guid is Globally Unique Identity

        public string Name { get; set; }

        public string Code { get; set; }

        public string? RegionImageUrl { get; set; } // '?' in 'string?' signifies that WalkImageUrl value can be null.
    }
}
