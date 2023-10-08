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
    public class AdminsController : Controller
    {
        private IAdminsDAL entidadDAL;

        private AdminsModel Convertir(Admin entidad)
        {
            return new AdminsModel
            {
                AdminId = entidad.AdminId,
                FullName = entidad.FullName,
                Email = entidad.Email,
                RoleId = entidad.RoleId
            };
        }

        private Admin Convertir(AdminsModel entidad)
        {
            return new Admin
            {
                AdminId = entidad.AdminId,
                FullName = entidad.FullName,
                Email = entidad.Email,
                RoleId = entidad.RoleId
            };
        }

        #region Constructores
        public AdminsController()
        {
            entidadDAL = new AdminsDALImpl();
        }
        #endregion

        #region Consultas
        // GET: api/<AdminsController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Admin> entidades = entidadDAL.GetAll();
            List<AdminsModel> models = new List<AdminsModel>();
            foreach (var entidad in entidades)
            {
                models.Add(Convertir(entidad));
            }
            return new JsonResult(models);
        }

        // GET api/<AdminsController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Admin entidad = entidadDAL.Get(id);
            return new JsonResult(Convertir(entidad));
        }
        #endregion

        #region Agregar
        // POST api/<AdminsController>
        [HttpPost]
        public JsonResult Post([FromBody] AdminsModel entidad)
        {
            entidadDAL.Add(Convertir(entidad));
            return new JsonResult(entidad);
        }
        #endregion

        #region Modificar
        // PUT api/<AdminsController>/5
        [HttpPut]
        public JsonResult Put([FromBody] AdminsModel entidad)
        {
            entidadDAL.Update(Convertir(entidad));
            return new JsonResult(entidad);
        }
        #endregion

        #region Eliminar
        // DELETE api/<AdminsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Admin entidad = new Admin
            {
                AdminId = id
            };
            entidadDAL.Remove(entidad);
        }
        #endregion
    }
}