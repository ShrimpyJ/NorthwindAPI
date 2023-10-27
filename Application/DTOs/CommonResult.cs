namespace API;

public class CommonResult<T>
{
    public bool IsSuccess { get; set; } = false;
    public T Data { get; set; }
    public string? Message { get; set; }
    public List<string> Errors { get; set; } = new List<string>();

    public static CommonResult<T> Success(T data)
    {
        return new CommonResult<T> { IsSuccess = true, Data = data };
    }

    public static CommonResult<T> Failure(string? message = null)
    {
        return new CommonResult<T> { IsSuccess = false, Message = message };
    }
}