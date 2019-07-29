using BaseApplication.BLL.ServiceImplementations;
using BaseApplication.SL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApplication.BLL
{
    /// <summary>
    /// Agente de servicios, sabe qué instancia devolver de acuerdo al contrato que se desea utilizar
    /// </summary>
    public static class ServiceAgent
    {
        /// <summary>
        /// Devuelve una instancia de ExaminadorMgr
        /// </summary>
        /// <returns></returns>
        public static IExaminadorManager GetExaminadorManager()
        {
            return new ServiceImplementations.ExaminadorManager();
        }

        public static IComunaManager GetComunaManager()
        {
            return new ServiceImplementations.ComunaManager();
        }
    }
}
