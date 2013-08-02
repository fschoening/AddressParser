using System;

namespace AddressParser.NET.Model.Exceptions
{
	public class AddressParseException : ApplicationException
	{
		public AddressParseException(string message) : base(message)
		{
		}
	}
}
