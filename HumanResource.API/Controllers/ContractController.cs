using CommonClass.API.Controllers;
using HumanResource.Aplication.DTOs.Request;
using HumanResource.Aplication.DTOs.Responses;
using HumanResource.Aplication.Interfaces;
using HumanResource.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.API.Controllers
{
    [Route("api/[controller]")]
    public class ContractController(IContractService service)
    : BaseController<Contract, ContractResponse, ContractRequest, ContractRequest>(service)
    {
        // ¡Listo! Ya tienes GetAll (paginado/filtros), GetById, Create, Update, Delete.
    }
}
