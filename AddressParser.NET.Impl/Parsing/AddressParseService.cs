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

			var floorStr = match.Groups["Floor"].Value;

			if (!string.IsNullOrEmpty(floorStr))
				add.Floor = GetFloor(floorStr);

			return add;
		}

		private int GetFloor(string floorStr)
		{
			floorStr = floorStr
				.ToLower()
				.Replace(".", string.Empty)
				.Replace("sal", string.Empty)
				.Trim();

			if (floorStr.StartsWith("st"))
				return 0;

			if (floorStr.StartsWith("kl"))
				return -1;

			return int.Parse(floorStr);
		}
	}
}
