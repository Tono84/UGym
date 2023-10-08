using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : Controller
    {
        private IMembersDAL entidadDAL;

        private MembersModel Convertir(Member entidad)
        {
            return new MembersModel
            {
                MemberId = entidad.MemberId,
                MemberNumb = entidad.MemberNumb,
                Password = entidad.Password,
                FullName = entidad.FullName,
                Gender = entidad.Gender,
                Cedula = entidad.Cedula,
                Birthday = entidad.Birthday,
                Ocupation = entidad.Ocupation,
                KnowGym = entidad.KnowGym,
                Motivation = entidad.Motivation,
                Email = entidad.Email,
                Address = entidad.Address,
                MobileNumber = entidad.MobileNumber,
                EmergencyContactId = entidad.EmergencyContactId,
                MembFileId = entidad.MembFileId,
                QrcodeId = entidad.QrcodeId,
                EmployeeId = entidad.QrcodeId,
                RoleId = entidad.RoleId
            };
        }

        private Member Convertir(MembersModel entidad)
        {
            return new Member
            {
                MemberId = entidad.MemberId,
                MemberNumb = entidad.MemberNumb,
                Password = entidad.Password,
                FullName = entidad.FullName,
                Gender = entidad.Gender,
                Cedula = entidad.Cedula,
                Birthday = entidad.Birthday,
                Ocupation = entidad.Ocupation,
                KnowGym = entidad.KnowGym,
                Motivation = entidad.Motivation,
                Email = entidad.Email,
                Address = entidad.Address,
                MobileNumber = entidad.MobileNumber,
                EmergencyContactId = entidad.EmergencyContactId,
                MembFileId = entidad.MembFileId,
                QrcodeId = entidad.QrcodeId,
                EmployeeId = entidad.QrcodeId,
                RoleId = entidad.RoleId
            };
        }

        #region Constructores
        public MembersController()
        {
            entidadDAL = new MembersDALImpl();
        }
        #endregion

        #region Consultas
        // GET: api/<MembersController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Member> entidades = entidadDAL.GetAll();
            List<MembersModel> models = new List<MembersModel>();
            foreach (var entidad in entidades)
            {
                models.Add(Convertir(entidad));
            }
            return new JsonResult(models);
        }

        // GET api/<MembersController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Member entidad = entidadDAL.Get(id);
            return new JsonResult(Convertir(entidad));
        }
        #endregion

        #region Agregar
        // POST api/<MembersController>
        [HttpPost]
        public JsonResult Post([FromBody] MembersModel entidad)
        {
            entidadDAL.Add(Convertir(entidad));
            return new JsonResult(entidad);
        }
        #endregion

        #region Modificar
        // PUT api/<MembersController>/5
        [HttpPut]
        public JsonResult Put([FromBody] MembersModel entidad)
        {
            entidadDAL.Update(Convertir(entidad));
            return new JsonResult(entidad);
        }
        #endregion

        #region Eliminar
        // DELETE api/<MembersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Member entidad = new Member
            {
                MemberId = id
            };
            entidadDAL.Remove(entidad);
        }
        #endregion
    }
}