using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApplication.BLL.ModelMapper
{
    /// <summary>
    /// Clase encarga de mapear Examinador dto-entity y viceversa
    /// </summary>
    internal class ExaminadorMapper
    {
        public static SL.DTO.ExaminadorDTO EntityToDto(DAL.Entities.Examinador entity)
        {
            SL.DTO.ExaminadorDTO dto = new SL.DTO.ExaminadorDTO();

            //dto = AutoMapper.Mapper.Map<DAL.Entities.Examinador, SL.DTO.ExaminadorDTO>(entity);

            dto.Id = entity.Id;
            dto.Rut = entity.Rut;
            dto.RutDv = entity.RutDv;
            dto.Name = entity.Name;
            dto.LastName = entity.LastName;
            dto.Birthdate = entity.Birthdate;
            dto.Sex = entity.Sex;
            dto.Cellphone = entity.Cellphone;
            dto.PaymentAmount = entity.PaymentAmount;
            dto.Address = entity.Address;
            dto.ComunaId = entity.ComunaId;
            dto.Email = entity.Email;

            return dto;
        }

        public static DAL.Entities.Examinador DtoToEntity(SL.DTO.ExaminadorDTO dto)
        {
            DAL.Entities.Examinador entity = new DAL.Entities.Examinador();

            //entity = AutoMapper.Mapper.Map<SL.DTO.ExaminadorDTO, DAL.Entities.Examinador>(dto);

            entity.Id = dto.Id;
            entity.Rut = dto.Rut;
            entity.RutDv = dto.RutDv;
            entity.Name = dto.Name;
            entity.LastName = dto.LastName;
            entity.Birthdate = dto.Birthdate;
            entity.Sex = dto.Sex;
            entity.Cellphone = dto.Cellphone;
            entity.PaymentAmount = dto.PaymentAmount;
            entity.Address = dto.Address;
            entity.ComunaId = dto.ComunaId;
            entity.Email = dto.Email;

            return entity;
        }

        
    }
}
