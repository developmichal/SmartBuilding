using Domain.Entities;
using Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using Application.Dto;

namespace SmartBuilding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {

        private readonly IBuildingRepository _buildingRepository;

        // הזרקת התלות של ה-Repository
        public BuildingController(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingDto>>> GetBuilding()
        {
            var products = await _buildingRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<Building>> PostBuilding(BuildingDto buildingDto)
        {
            await _buildingRepository.AddBuildingAsync(buildingDto);
            return CreatedAtAction(nameof(GetBuilding), new { id = buildingDto.Id }, buildingDto);
        }
    }
}
