using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressParser.NET.IoCBootstrap;
using AddressParser.NET.Model.AddressTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressParser.NET.Tests
{
	[TestClass]
	public class AddressFormatsParseTestsFloor
	{
		protected ServiceWrapper Services { get; set; }
		protected Dictionary<string, DanishAddress> AddressAssertions { get; set; }

		[TestInitialize]
		public void Init()
		{
			this.Services = IoCHelper.GetDefaultServices();
		}

		[TestMethod]
		public void GroundFloorAddress()
		{
			var testAddressStrings = new List<string>
				{
					"Testvej 10, st.",
					"Testvej 10, ST",
					"Testvej 10, s.t.",
					"Testvej 10 stuen"
				};

			var assertedAddress = new DanishAddress
			{
				StreetName = "Testvej",
				HouseNumber = 10,
				Floor = 0
			};

			foreach (var testAddressString in testAddressStrings)
			{
				var testAddress = Services.DefaultIAddressParseService.ParseAddress(testAddressString);
				Assert.AreEqual(assertedAddress, testAddress);
			}
		}

		[TestMethod]
		public void BasementAddress()
		{
			var testAddressStrings = new List<string>
				{
					"Testvej 10, kl.",
					"Testvej 10, kld",
					"Testvej 10, kld.",
					"Testvej 10, kldr.",
					"Testvej 10, -1"
				};

			var assertedAddress = new DanishAddress
			{
				StreetName = "Testvej",
				HouseNumber = 10,
				Floor = -1
			};

			foreach (var testAddressString in testAddressStrings)
			{
				var testAddress = Services.DefaultIAddressParseService.ParseAddress(testAddressString);
				Assert.AreEqual(assertedAddress, testAddress);
			}
		}

		[TestMethod]
		public void FloorAddress()
		{
			var testAddressStrings = new List<string>
				{
					"Testvej 10, 4. sal",
					"Testvej 10, 4. th.",
					//"Testvej 10-04",
					"Testvej 10, 4",
					"Testvej 10., 4.",
					"Testvej 10, 04-02",
					"Testvej 10, 4.2",
					"Testvej 10.4.1",
					"Testvej 10 4 6"
				};

			var assertedAddress = new DanishAddress
			{
				StreetName = "Testvej",
				HouseNumber = 10,
				Floor = 4
			};

			foreach (var testAddressString in testAddressStrings)
			{
				var testAddress = Services.DefaultIAddressParseService.ParseAddress(testAddressString);
				Assert.AreEqual(assertedAddress, testAddress);
			}
		}
	}
}
