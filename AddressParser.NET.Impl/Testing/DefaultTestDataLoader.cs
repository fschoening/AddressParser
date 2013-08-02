using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AddressParser.NET.Model.AddressTypes;
using AddressParser.NET.Model.Interfaces;

namespace AddressParser.NET.Impl.Testing
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
							AddressString1 = match.Groups["Address1"].Value,
							AddressString2 = match.Groups["Address2"].Value
						};

					testAddresses.Add(testAddress);
				}

			}

			return testAddresses;
		}
	}
}
