using System;
using AddressParser.NET.Model;
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

			var address = new DanishAddress();
			address.StreetName = match.Groups["StreetName"].Value
				.CapitalizeFirstLowercaseRest();

			address.HouseNumber = int.Parse(match.Groups["HouseNumber"].Value);

			var houseLetterStr = match.Groups["HouseLetter"].Value;
			if (!string.IsNullOrEmpty(houseLetterStr))
				address.HouseLetter = houseLetterStr.ToLower();

			var floorStr = match.Groups["Floor"].Value;
			if (!string.IsNullOrEmpty(floorStr))
				address.Floor = GetFloor(floorStr);

			var sideStr = match.Groups["Side"].Value;
			if (!string.IsNullOrEmpty(sideStr))
				address.Side = GetSide(sideStr);

			var roomNumberStr = match.Groups["DoorOrRoomNo"].Value;
			if (!string.IsNullOrEmpty(roomNumberStr))
				address.DoorOrRoomNo = GetRoomNumber(roomNumberStr);

			return address;
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

		private ApartmentSide GetSide(string sideStrArg)
		{
			var sideStr = sideStrArg
				.ToLower()
				.Replace(".", string.Empty)
				.Replace(" ", string.Empty);

			ApartmentSide side;
			if (Enum.TryParse(sideStr, true, out side))
				return side;

			throw new NotImplementedException(string.Format("No handler for parsing the side '{0}'", sideStrArg));
		}

		private int GetRoomNumber(string roomNumberStr)
		{
			return int.Parse(roomNumberStr);
		}
	}
}
