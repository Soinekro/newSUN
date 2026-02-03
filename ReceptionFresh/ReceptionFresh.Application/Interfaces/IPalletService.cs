using CommonClass.Application.Interfaces;
using ReceptionFresh.Application.DTOs.Request;
using ReceptionFresh.Application.DTOs.Responses;
using ReceptionFresh.Domain.Entities;

namespace ReceptionFresh.Application.Interfaces;

public interface IPalletService 
    : IBaseService<Pallet, PalletResponse, PalletRequest, PalletRequest>
{
}