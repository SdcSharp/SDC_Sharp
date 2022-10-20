#nullable enable
using System;

namespace SDC_Sharp.Types
{
	public class SdcConfig
	{
		private const string c_tokenStartsWith = "SDC ";
		private string m_token = "";

		public string Token
		{
			get => m_token;
			set
			{
				value = value.StartsWith(c_tokenStartsWith) ? value : c_tokenStartsWith + value;

				if (value.Length <= c_tokenStartsWith.Length + 1)
					throw new NullReferenceException("Token can not be empty");

				m_token = value;
			}
		}
	}
}