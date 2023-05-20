using System;
using SDC_Sharp.Types.Enums;
using SDC_Sharp.Types.Exceptions.Errors;
using SDC_Sharp.Types.Interfaces;

namespace SDC_Sharp.Types.Exceptions;

public class ApiErrorException : Exception, IError
{
	internal ApiErrorException(IError response)
	{
		Message = response.Message;
		Type = response.Type;
		Code = response.Code;
	}

	public override string Message { get; }
	public ErrorType Type { get; }
	public int Code { get; }

	public static ApiErrorException GetException(IError response)
	{
		return response.Type switch
		{
			ErrorType.NoContent => new NoContent(response),
			ErrorType.Forbidden => new Forbidden(response),
			_ => new ApiErrorException(response)
		};
	}
}