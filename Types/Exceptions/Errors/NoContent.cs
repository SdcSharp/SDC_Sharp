using SDC_Sharp.Types.Interfaces;

namespace SDC_Sharp.Types.Exceptions.Errors;

public class NoContent : ApiErrorException
{
	internal NoContent(IError response) : base(response)
	{
	}
}