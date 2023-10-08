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
    public class EmployeesDALImpl : IEmployeesDAL
    {
        private UGymContext Context;
        private UnidadDeTrabajo<Employee> unidad;

        public bool Add(Employee entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Employee>(new UGymContext()))
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

        public void AddRange(IEnumerable<Employee> entidades)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Find(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Employee Get(int id)
        {
            Employee entidad = null;
            using (unidad = new UnidadDeTrabajo<Employee>(new UGymContext()))
            {
                entidad = unidad.genericDAL.Get(id);
            }

            return entidad;
        }

        public IEnumerable<Employee> GetAll()
        {
            IEnumerable<Employee> entidades = null;
            using (unidad = new UnidadDeTrabajo<Employee>(new UGymContext()))
            {
                entidades = unidad.genericDAL.GetAll();
            }
            return entidades;
        }

        public bool Remove(Employee entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Employee>(new UGymContext()))
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

        public void RemoveRange(IEnumerable<Employee> entidades)
        {
            throw new NotImplementedException();
        }

        public Employee SingleOrDefault(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Employee entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Employee>(new UGymContext()))
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