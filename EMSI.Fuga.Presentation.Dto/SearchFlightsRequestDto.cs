#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
namespace EMSI.Fuga.Presentation.Dto;

public class SearchFlightsRequestDto
{
    public DateOnly DepartureDate { get; set; }
    public DateOnly? ReturnDate { get; set; }
    public string DepartureFrom { get; set; }
    public string ArrivalTo { get; set; }
    public bool DirectFlight { get; set; }
}