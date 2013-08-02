using AddressParser.NET.Model.Interfaces;

namespace AddressParser.NET.IoCBootstrap
{
	public class ServiceWrapper
	{
		public ITestDataLoader DefaultITestDataLoader { get; set; }
		public IAddressParseService DefaultIAddressParseService { get; set; }
	}
}
