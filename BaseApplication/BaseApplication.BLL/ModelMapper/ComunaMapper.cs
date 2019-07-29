using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApplication.BLL.ModelMapper
{
    /// <summary>
    /// Clase encarga de mapear Comuna dto-entity y viceversa
    /// </summary>
    internal class ComunaMapper
    {
        public static SL.DTO.ComunaDTO EntityToDto(DAL.Entities.Comuna entity)
        {
            SL.DTO.ComunaDTO dto = new SL.DTO.ComunaDTO();

            //dto = AutoMapper.Mapper.Map<DAL.Entities.Comuna, SL.DTO.ComunaDTO>(entity);

            dto.Id = entity.Id;
            dto.ComunaDescription = entity.ComunaDescription;
            dto.RegionId = entity.RegionId;

            return dto;
        }

        public static DAL.Entities.Comuna DtoToEntity(SL.DTO.ComunaDTO dto)
        {
            DAL.Entities.Comuna entity = new DAL.Entities.Comuna();

            //dto = AutoMapper.Mapper.Map<DAL.Entities.Comuna, SL.DTO.ComunaDTO>(entity);
            entity.Id = dto.Id;
            entity.ComunaDescription = dto.ComunaDescription;
            entity.RegionId = dto.RegionId;

            return entity;
        }
    }
}
