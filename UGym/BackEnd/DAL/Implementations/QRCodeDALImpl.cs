using BackEnd.DAL.interfaces;
using BackEnd.Areas.Identity.Data;
using BackEnd.Data;
using BackEnd.DAL.Implementations;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL.Implementations
{
    public class QRCodeDALImpl : IQRCodeDAL
    {
        private UGymContext Context;
        private WorkUnit<Qrcode> unidad;

        public bool Add(Qrcode entidad)
        {
            try
            {
                using (unidad = new WorkUnit<Qrcode>(new UGymContext()))
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

        public void AddRange(IEnumerable<Qrcode> entidades)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Qrcode> Find(Expression<Func<Qrcode, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Qrcode Get(int id)
        {
            Qrcode entidad = null;
            using (unidad = new WorkUnit<Qrcode>(new UGymContext()))
            {
                entidad = unidad.genericDAL.Get(id);
            }

            return entidad;
        }

        public IEnumerable<Qrcode> GetAll()
        {
            IEnumerable<Qrcode> entidades = null;
            using (unidad = new WorkUnit<Qrcode>(new UGymContext()))
            {
                entidades = unidad.genericDAL.GetAll();
            }
            return entidades;
        }

        public bool Remove(Qrcode entidad)
        {
            try
            {
                using (unidad = new WorkUnit<Qrcode>(new UGymContext()))
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

        public void RemoveRange(IEnumerable<Qrcode> entidades)
        {
            throw new NotImplementedException();
        }

        public Qrcode SingleOrDefault(Expression<Func<Qrcode, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Qrcode entidad)
        {
            try
            {
                using (unidad = new WorkUnit<Qrcode>(new UGymContext()))
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