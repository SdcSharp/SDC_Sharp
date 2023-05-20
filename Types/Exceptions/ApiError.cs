namespace SDC_Sharp.Types.Exceptions;

internal sealed class ApiError
{
	public readonly ApiErrorResponse Error;

	public ApiError(ApiErrorResponse error)
	{
		Error = error;
	}
}