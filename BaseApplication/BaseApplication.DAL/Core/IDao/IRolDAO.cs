using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApplication.DAL.Core.IDao
{
    /// <summary>
    /// Contrato para el DAO de Rol
    /// </summary>
    public interface IRolDAO
    {
        /// <summary>
        /// Obtiene todas los roles
        /// </summary>
        /// <returns>Colección de roles</returns>
        IEnumerable<Entities.Rol> GetAll();

        /// <summary>
        /// Obtiene los roles a los que está asociado un examinador
        /// </summary>
        /// <param name="id">Id del examinador</param>
        /// <returns>Colección de roles encontrados</returns>
        IEnumerable<Entities.Rol> GetByExaminadorId(int id);
    }
}
