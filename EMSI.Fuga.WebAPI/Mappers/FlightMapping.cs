using EMSI.Fuga.Domain.Models;
using EMSI.Fuga.Presentation.Dto;
using Mapster;

namespace EMSI.Fuga.WebAPI.Mappers;

public class FlightMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Flight, FlightDto>();
    }
}