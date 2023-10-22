using BackEnd.Service.Models;

namespace BackEnd.Service.Services
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}