using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;
using Application.Dto;
using Application.Converters;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly ApplicationDbContext _context;

        public BuildingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<BuildingDto>> GetAllAsync()
        {
            var buildings = await _context.Buildings.ToListAsync();

            var dtoList = buildings.Select(b => BuildingConverter.ToBuildingDto(b)).ToList();

            return dtoList;
        }

        public async Task AddBuildingAsync(BuildingDto buildingDto)
        {
            Building building = BuildingConverter.ToBuilding(buildingDto);
            await _context.Buildings.AddAsync(building);
            await _context.SaveChangesAsync();
        }



    }
}