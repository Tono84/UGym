using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class AdminsHelper
    {
        ServiceRepository repository;

        public AdminsHelper()
        {
            repository = new ServiceRepository();
        }

        #region  GetALL
        public List<AdminsViewModel> GetAll()
        {
            List<AdminsViewModel> lista = new List<AdminsViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Admins/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<AdminsViewModel>>(content);
            }
            return lista;
        }
        #endregion

        #region GetByID
        public AdminsViewModel GetByID(int id)
        {
            AdminsViewModel entidad = new AdminsViewModel();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Admins/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            entidad = JsonConvert.DeserializeObject<AdminsViewModel>(content);
            return entidad;
        }
        #endregion

        #region Update
        public AdminsViewModel Edit(AdminsViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PutResponse("api/Admins/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            AdminsViewModel entidadAPI = JsonConvert.DeserializeObject<AdminsViewModel>(content);
            return entidadAPI;
        }
        #endregion

        #region Create
        public AdminsViewModel Add(AdminsViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PostResponse("api/Admins/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            AdminsViewModel entidadAPI = JsonConvert.DeserializeObject<AdminsViewModel>(content);
            return entidadAPI;
        }
        #endregion

        #region GetByID
        public AdminsViewModel Delete(int id)
        {
            AdminsViewModel entidad = new AdminsViewModel();
            HttpResponseMessage responseMessage = repository.DeleteResponse("api/Admins/" + id);
            return entidad;
        }
        #endregion
    }
}