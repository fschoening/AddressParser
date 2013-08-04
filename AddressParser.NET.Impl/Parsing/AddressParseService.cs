using System;
using AddressParser.NET.Model.AddressTypes;
using AddressParser.NET.Model.Exceptions;
using AddressParser.NET.Model.Interfaces;
using AddressParser.NET.Core.Extensions;

namespace AddressParser.NET.Impl.Parsing
{
	public class AddressParseService : IAddressParseService
	{
		public DanishAddress ParseAddress(string addressString)
		{
			var match = Regexes.ImmaParseAnAddress.Match(addressString);

			if (!match.Success)
				throw new AddressParseException("Address '{0}' does not appear to be a valid Danish address.");

			var add = new DanishAddress();
			add.StreetName = match.Groups["StreetName"].Value
				.CapitalizeFirstLowercaseRest();

			add.HouseNumber = int.Parse(match.Groups["HouseNumber"].Value);

			var houseletter = match.Groups["HouseLetter"].Value;
			if (!string.IsNullOrEmpty(houseletter))
				add.HouseLetter = houseletter.ToLower();

			return add;
		}
	}
}
