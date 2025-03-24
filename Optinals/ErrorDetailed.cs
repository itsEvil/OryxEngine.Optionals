// ReSharper disable once CheckNamespace
namespace OryxEngine.Optionals;
public class ErrorDetailed(string message = "none", string stackTrace = "none") : Error
{
    private readonly string _message = message;
    private readonly string _stackTrace = stackTrace;

    public override string ToString() => $"{_message}\n{_stackTrace}";
    
    public static implicit operator ErrorDetailed(string message) => new(message);
    
    public static implicit operator ErrorDetailed(Exception ex) => new(ex.Message, ex.StackTrace ?? "Stacktrace is null");
}