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
    public class QRCodeController : Controller
    {
        private IQRCodeDAL entidadDAL;

        private QRCodeModel Convertir(Qrcode entidad)
        {
            return new QRCodeModel
            {
                QrcodeId = entidad.QrcodeId,
                LinkQr = entidad.LinkQr
            };
        }

        private Qrcode Convertir(QRCodeModel entidad)
        {
            return new Qrcode
            {
                QrcodeId = entidad.QrcodeId,
                LinkQr = entidad.LinkQr
            };
        }

        #region Constructores
        public QRCodeController()
        {
            entidadDAL = new QRCodeDALImpl();
        }
        #endregion

        #region Consultas
        // GET: api/<QRCodeController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Qrcode> entidades = entidadDAL.GetAll();
            List<QRCodeModel> models = new List<QRCodeModel>();
            foreach (var entidad in entidades)
            {
                models.Add(Convertir(entidad));
            }
            return new JsonResult(models);
        }

        // GET api/<QRCodeController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Qrcode entidad = entidadDAL.Get(id);
            return new JsonResult(Convertir(entidad));
        }
        #endregion

        #region Agregar
        // POST api/<QRCodeController>
        [HttpPost]
        public JsonResult Post([FromBody] QRCodeModel entidad)
        {
            entidadDAL.Add(Convertir(entidad));
            return new JsonResult(entidad);
        }
        #endregion

        #region Modificar
        // PUT api/<QRCodeController>/5
        [HttpPut]
        public JsonResult Put([FromBody] QRCodeModel entidad)
        {
            entidadDAL.Update(Convertir(entidad));
            return new JsonResult(entidad);
        }
        #endregion

        #region Eliminar
        // DELETE api/<QRCodeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Qrcode entidad = new Qrcode
            {
                QrcodeId = id
            };
            entidadDAL.Remove(entidad);
        }
        #endregion
    }
}