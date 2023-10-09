using BackEnd.Helpers;
using BackEnd.Models;
using BackEnd.Services;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private IEmployeesDAL entidadDAL;
        private UGymContext context;
        private BcryptPasswordHelper BcryptPasswordHelper;
        private readonly JWTServiceManage _jwttokenservice;
        private readonly IConfiguration _configuration;

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
            BcryptPasswordHelper = new BcryptPasswordHelper();
            _jwttokenservice = new JWTServiceManage(_configuration);
            context = new UGymContext();
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
            string passwordEncrypted = BcryptPasswordHelper.HashPassword(entidad.Password);
            entidad.Password = passwordEncrypted;
            entidadDAL.Add(Convertir(entidad));
            return new JsonResult(entidad);
        }
        #endregion

        #region Modificar
        // PUT api/<EmployeesController>/5
        [HttpPut]
        public JsonResult Put([FromBody] EmployeesModel entidad)
        {
            if (string.IsNullOrEmpty(entidad.Password))
            {
                string passwordEncrypted = BcryptPasswordHelper.HashPassword("12345678");
                entidad.Password = passwordEncrypted;
                entidadDAL.Update(Convertir(entidad));
                return new JsonResult(entidad);
            }
            else
            {
                string passwordEncrypted = BcryptPasswordHelper.HashPassword(entidad.Password);
                entidad.Password = passwordEncrypted;
                entidadDAL.Update(Convertir(entidad));
                return new JsonResult(entidad);
            }
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

        #region Authenticate
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public JsonResult Authenticate(EmployeesModel entidad)
        {
            JWTTokens token = _jwttokenservice.Authenticate(entidad);

            if (token == null)
            {
                return new JsonResult(new { authState = false, Message = "Correo Eléctronico o contraseña Incorrectos" });
            }

            return new JsonResult(token);
        }


        [AllowAnonymous]
        [HttpPost("validateUserToken/{currentToken}")]
        public JsonResult validateUserToken(string currentToken)
        {
            //Boolean token = _jwttokenservice.ValidateToken(currentToken);

            //if (token == null)
            //{
            //    return new JsonResult(new { authState = false, Message = "Correo Eléctronico o contraseña Incorrectos" });
            //}
            bool validToken = _jwttokenservice.ValidateToken(currentToken);

            return new JsonResult(validToken);
        }
        #endregion
    }
}