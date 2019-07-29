using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApplication.BLL.ServiceImplementations
{
    internal class ExaminadorManager : SL.Services.IExaminadorManager
    {
        private DAL.Core.DataAccess dataAccess;

        public ExaminadorManager()
        {
            //instanciamos nuestro dataAccess que será compartido en esta llamada por este mgr
            this.dataAccess = new DAL.Core.DataAccess();
        }

        public IEnumerable<SL.DTO.ExaminadorDTO> GetExaminadoresCollection()
        {
            IList<SL.DTO.ExaminadorDTO> examinadorCollection = new List<SL.DTO.ExaminadorDTO>();

            //primero manejamos una colección que representa a todos los elementos de la bd para Examinador
            var examinadores = this.dataAccess.ExaminadorDAO.GetAll();

            //obtenemos y cargamos el listado de comunas para el mapeo
            var comunas = this.dataAccess.ComunaDAO.GetAll().ToList();

            //mapeamos los elementos de entidad a dto
            foreach (var entity in examinadores)
            {
                var dto = ModelMapper.ExaminadorMapper.EntityToDto(entity);
                dto.ComunaDescription = comunas.First(x => x.Id == dto.ComunaId).ComunaDescription;

                examinadorCollection.Add(dto);
            }

            //retornamos la colección
            return examinadorCollection;
        }

        public SL.DTO.ExaminadorDTO GetExaminadorById(int id)
        {
            var entity = this.dataAccess.ExaminadorDAO.GetById(id);
            var dto = ModelMapper.ExaminadorMapper.EntityToDto(entity);
            dto.ComunaDescription = this.dataAccess.ComunaDAO.GetAll().First(x => x.Id == entity.ComunaId).ComunaDescription;

            return dto;
        }
        public IEnumerable<SL.DTO.ExaminadorDTO> GetExaminadoresByFilter(SL.DTO.ExaminadorFilterDTO filterDto)
        {
            IList<SL.DTO.ExaminadorDTO> examinadorCollection = new List<SL.DTO.ExaminadorDTO>();

            //primero manejamos una colección que representa a todos los elementos de la bd para Examinador
            var examinadores = this.dataAccess.ExaminadorDAO.GetAll();


            //aplicamos los filtros
            if (filterDto.Rut.GetValueOrDefault() != 0)
                examinadores = examinadores.Where(x => x.Rut == filterDto.Rut);

            if (!string.IsNullOrEmpty(filterDto.Name))
                examinadores = examinadores.Where(x => x.Name.ToLower().Contains(filterDto.Name.ToLower()));

            if (!string.IsNullOrEmpty(filterDto.LastName))
                examinadores = examinadores.Where(x => x.LastName.ToLower().Contains(filterDto.LastName.ToLower()));

            if (examinadores != null && examinadores.Any())
            {
                //obtenemos y cargamos el listado de comunas para el mapeo
                var comunas = this.dataAccess.ComunaDAO.GetAll().ToList();

                //mapeamos los elementos de entidad a dto
                foreach (var entity in examinadores)
                {
                    var dto = ModelMapper.ExaminadorMapper.EntityToDto(entity);
                    dto.ComunaDescription = comunas.First(x => x.Id == dto.ComunaId).ComunaDescription;

                    examinadorCollection.Add(dto);
                }
            }

            //retornamos la colección
            return examinadorCollection;
        }

        public void RemoveExaminador(int examinadorId)
        {
            //eliminamos a través de la DAL
            this.dataAccess.ExaminadorDAO.Remove(examinadorId);
        }

        public void AddExaminador(SL.DTO.ExaminadorDTO examinadorDto)
        {
            //mapeamos
            var entity = ModelMapper.ExaminadorMapper.DtoToEntity(examinadorDto);

            //creamos a través de la DAL
            this.dataAccess.ExaminadorDAO.Create(entity);

        }

        public void UpdateExaminador(SL.DTO.ExaminadorDTO examinadorDto)
        {
            //mapeamos
            var entity = ModelMapper.ExaminadorMapper.DtoToEntity(examinadorDto);

            //actualizamos a través de la DAL
            this.dataAccess.ExaminadorDAO.Update(entity);
        }

        public IEnumerable<SL.DTO.RegionDTO> GetRegionCollection()
        {
            IList<SL.DTO.RegionDTO> regionCollection = new List<SL.DTO.RegionDTO>();

            //primero manejamos una colección que representa a todos los elementos de la bd para Region
            var regiones = this.dataAccess.RegionDAO.GetAll();

            //mapeamos
            foreach (var entity in regiones)
            {
                var dto = ModelMapper.RegionMapper.EntityToDto(entity);
                regionCollection.Add(dto);
            }

            //retornamos la colección
            return regionCollection;
        }

        public IEnumerable<SL.DTO.ComunaDTO> GetComunaCollection()
        {
            IList<SL.DTO.ComunaDTO> comunaCollection = new List<SL.DTO.ComunaDTO>();

            //primero manejamos una colección que representa a todos los elementos de la bd para Examinador
            var comunas = this.dataAccess.ComunaDAO.GetAll();

            //primero manejamos una colección que representa a todos los elementos de la bd para Region
            foreach (var entity in comunas)
            {
                var dto = ModelMapper.ComunaMapper.EntityToDto(entity);
                comunaCollection.Add(dto);
            }

            //retornamos la colección
            return comunaCollection;
        }
        public IEnumerable<SL.DTO.ComunaDTO> GetComunasByRegionId(int regionId)
        {
            IList<SL.DTO.ComunaDTO> comunaCollection = new List<SL.DTO.ComunaDTO>();

            //primero manejamos una colección que representa a todos los elementos de la bd para Examinador
            var comunas = this.dataAccess.ComunaDAO.GetByRegionId(regionId);

            //primero manejamos una colección que representa a todos los elementos de la bd para Region
            foreach (var entity in comunas)
            {
                var dto = ModelMapper.ComunaMapper.EntityToDto(entity);
                comunaCollection.Add(dto);
            }

            //retornamos la colección
            return comunaCollection;
        }


    }
}
