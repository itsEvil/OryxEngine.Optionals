# OryxEngine.Optionals
 A basic union impl in C# for Oryx Engine

```csharp
    public static void Main(string[] args)
    {
        string[] arr = ["hello", "world", "how", "are", "we", "today", "?"];

        for (var i = 0; i < arr.Length + 5; i++) {
            Console.Write("Index:{0} ", i);
            var result = TryGetValue(arr, i);
            result.Handle(OnSuccess, OnFailure);
        }
    }
    private static void OnSuccess(string obj)
    {
        Console.WriteLine("Success: {0}", obj);
    }
    private static void OnFailure(Error obj)
    {
        Console.WriteLine("Error occured: {0}", obj);
    }
    private static Option<string> TryGetValue(string[] args, int index = 0)
    {
        try
        {
            //For this example pretend we can't do anything
            //about this exception as it happens in a class we cannot modify 
            return args[index];
        }
        catch (Exception e)
        {
            return e;
        }
    }
```
