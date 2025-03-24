using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace OryxEngine.Optionals;
public readonly struct Option<T>
{
    private readonly bool _isSuccess;
    private readonly Error _error;
    private readonly T _value;
    private Option(ErrorDetailed e)
    {
        _isSuccess = false;
        _error = e;
        _value = default!;
    }
    private Option(T value)
    {
        _isSuccess = true;
        _value = value;
        _error = Error.Empty;
    }

    public static implicit operator Option<T>(Exception e) => new(e);
    public static implicit operator Option<T>(ErrorDetailed e) => new(e);
    public static implicit operator Option<T>(T value) => new(value);
    public void Handle(Action<T>? success = null, Action<Error>? failure = null)
    {
        switch (_isSuccess) 
        {
            case true:
                success?.Invoke(_value);
                return;
            default:
                failure?.Invoke(_error);
                return;
        }
    }
    
    public void HandleSuccess(Action<T>? success = null) {
        if(!_isSuccess)
            return;
        
        success?.Invoke(_value);
    }

    public void HandleFailure(Action<Error>? failure = null) {
        if(_isSuccess)
            return;
        
        failure?.Invoke(_error);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void HandleInline(Action<T>? success = null, Action<Error>? failure = null)
    {
        switch (_isSuccess) 
        {
            case true:
                success?.Invoke(_value);
                return;
            default:
                failure?.Invoke(_error);
                return;
        }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void HandleSuccessInline(Action<T>? success = null) {
        if(!_isSuccess)
            return;
        
        success?.Invoke(_value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void HandleFailureInline(Action<Error>? failure = null) {
        if(_isSuccess)
            return;
        
        failure?.Invoke(_error);
    }
}