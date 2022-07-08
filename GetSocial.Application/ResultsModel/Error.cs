using GetSocial.Application.Enums;

namespace GetSocial.Application.ResultsModel;

public class Error
{
    public ErrorCode Code { get; set; }
    public string Message { get; set; }
}