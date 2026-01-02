using EMSI.Fuga.Domain.Abstractions;
using EMSI.Fuga.Domain.Models;
using EMSI.Fuga.Exceptions;
using EMSI.Fuga.Infrastructure.Abstractions;
using EMSI.Fuga.Infrastructure.DAO;
using MapsterMapper;

namespace EMSI.Fuga.Bookings;

public class BookingsService : IBookingsService
{
    private readonly IBookingsRepository _bookingsRepository;
    private readonly IPassengersRepository _passengersRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookingsService(IBookingsRepository bookingsRepository, IPassengersRepository passengersRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _bookingsRepository = bookingsRepository;
        _passengersRepository = passengersRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task BookFlightAsync(Booking booking)
    {
        booking.Id = Guid.NewGuid();
        booking.BookingDate = DateTime.UtcNow;
        var dao = _mapper.Map<BookingDAO>(booking);
        await _bookingsRepository.AddAsync(dao);
        await _unitOfWork.CommitAsync();
    }

    public async Task CancelFlightAsync(Guid bookingId, Guid passengerId)
    {
        var dao = await GetBookingDaoOrThrowException(bookingId, passengerId);

        dao.CancellationDate = DateTime.UtcNow;
        _bookingsRepository.Update(dao);
        await _unitOfWork.CommitAsync();
    }
    

    public async Task CheckingFlightAsync(Guid bookingId, Guid passengerId, string passportNumber)
    {
        var dao = await GetBookingDaoOrThrowException(bookingId, passengerId);
        
        dao!.CheckingDate = DateTime.UtcNow;
        _bookingsRepository.Update(dao);
        
        var passenger = await _passengersRepository.GetByIdAsync(passengerId);
        if(passenger is null)
            throw new FunctionalException($"Passenger#{passengerId} not found", TypeEnum.NotFound);
        
        passenger.PassportNumber = passportNumber;
        _passengersRepository.Update(passenger);
        
        //save all as in one transaction
        await _unitOfWork.CommitAsync();
    }
    
    private async Task<BookingDAO?> GetBookingDaoOrThrowException(Guid bookingId, Guid passengerId)
    {
        var dao = await _bookingsRepository.GetByIdAsync(bookingId);
        if(dao is null)
            throw new FunctionalException($"Booking#{bookingId} not found", TypeEnum.NotFound);
        
        return dao.PassengerId != passengerId 
            ? throw new FunctionalException($"Booking#{bookingId} not booked by Passenger#{passengerId}", TypeEnum.NotFound) 
            : dao;
    }
}