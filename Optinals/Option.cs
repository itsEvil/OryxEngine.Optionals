using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace OryxEngine.Optionals;
public readonly struct Option<T>
{
    // ReSharper disable once MemberCanBePrivate.Global
    public readonly bool IsSuccess;
    // ReSharper disable once MemberCanBePrivate.Global
    public readonly Error Error;
    // ReSharper disable once MemberCanBePrivate.Global
    public readonly T Value;
    private Option(ErrorDetailed e)
    {
        IsSuccess = false;
        Error = e;
        Value = default!;
    }
    private Option(T value)
    {
        IsSuccess = true;
        Value = value;
        Error = Error.Empty;
    }

    public static implicit operator Option<T>(Exception e) => new(e);
    public static implicit operator Option<T>(ErrorDetailed e) => new(e);
    public static implicit operator Option<T>(T value) => new(value);
    public void Handle(Action<T>? success = null, Action<Error>? failure = null)
    {
        switch (IsSuccess) 
        {
            case true:
                success?.Invoke(Value);
                return;
            default:
                failure?.Invoke(Error);
                return;
        }
    }
    
    public void HandleSuccess(Action<T>? success = null) {
        if(!IsSuccess)
            return;
        
        success?.Invoke(Value);
    }

    public void HandleFailure(Action<Error>? failure = null) {
        if(IsSuccess)
            return;
        
        failure?.Invoke(Error);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void HandleInline(Action<T>? success = null, Action<Error>? failure = null)
    {
        switch (IsSuccess) 
        {
            case true:
                success?.Invoke(Value);
                return;
            default:
                failure?.Invoke(Error);
                return;
        }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void HandleSuccessInline(Action<T>? success = null) {
        if(!IsSuccess)
            return;
        
        success?.Invoke(Value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void HandleFailureInline(Action<Error>? failure = null) {
        if(IsSuccess)
            return;
        
        failure?.Invoke(Error);
    }
}