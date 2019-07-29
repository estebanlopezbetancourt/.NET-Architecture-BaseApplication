using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApplication.DAL.Implementations.EntityFramework
{
    /// <summary>
    /// Clase que implementa la interfaz IRolDAO usando EntityFramework
    /// </summary>
    internal class RolDAO : BaseDAO, Core.IDao.IRolDAO
    {
        /// <summary>
        /// Constructor pasa arg por parametro a constructor de la clase Base
        /// </summary>
        /// <param name="context"></param>
        public RolDAO(Entities.SimceSampleDbConnection context) 
            : base(context) { }

        public IEnumerable<Entities.Rol> GetAll()
        {
            return this.Context.Rol;
        }

        public IEnumerable<Entities.Rol> GetByExaminadorId(int id)
        {
            return this.Context.ExaminadorRol.Include("Rol").Where(x => x.ExaminadorId == id).Select(x => x.Rol);
        }

        
    }
}
