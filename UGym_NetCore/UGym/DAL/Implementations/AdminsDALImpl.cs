using DAL.Interfaces;
using Entities.Entities;
using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class AdminsDALImpl : IAdminsDAL
    {
        private UGymContext Context;
        private UnidadDeTrabajo<Admin> unidad;

        public bool Add(Admin entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Admin>(new UGymContext()))
                {
                    unidad.genericDAL.Add(entidad);
                    unidad.Complete();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<Admin> entidades)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Admin> Find(Expression<Func<Admin, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Admin Get(int id)
        {
            Admin entidad = null;
            using (unidad = new UnidadDeTrabajo<Admin>(new UGymContext()))
            {
                entidad = unidad.genericDAL.Get(id);
            }

            return entidad;
        }

        public IEnumerable<Admin> GetAll()
        {
            IEnumerable<Admin> entidades = null;
            using (unidad = new UnidadDeTrabajo<Admin>(new UGymContext()))
            {
                entidades = unidad.genericDAL.GetAll();
            }
            return entidades;
        }

        public bool Remove(Admin entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Admin>(new UGymContext()))
                {
                    unidad.genericDAL.Remove(entidad);
                    unidad.Complete();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void RemoveRange(IEnumerable<Admin> entidades)
        {
            throw new NotImplementedException();
        }

        public Admin SingleOrDefault(Expression<Func<Admin, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Admin entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Admin>(new UGymContext()))
                {
                    unidad.genericDAL.Update(entidad);
                    unidad.Complete();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}