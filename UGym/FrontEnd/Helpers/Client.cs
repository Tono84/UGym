namespace FrontEnd.Helpers
{
    public class Authentication
    {
        public HttpClient Initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:5098");
            return Client;
        }
    }
}
