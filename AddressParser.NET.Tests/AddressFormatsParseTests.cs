using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressParser.IoCBootstrap;
using AddressParser.Model.AddressTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressParser.Tests
{
	[TestClass]
	public class AddressFormatsParseTests
	{
		protected ServiceWrapper Services { get; set; }
		protected Dictionary<string, DanishAddress> AddressAssertions { get; set; }

		[TestInitialize]
		public void Init()
		{
			this.Services = IoCHelper.GetDefaultServices();
		}

		[TestMethod]
		public void Simple()
		{
			const string testAddressString = "Testvej 10";
			var testAddress = Services.DefaultIAddressParseService.ParseAddress(testAddressString);
			var assertedAddress = new DanishAddress
				{
					StreetName = "Testvej",
					HouseNumber = 10
				};

			Assert.AreEqual(assertedAddress, testAddress, "haxor");
		}
	}
}
