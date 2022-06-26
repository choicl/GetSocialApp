namespace GetSocial.Application.ResponseMessages;

public class OperationResults<T>
{
    public T Payload { get; set; }
    public bool IsError { get; set; }
    public List<string> Errors { get; set; }
}