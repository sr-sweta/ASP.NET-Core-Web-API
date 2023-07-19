using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
    // Route value tells what will be the url
    // like here below you can see according to Regions Controller what will be the url
    // https://localhost:portnumber/api/Regions
    // and 'Controller' should be the suffix of the choosen name of the controller
    // Like here controller name is 'Regions'
    // So the naming convention of the API Controller is 'RegionsController'
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;

        public RegionsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Get all Regions
        // GET: https://localhost:portnumber/api/Regions
        [HttpGet]
        // In the below function 
        // Regions data from Domain is not directly given to user from database
        // rather first Doamin takes data from database and then it gives to the DTO
        // and then DTO passes the data to the user.
        // This help in preventing direct expose of database data and pass user only those data through the API 
        // which is needed. Here for this purpose DTO ( Data Transfer Objects ) is used
        public IActionResult GetAll()
        {
            // Get region domain model from database
            var regionsDomain = dbContext.Regions.ToList();

            // Creating list to store all regions from domain to dto objects
            var regionsDto = new List<RegionDTO>();

            foreach (var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDTO()
                {
                    Id = regionDomain.Id,
                    Name = regionDomain.Name,
                    Code = regionDomain.Code,
                    RegionImageUrl = regionDomain.RegionImageUrl
                });
            }

            // return Regions list from DTO
            return Ok(regionsDto);
        }

        // Get single Region with provided ID (If Available)
        // GET: https://localhost:portnumber/api/Regions/{id}
        [HttpGet]
        // In below line routing will be done as per provided id
        // 'Guid' in this line signifies the type of 'id'
        [Route("{id:Guid}")]
        // [FromRoute] says that the input will be from router
        public IActionResult GetById([FromRoute] Guid id)
        {
            // Get data from database - domain model
            var regionDomain = dbContext.Regions.Find(id);

            // Below commented statement is other way to get the same id region
            // var region = dbContext.Regions.FirstOrDefault(x => x.Id == id);


            if (regionDomain == null)
            {
                return NotFound();
            }

            // Map/Convert Region Domain Model to Region DTO
            var regionDto = new RegionDTO()
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            // return Region DTO 
            return Ok(regionDto);
        }

        // Create Region form user's end and return the created Region details with a location url where
        // the value can be found.
        // POST: https://localhost:portnumber/api/Regions
        [HttpPost]

        public IActionResult Create([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {
            // Creating Region Domain Model to pass it to database for Region creation
            // Data passed from DTO to Domain
            var regionDomainModel = new Region()
            {
                Name = addRegionRequestDTO.Name,
                Code = addRegionRequestDTO.Code,
                RegionImageUrl = addRegionRequestDTO.RegionImageUrl
            };

            //  Adding a new entity just means to tell the context to start tracking that now
            dbContext.Regions.Add(regionDomainModel);
            // Saves all changes made in this context to the underlying database
            dbContext.SaveChanges();

            // Take the newly created Region data from Domain to DTO for passing it to user.
            var regionDto = new RegionDTO()
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl

            };

            // CreatedAtAction method provides more support in generating URI for the Location header.
            // this method allows us to set Location URI of the newly created resource by
            // specifying the name of an action where we can retrieve our resource.
            return CreatedAtAction(nameof(GetById), new {id = regionDto.Id}, regionDto);
        }


        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody]  UpdateRegion updateRegion)
        {
            var regionDomain = dbContext.Regions.Find(id);

            if (regionDomain == null)
            {
                return NotFound();
            }            

            regionDomain.Name = updateRegion.Name;
            regionDomain.Code = updateRegion.Code;
            regionDomain.RegionImageUrl = updateRegion.RegionImageUrl;

            dbContext.Regions.Update(regionDomain);
            dbContext.SaveChanges();

            return Ok(updateRegion);
        }
        
        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var regionDomain = dbContext.Regions.Find(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            dbContext.Regions.Remove(regionDomain);
            dbContext.SaveChanges();

            return Ok();
        }
        

    }
}
