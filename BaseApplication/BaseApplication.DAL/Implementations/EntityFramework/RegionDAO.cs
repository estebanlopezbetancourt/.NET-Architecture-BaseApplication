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
    internal class RegionDAO : BaseDAO, Core.IDao.IRegionDAO
    {
        /// <summary>
        /// Constructor pasa arg por parametro a constructor de la clase Base
        /// </summary>
        /// <param name="context"></param>
        public RegionDAO(Entities.SimceSampleDbConnection context) 
            : base(context) { }

        public IEnumerable<Entities.Region> GetAll()
        {
            return this.Context.Region;
        }
       
    }
}
