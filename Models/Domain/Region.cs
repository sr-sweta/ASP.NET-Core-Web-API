namespace NZWalks.API.Models.Domain
{
    public class Region
    {
        public Guid Id { get; set; }   //Guid is Globally Unique Identity

        public string Name { get; set; }

        public string Code { get; set; }

        public string? RegionImageUrl { get; set; } // '?' in 'string?' signifies that WalkImageUrl value can be null.


    }
}
