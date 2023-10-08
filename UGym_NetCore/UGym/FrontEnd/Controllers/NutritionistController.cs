using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FrontEnd.Helpers;

namespace FrontEnd.Controllers
{
    public class NutritionistController : Controller
    {
        private MembersHelper membersHelper;

        private EmployeesHelper employeesHelper;

        public NutritionistController()
        {
            membersHelper = new MembersHelper(); // Debes crear la clase MembersHelper para acceder a los datos de los nutricionistas
            employeesHelper = new EmployeesHelper();
        }

        // GET: Nutritionist
        public ActionResult Index()
        {
            return View();
        }

        // GET: Nutritionist/Edit/{id}
        public ActionResult Edit(int id)
        {
            EmployeesViewModel employee = employeesHelper.GetByID(id);
            if (employee == null)
            {
                return NotFound(); // Manejar el caso en que el empleado no se encuentre
            }

            return View(employee);
        }

        // POST: Nutritionist/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeesViewModel employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest(); // Manejar el caso en que el ID no coincida
            }

            if (ModelState.IsValid)
            {
                // Realizar la actualización del empleado en la base de datos
                EmployeesViewModel updatedEmployee = employeesHelper.Edit(employee);

                if (updatedEmployee != null)
                {
                    return RedirectToAction("Profile"); // Redirigir a la vista "Profile" después de la actualización exitosa
                }
                else
                {
                    ModelState.AddModelError("", "Error al actualizar el empleado"); // Manejar errores de actualización
                }
            }

            return View(employee);
        }

        #region Profile
        // GET: Nutritionist/Index
        public ActionResult Profile()
        {
            List<EmployeesViewModel> list = employeesHelper.GetAll();
            return View(list);
        }
        #endregion

        public ActionResult Reports()
        {
            return View();
        }

        #region Clients
        // GET: Nutritionist/Index
        public ActionResult Clients()
        {
            List<MembersViewModel> list = membersHelper.GetAll();
            return View(list);
        }
        #endregion
    }
}