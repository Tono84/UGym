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
    public class MembersDALImpl : IMembersDAL
    {
        private UGymContext Context;
        private UnidadDeTrabajo<Member> unidad;

        public bool Add(Member entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Member>(new UGymContext()))
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

        public void AddRange(IEnumerable<Member> entidades)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> Find(Expression<Func<Member, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Member Get(int id)
        {
            Member entidad = null;
            using (unidad = new UnidadDeTrabajo<Member>(new UGymContext()))
            {
                entidad = unidad.genericDAL.Get(id);
            }

            return entidad;
        }

        public IEnumerable<Member> GetAll()
        {
            IEnumerable<Member> entidades = null;
            using (unidad = new UnidadDeTrabajo<Member>(new UGymContext()))
            {
                entidades = unidad.genericDAL.GetAll();
            }
            return entidades;
        }

        public bool Remove(Member entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Member>(new UGymContext()))
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

        public void RemoveRange(IEnumerable<Member> entidades)
        {
            throw new NotImplementedException();
        }

        public Member SingleOrDefault(Expression<Func<Member, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Member entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Member>(new UGymContext()))
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