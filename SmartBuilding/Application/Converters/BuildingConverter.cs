using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Converters
{
    public class BuildingConverter
    {
        public static Dto.BuildingDto ToBuildingDto(Building building)
        {
            Dto.BuildingDto newBuilding = new Dto.BuildingDto();
            newBuilding.Id = building.Id;
            newBuilding.Name = building.Name;
            newBuilding.Address = building.Address;
            return newBuilding;
        }
        public static Building ToBuilding(Dto.BuildingDto buildingDto)
        {
            Building newBuilding = new Building();
            newBuilding.Name = buildingDto.Name;
            newBuilding.Address = buildingDto.Address;
            return newBuilding;
        }
        public static List<Dto.BuildingDto> ToListBuildingDto(List<Building> listBuildingDto)
        {
            List<Dto.BuildingDto> newlistCategory = new List<Dto.BuildingDto>();
            foreach (Building building in listBuildingDto)
            {
                newlistCategory.Add(ToBuildingDto(building));
            }
            return newlistCategory;
            ;
        }
    }
}
