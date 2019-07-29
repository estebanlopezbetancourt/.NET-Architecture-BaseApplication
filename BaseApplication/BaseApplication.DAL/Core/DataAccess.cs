using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApplication.DAL.Core
{
    /// <summary>
    /// Puerta de entrada a la capa de acceso a datos. 
    /// Tiene la responsabilidad de instanciar y devolver las clases de acceso a datos requeridas, 
    /// de acuerdo a los contratos que para ellas se han definido en el Core de la DAL
    /// </summary>
    public class DataAccess : IDisposable
    {
        //definimos como miembros privados los DAO, DataService, contextos, etc.
        private Entities.SimceSampleDbConnection context;
        private IDao.IExaminadorDAO examinadorDAO;
        private IDao.IRolDAO rolDAO;
        private IDao.IComunaDAO comunaDAO;
        private IDao.IRegionDAO regionDAO;


        /// <summary>
        /// Constructor de la clase, instanciamos el contexto que compartiremos entre los objetos de acceso a datos (dao)
        /// </summary>
        public DataAccess()
        {
            this.context = new Entities.SimceSampleDbConnection();
        }


        private bool disposed = false;
        /// <summary>
        /// Implementación del método Dispose (contrato IDisposable)
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Instancia de clase que implementa IExaminadorDAO
        /// </summary>
        public IDao.IExaminadorDAO ExaminadorDAO { 
            get 
            {
                //revisamos si ya existe una instancia del DAO, sino, se instancia un nuevo dao y se guarda como miembro privado, 
                //la próxima vez que se use (desde la misma instancia de DataAccess) usaremos la misma propiedad ya instanciada del DAO
                if (this.examinadorDAO == null)
                    this.examinadorDAO = new Implementations.EntityFramework.ExaminadorDAO(this.context);
                return this.examinadorDAO;
            } 
        }

        /// <summary>
        /// Instancia de clase que implementa IComunaDAO
        /// </summary>
        public IDao.IComunaDAO ComunaDAO
        {
            get
            {
                if (this.comunaDAO == null)
                    this.comunaDAO = new Implementations.EntityFramework.ComunaDAO(this.context);
                return this.comunaDAO;
            }
        }

        /// <summary>
        /// Instancia de clase que implementa IComunaDAO
        /// </summary>
        public IDao.IRegionDAO RegionDAO
        {
            get
            {
                if (this.regionDAO == null)
                    this.regionDAO = new Implementations.EntityFramework.RegionDAO(this.context);
                return this.regionDAO;
            }
        }

        /// <summary>
        /// Instancia de clase que implementa IComunaDAO
        /// </summary>
        public IDao.IRolDAO RolDAO
        {
            get
            {
                if (this.rolDAO == null)
                    this.rolDAO = new Implementations.EntityFramework.RolDAO(this.context);
                return this.rolDAO;
            }
        }
        
    }
}
