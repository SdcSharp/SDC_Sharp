#nullable enable
using System;
using SDC_Sharp.Types.Interfaces;

namespace SDC_Sharp.Types;

public class SdcConfig : ISdcConfig
{
	private const string m_cTokenStartsWith = "SDC ";
	private string m_token = "";

	public string Token
	{
		get => m_token;
		set
		{
			value = value.StartsWith(m_cTokenStartsWith) ? value : m_cTokenStartsWith + value;

			if (value.Length <= m_cTokenStartsWith.Length + 1)
				throw new NullReferenceException("Token can not be empty");

			m_token = value;
		}
	}
}