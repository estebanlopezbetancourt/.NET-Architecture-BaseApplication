using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApplication.DAL.Implementations.EntityFramework
{
    /// <summary>
    /// Base class used to manage a same db context through different Data Access Objects
    /// </summary>
    public abstract class BaseDAO
    {
        public BaseDAO(Entities.SimceSampleDbConnection context)
        {
            this.Context = context;
        }

        protected Entities.SimceSampleDbConnection Context;
    }
}
