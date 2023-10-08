using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class MembersHelper
    {
        ServiceRepository repository;

        public MembersHelper()
        {
            repository = new ServiceRepository();
        }

        #region  GetALL
        public List<MembersViewModel> GetAll()
        {
            List<MembersViewModel> lista = new List<MembersViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Members/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<MembersViewModel>>(content);
            }
            return lista;
        }
        #endregion

        #region GetByID
        public MembersViewModel GetByID(int id)
        {
            MembersViewModel entidad = new MembersViewModel();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Members/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            entidad = JsonConvert.DeserializeObject<MembersViewModel>(content);
            return entidad;
        }
        #endregion

        #region Update
        public MembersViewModel Edit(MembersViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PutResponse("api/Members/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            MembersViewModel entidadAPI = JsonConvert.DeserializeObject<MembersViewModel>(content);
            return entidadAPI;
        }
        #endregion

        #region Create
        public MembersViewModel Add(MembersViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PostResponse("api/Members/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            MembersViewModel entidadAPI = JsonConvert.DeserializeObject<MembersViewModel>(content);
            return entidadAPI;
        }
        #endregion

        #region GetByID
        public MembersViewModel Delete(int id)
        {
            MembersViewModel entidad = new MembersViewModel();
            HttpResponseMessage responseMessage = repository.DeleteResponse("api/Members/" + id);
            return entidad;
        }
        #endregion
    }
}