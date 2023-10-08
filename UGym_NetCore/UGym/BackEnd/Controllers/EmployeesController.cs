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
    public class EmployeesController : Controller
    {
        private IEmployeesDAL entidadDAL;

        private EmployeesModel Convertir(Employee entidad)
        {
            return new EmployeesModel
            {
                EmployeeId = entidad.EmployeeId,
                EmployeeNumber = entidad.EmployeeNumber,
                Password = entidad.Password,
                FullName = entidad.FullName,
                Birthday = entidad.Birthday,
                Gender = entidad.Gender,
                Email = entidad.Email,
                Address = entidad.Address,
                MobileNumber = entidad.MobileNumber,
                EmergencyContactId = entidad.EmergencyContactId,
                RoleId = entidad.RoleId
            };
        }

        private Employee Convertir(EmployeesModel entidad)
        {
            return new Employee
            {
                EmployeeId = entidad.EmployeeId,
                EmployeeNumber = entidad.EmployeeNumber,
                Password = entidad.Password,
                FullName = entidad.FullName,
                Birthday = entidad.Birthday,
                Gender = entidad.Gender,
                Email = entidad.Email,
                Address = entidad.Address,
                MobileNumber = entidad.MobileNumber,
                EmergencyContactId = entidad.EmergencyContactId,
                RoleId = entidad.RoleId
            };
        }

        #region Constructores
        public EmployeesController()
        {
            entidadDAL = new EmployeesDALImpl();
        }
        #endregion

        #region Consultas
        // GET: api/<EmployeesController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Employee> entidades = entidadDAL.GetAll();
            List<EmployeesModel> models = new List<EmployeesModel>();
            foreach (var entidad in entidades)
            {
                models.Add(Convertir(entidad));
            }
            return new JsonResult(models);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Employee entidad = entidadDAL.Get(id);
            return new JsonResult(Convertir(entidad));
        }
        #endregion

        #region Agregar
        // POST api/<EmployeesController>
        [HttpPost]
        public JsonResult Post([FromBody] EmployeesModel entidad)
        {
            entidadDAL.Add(Convertir(entidad));
            return new JsonResult(entidad);
        }
        #endregion

        #region Modificar
        // PUT api/<EmployeesController>/5
        [HttpPut]
        public JsonResult Put([FromBody] EmployeesModel entidad)
        {
            entidadDAL.Update(Convertir(entidad));
            return new JsonResult(entidad);
        }
        #endregion

        #region Eliminar
        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Employee entidad = new Employee
            {
                EmployeeId = id
            };
            entidadDAL.Remove(entidad);
        }
        #endregion
    }
}