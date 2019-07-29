using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApplication.DAL.Core.IDao
{
    /// <summary>
    /// Contrato para el DAO de Comuna
    /// </summary>
    public interface IComunaDAO
    {
        /// <summary>
        /// Obtiene todas las comunas
        /// </summary>
        /// <returns>Colección de comunas</returns>
        IEnumerable<Entities.Comuna> GetAll();

        /// <summary>
        /// Obtiene todas las comunas que pertenezcan a la región especificada
        /// </summary>
        /// <param name="regionId">Id de la region</param>
        /// <returns>Colección de comunas encontradas</returns>
        IEnumerable<Entities.Comuna> GetByRegionId(int regionId);

        /// <summary>
        /// Permite crear una comuna
        /// </summary>
        /// <param name="comuna">comuna a crear</param>
        void Create(DAL.Entities.Comuna comuna);
    }
}
