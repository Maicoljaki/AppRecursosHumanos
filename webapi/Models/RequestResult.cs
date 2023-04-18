namespace webapi.Models;

public class RequestResult<T>
{
    public bool IsError { get; set; }
    public T? Result { get; set; }
    public string? Error { get; set; }
}
