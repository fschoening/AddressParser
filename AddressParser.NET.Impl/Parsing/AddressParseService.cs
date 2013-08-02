using AddressParser.NET.Model.AddressTypes;
using AddressParser.NET.Model.Interfaces;

namespace AddressParser.NET.Impl.Parsing
{
    public class AddressParseService : IAddressParseService
    {
		public DanishAddress ParseAddress(string addressString)
		{
			var match = Regexes.ImmaParseAnAddress.Match(addressString);

			if (!match.Success)
				return null;

			var add = new DanishAddress();
			add.StreetName = match.Groups["StreetName"].Value;
			add.HouseNumber = int.Parse(match.Groups["HouseNumber"].Value);

			var houseletter = match.Groups["HouseLetter"].Value;
			add.HouseLetter = houseletter;

			return add;
		}
    }
}
