using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class EmployeesHelper
    {
        ServiceRepository repository;

        public EmployeesHelper()
        {
            repository = new ServiceRepository();
        }

        #region  GetALL
        public List<EmployeesViewModel> GetAll()
        {
            List<EmployeesViewModel> lista = new List<EmployeesViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Employees/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<EmployeesViewModel>>(content);
            }
            return lista;
        }
        #endregion

        #region GetByID
        public EmployeesViewModel GetByID(int id)
        {
            EmployeesViewModel entidad = new EmployeesViewModel();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Employees/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            entidad = JsonConvert.DeserializeObject<EmployeesViewModel>(content);
            return entidad;
        }
        #endregion

        #region Update
        public EmployeesViewModel Edit(EmployeesViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PutResponse("api/Employees/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            EmployeesViewModel entidadAPI = JsonConvert.DeserializeObject<EmployeesViewModel>(content);
            return entidadAPI;
        }
        #endregion

        #region Create
        public EmployeesViewModel Add(EmployeesViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PostResponse("api/Employees/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            EmployeesViewModel entidadAPI = JsonConvert.DeserializeObject<EmployeesViewModel>(content);
            return entidadAPI;
        }
        #endregion

        #region GetByID
        public EmployeesViewModel Delete(int id)
        {
            EmployeesViewModel entidad = new EmployeesViewModel();
            HttpResponseMessage responseMessage = repository.DeleteResponse("api/Employees/" + id);
            return entidad;
        }
        #endregion
    }
}