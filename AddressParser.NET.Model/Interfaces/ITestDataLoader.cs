using System.Collections.Generic;
using AddressParser.NET.Model.AddressTypes;

namespace AddressParser.NET.Model.Interfaces
{
	public interface ITestDataLoader
	{
		List<TestAddress> GetTestAddresses(string filename);
	}
}
