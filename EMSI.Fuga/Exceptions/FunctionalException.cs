namespace EMSI.Fuga.Exceptions;

public class FunctionalException : Exception
{
    public TypeEnum Type { get; set; }
    
    public FunctionalException(string message) : this(message, TypeEnum.ServerError)
    {
        
    }

    public FunctionalException(string message, TypeEnum type) : base(message)
    {
        Type = type;
    }
}
public enum TypeEnum
{
    NotFound,
    InvalidInput,
    ServerError
}