#nullable enable
using System;

namespace SDC_Sharp.Types
{
    public class SdcConfig
    {
        private const string _tokenStartsWith = "SDC ";
        private string _token = "";

        public string Token
        {
            get => _token;
            set
            {
                value = value.StartsWith(_tokenStartsWith) ? value : _tokenStartsWith + value;

                if (value.Length <= _tokenStartsWith.Length + 1)
                    throw new NullReferenceException("Token can not be empty");

                _token = value;
            }
        }
    }
}