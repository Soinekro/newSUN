using CommonClass.Application.Interfaces;
using __Module__.Application.DTOs.Request;
using __Module__.Application.DTOs.Responses;
using __Module__.Domain.Entities;

namespace __Module__.Application.Interfaces;

public interface I__Entity__Service 
    : IBaseService<__Entity__, __Entity__Response, __Entity__Request, __Entity__Request>
{
}