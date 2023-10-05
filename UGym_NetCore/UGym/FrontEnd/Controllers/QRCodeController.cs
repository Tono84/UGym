using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace FrontEnd.Controllers
{
    public class QRCodeController : Controller
    {
        QRCodeHelper entidadHelper;

        #region Index
        // GET: CategoryController
        public ActionResult Index()
        {
            entidadHelper = new QRCodeHelper();
            List<QRCodeViewModel> list = entidadHelper.GetAll();
            return View(list);
        }
        #endregion

        #region Details
        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            entidadHelper = new QRCodeHelper();
            QRCodeViewModel entidad = entidadHelper.GetByID(id);
            return View(entidad);
        }
        #endregion

        #region Create
        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QRCodeViewModel entidad)
        {
            try
            {
                entidadHelper = new QRCodeHelper();
                entidad = entidadHelper.Add(entidad);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Edit
        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            entidadHelper = new QRCodeHelper();
            QRCodeViewModel entidad = entidadHelper.GetByID(id);
            return View(entidad);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QRCodeViewModel entidad)
        {
            try
            {
                entidadHelper = new QRCodeHelper();
                entidad = entidadHelper.Edit(entidad);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Delete
        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            entidadHelper = new QRCodeHelper();
            QRCodeViewModel entidad = entidadHelper.GetByID(id);
            return View(entidad);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(QRCodeViewModel entidad)
        {
            try
            {
                entidadHelper = new QRCodeHelper();
                entidadHelper.Delete(entidad.QrcodeId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }
}