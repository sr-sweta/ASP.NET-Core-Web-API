namespace NZWalks.API.Models.DTO
{
    public class AddRegionRequestDTO
    {
        // ID will be automatically created by server as it is Guid

        public string Name { get; set; }

        public string Code { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
