using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AddressParser.Model.AddressTypes;
using AddressParser.Model.Interfaces;

namespace AddressParser.Impl.Testing
{
	public class DefaultTestDataLoader : ITestDataLoader
	{
		private readonly Regex _extractTestAddressRegEx = new Regex(@"Address1:\s*(?<Address1>.*?)\s*Address2:\s*(?<Address2>.*?)\s*Zip", RegexOptions.IgnoreCase | RegexOptions.Compiled);

		public List<TestAddress> GetTestAddresses(string filename)
		{
			var testAddresses = new List<TestAddress>();

			using (var file =
				new System.IO.StreamReader(filename))
			{
				string line;
				while ((line = file.ReadLine()) != null)
				{
					var match = _extractTestAddressRegEx.Match(line);

					if (!match.Success)
						throw new ArgumentException("Error in test-address file.");

					var testAddress = new TestAddress
						{
							Address1 = match.Groups["Address1"].Value,
							Address2 = match.Groups["Address2"].Value
						};

					testAddresses.Add(testAddress);
				}

			}

			return testAddresses;
		}
	}
}
