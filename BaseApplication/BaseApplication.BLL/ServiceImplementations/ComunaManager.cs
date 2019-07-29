using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApplication.BLL.ServiceImplementations
{
    internal class ComunaManager : SL.Services.IComunaManager
    {
        private DAL.Core.DataAccess dateAccess;

        public ComunaManager()
        {
            this.dateAccess = new DAL.Core.DataAccess();
        }


        public IEnumerable<SL.DTO.ComunaDTO> GetComunaCollection()
        {
            IList<SL.DTO.ComunaDTO> comunaCollection = new List<SL.DTO.ComunaDTO>();
            
            var comunas = this.dateAccess.ComunaDAO.GetAll();

            foreach (var item in comunas)
            {
                var dto = ModelMapper.ComunaMapper.EntityToDto(item);
                comunaCollection.Add(dto);
            }

            return comunaCollection;

        }

        public void CreateComuna(SL.DTO.ComunaDTO comunaDto)
        {
            var entity = ModelMapper.ComunaMapper.DtoToEntity(comunaDto);
            this.dateAccess.ComunaDAO.Create(entity);
        }
    }
}
