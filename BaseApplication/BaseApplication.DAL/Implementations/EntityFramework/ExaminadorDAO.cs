using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApplication.DAL.Implementations.EntityFramework
{
    /// <summary>
    /// Clase que implementa la interfaz IExaminadorDAO usando EntityFramework
    /// </summary>
    internal class ExaminadorDAO : BaseDAO, Core.IDao.IExaminadorDAO
    {
        /// <summary>
        /// Constructor pasa arg por parametro a constructor de la clase Base
        /// </summary>
        /// <param name="context"></param>
        public ExaminadorDAO(Entities.SimceSampleDbConnection context) 
            : base(context) { }

        public IEnumerable<Entities.Examinador> GetAll()
        {
            return this.Context.Examinador;
        }

        public Entities.Examinador GetById(int id)
        {
            return this.Context.Examinador.First(x => x.Id == id);
        }

        public Entities.Examinador GetByRut(int rut)
        {
            return this.Context.Examinador.First(x => x.Rut == rut);
        }

        public Entities.Examinador Create(Entities.Examinador entity)
        {
            entity = this.Context.Examinador.Add(entity);
            this.Context.SaveChanges();
            return entity;
        }

        public Entities.Examinador Update(Entities.Examinador entity)
        {
            //this.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;

            #region Old way to do it
            var entityFromDb = this.Context.Examinador.First(x => x.Id == entity.Id);
            entityFromDb.Name = entity.Name;
            entityFromDb.LastName = entity.LastName;
            entityFromDb.PaymentAmount = entity.PaymentAmount;
            entityFromDb.Sex = entityFromDb.Sex;
            entityFromDb.ComunaId = entity.ComunaId;
            entityFromDb.Email = entity.Email;
            entityFromDb.Cellphone = entity.Cellphone;
            entityFromDb.Address = entity.Address;
            entityFromDb.Birthdate = entity.Birthdate;
            #endregion

            this.Context.SaveChanges();

            return entity;
        }

        public void Remove(int id)
        {
            var entityToRemove = this.Context.Examinador.First(x => x.Id == id);
            this.Context.Examinador.Remove(entityToRemove);
            this.Context.SaveChanges();
        }
    }
}
