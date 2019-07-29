using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApplication.DAL.Core.IDao
{
    /// <summary>
    /// Contrato para el DAO de Examinador
    /// </summary>
    public interface IExaminadorDAO
    {
        /// <summary>
        /// Obtiene todos los examinadores de la colección
        /// </summary>
        /// <returns>Colección de examinadores</returns>
        IEnumerable<Entities.Examinador> GetAll();

        /// <summary>
        /// Obtiene un Examinador específico según su identificador
        /// </summary>
        /// <param name="id">ID del Examinador</param>
        /// <returns>entidad de examinador encontrado</returns>
        Entities.Examinador GetById(int id);

        /// <summary>
        /// Obtiene un Examinador por Rut
        /// </summary>
        /// <param name="rut">rut del Examinador</param>
        /// <returns>entidad de examinador encontrado</returns>
        Entities.Examinador GetByRut(int rut);

        /// <summary>
        /// Permite Crear (persistir) una nueva entidad de Examinador
        /// </summary>
        /// <param name="entity">entidad a crear</param>
        /// <returns>entidad creada con ID asignado</returns>
        Entities.Examinador Create(Entities.Examinador entity);

        /// <summary>
        /// Actualiza una entidad que ya existe en el modelo
        /// </summary>
        /// <param name="entity">entidad a actualizar</param>
        /// <returns>la entidad ya actualizada</returns>
        Entities.Examinador Update(Entities.Examinador entity);

        /// <summary>
        /// Elimina un examinador según su ID
        /// </summary>
        /// <param name="id">Id de la entidad a eliminar</param>
        void Remove(int id);
    }
}
