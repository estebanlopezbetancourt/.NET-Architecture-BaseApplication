using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApplication.BLL.ModelMapper
{
    /// <summary>
    /// Clase encarga de mapear Region dto-entity y viceversa
    /// </summary>
    internal class RegionMapper
    {
        public static SL.DTO.RegionDTO EntityToDto(DAL.Entities.Region entity)
        {
            SL.DTO.RegionDTO dto = new SL.DTO.RegionDTO();

            //dto = AutoMapper.Mapper.Map<DAL.Entities.Region, SL.DTO.RegionDTO>(entity);

            dto.Id = entity.Id;
            dto.RegionDescription = entity.RegionDescription;

            return dto;
        }
    }
}
