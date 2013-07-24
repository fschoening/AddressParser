using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressParser.IoCBootstrap;

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
			var testAddresses = Services.DefaultITestDataLoader.GetTestAddresses(@"D:\Schoening.it\_stuff\test_adresser_01.txt");
			testAddresses = testAddresses.OrderBy(x => x.Address1).ToList();
			
			using (var sw = new StreamWriter(@"D:\Schoening.it\_stuff\parsed_address1.txt", false))
			{
				foreach (var testAddress in testAddresses)
				{
					sw.WriteLine(testAddress.Address1);
				}
			}
		}

	}
}
