using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApplication.DAL.Core.IDao
{
    /// <summary>
    /// Contrato para el DAO de Region
    /// </summary>
    public interface IRegionDAO
    {
        /// <summary>
        /// Obtiene todas las regiones
        /// </summary>
        /// <returns>Colección de regiones</returns>
        IEnumerable<Entities.Region> GetAll();
    }
}
