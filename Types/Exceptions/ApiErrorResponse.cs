using SDC_Sharp.Types.Enums;
using SDC_Sharp.Types.Interfaces;

namespace SDC_Sharp.Types.Exceptions;

internal sealed class ApiErrorResponse : IError
{
	public string Message { get; set; }
	public ErrorType Type { get; set; }
	public int Code { get; set; }
}