using System;
using BackEnd.Models;

namespace BackEnd.Services
{
    public interface IJWTTokenServices
    {
        JWTTokens Authenticate(EmployeesModel usuario);
    }
}