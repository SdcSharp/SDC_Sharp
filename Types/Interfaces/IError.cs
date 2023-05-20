using SDC_Sharp.Types.Enums;

namespace SDC_Sharp.Types.Interfaces;

public interface IError
{
	public string Message { get; }
	public ErrorType Type { get; }
	public int Code { get; }
}