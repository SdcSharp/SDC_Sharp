using SDC_Sharp.Types.Interfaces;

namespace SDC_Sharp.Types.Exceptions.Errors;

public class Forbidden : ApiErrorException
{
	internal Forbidden(IError response) : base(response)
	{
	}
}