using EMSI.Fuga.Domain.Abstractions;
using EMSI.Fuga.Domain.Models;
using EMSI.Fuga.Exceptions;
using EMSI.Fuga.Infrastructure.Abstractions;
using EMSI.Fuga.Infrastructure.DAO;
using MapsterMapper;

namespace EMSI.Fuga.Passengers;

public class PassengersService : IPassengersService
{
    private readonly IPassengersRepository _passengersRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PassengersService(IPassengersRepository passengersRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _passengersRepository = passengersRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreatePassengerAsync(Passenger passenger)
    {
        var dao = _mapper.Map<PassengerDAO>(passenger);
        dao.Id = Guid.NewGuid();
        await _passengersRepository.AddAsync(dao);
        await _unitOfWork.CommitAsync();
    }

    public async Task<Passenger> GetByIdAsync(Guid passengerId)
    {
        var dao = await _passengersRepository.GetByIdAsync(passengerId);
        
        if(dao is null)
            throw new FunctionalException($"Passenger#{passengerId} not found", TypeEnum.NotFound);
        
        return _mapper.Map<Passenger>(dao);
    }
}