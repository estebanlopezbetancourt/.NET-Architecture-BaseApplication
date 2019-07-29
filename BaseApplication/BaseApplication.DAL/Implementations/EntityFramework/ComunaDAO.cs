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
    internal class ComunaDAO : BaseDAO, Core.IDao.IComunaDAO
    {
        /// <summary>
        /// Constructor pasa arg por parametro a constructor de la clase Base
        /// </summary>
        /// <param name="context"></param>
        public ComunaDAO(Entities.SimceSampleDbConnection context) 
            : base(context) { }

        public IEnumerable<Entities.Comuna> GetAll()
        {
            return this.Context.Comuna;
        }

        public IEnumerable<Entities.Comuna> GetByRegionId(int regionId)
        {
            return this.Context.Comuna.Where(x => x.RegionId == regionId);
        }


        public void Create(Entities.Comuna comuna)
        {
            this.Context.Comuna.Add(comuna);
            this.Context.SaveChanges();
        }
    }
}
