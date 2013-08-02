using AddressParser.NET.Model.AddressTypes;

namespace AddressParser.NET.Model.Interfaces
{
	public interface IAddressParseService
	{
		DanishAddress ParseAddress(string addressString);
	}
}
