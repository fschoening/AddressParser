using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AddressParser.NET.IoCBootstrap;
using AddressParser.NET.Model.AddressTypes;

namespace ConsoleTester
{
	class ConsoleTester
	{
		protected static ServiceWrapper Services { get; set; }

		static ConsoleTester()
		{
			Services = IoCHelper.GetDefaultServices();
		}

		static void Main(string[] args)
		{
			const string folder = @"D:\Schoening.it\_stuff\";
			var testAddressesFile = string.Format("{0}test_adresser_01.txt", folder);
			var rawAddress1File = string.Format("{0}parsed_address1.txt", folder);
			var parsedAddressesFile = string.Format("{0}parsed.txt", folder);
			var notParsedAddressesFile = string.Format("{0}notparsed.txt", folder);

			var testAddresses = Services.DefaultITestDataLoader
				.GetTestAddresses(testAddressesFile)
				.OrderBy(x => x.AddressString1).ToList();

			var parsedAddresses = new List<DanishAddress>();

			foreach (var testAddress in testAddresses)
			{
				var parsedAddress = Services.DefaultIAddressParseService.ParseAddress(testAddress.AddressString1);
				if (parsedAddress != null)
					parsedAddresses.Add(parsedAddress);
			}

			//using (var sw = new StreamWriter(rawAddress1File, false))
			//{
			//	foreach (var testAddress in testAddresses)
			//	{
			//		sw.WriteLine(testAddress.AddressString1);
			//	}
			//}
		}

	}
}
