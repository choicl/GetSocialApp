namespace GetSocial.Application.ResultsModel;

public class OperationResults<T>
{
    public T Payload { get; set; }
    public bool IsError { get; set; }
    public List<Error> Errors { get; set; } = new List<Error>();
}