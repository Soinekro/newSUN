using CommonClass.API.Controllers;
using __Module__.Aplication.DTOs.Request;
using __Module__.Aplication.DTOs.Responses;
using __Module__.Aplication.Interfaces;
using __Module__.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace __Module__.API.Controllers;

[Route("api/[controller]")]
public class __Entity__Controller(I__Entity__Service service) 
    : BaseController<__Entity__, __Entity__Response, __Entity__Request, __Entity__Request>(service)
{
}