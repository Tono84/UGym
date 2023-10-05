using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class QRCodeHelper
    {
        ServiceRepository repository;

        public QRCodeHelper()
        {
            repository = new ServiceRepository();
        }

        #region  GetALL
        public List<QRCodeViewModel> GetAll()
        {
            List<QRCodeViewModel> lista = new List<QRCodeViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/QRCode/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<QRCodeViewModel>>(content);
            }
            return lista;
        }
        #endregion

        #region GetByID
        public QRCodeViewModel GetByID(int id)
        {
            QRCodeViewModel entidad = new QRCodeViewModel();
            HttpResponseMessage responseMessage = repository.GetResponse("api/QRCode/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            entidad = JsonConvert.DeserializeObject<QRCodeViewModel>(content);
            return entidad;
        }
        #endregion

        #region Update
        public QRCodeViewModel Edit(QRCodeViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PutResponse("api/QRCode/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            QRCodeViewModel entidadAPI = JsonConvert.DeserializeObject<QRCodeViewModel>(content);
            return entidadAPI;
        }
        #endregion

        #region Create
        public QRCodeViewModel Add(QRCodeViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PostResponse("api/QRCode/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            QRCodeViewModel entidadAPI = JsonConvert.DeserializeObject<QRCodeViewModel>(content);
            return entidadAPI;
        }
        #endregion

        #region GetByID
        public QRCodeViewModel Delete(int id)
        {
            QRCodeViewModel entidad = new QRCodeViewModel();
            HttpResponseMessage responseMessage = repository.DeleteResponse("api/QRCode/" + id);
            return entidad;
        }
        #endregion
    }
}