using CommonClass.API.Controllers;
using ReceptionFresh.Application.DTOs.Request;
using ReceptionFresh.Application.DTOs.Responses;
using ReceptionFresh.Application.Interfaces;
using ReceptionFresh.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ReceptionFresh.API.Controllers;

[Route("api/[controller]")]
public class PalletController(IPalletService service) 
    : BaseController<Pallet, PalletResponse, PalletRequest, PalletRequest>(service)
{
}