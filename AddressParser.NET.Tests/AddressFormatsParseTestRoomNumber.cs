using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AddressParser.NET.IoCBootstrap;
using AddressParser.NET.Model.AddressTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressParser.NET.Tests
{
	[TestClass]
	public class AddressFormatsParseTestRoomNumber
	{
		protected ServiceWrapper Services { get; set; }
		protected Dictionary<string, DanishAddress> AddressAssertions { get; set; }

		[TestInitialize]
		public void Init()
		{
			this.Services = IoCHelper.GetDefaultServices();
		}

		[TestMethod]
		public void GroundFloorWithRoomNumber()
		{
			var testAddressStrings = new List<string>
				{
					"Test Testesens Vej 7  ST151",
					"Test Testesens Vej 7  ST. 151",
					"Test Testesens Vej 7,  st. dør 151",
					"TEST TESTESENS Vej 7 s.t. 151",
					"Test Testesens Vej 7 st, nr. 151",
					"Test Testesens Vej 7 ST lejlighed 151",
					"Test TESTESENS Vej 7 st. lejl. 151",
					"Test Testesens Vej 7 st. dør 151",
					"Test Testesens Vej 7 st. dør. 151"
				};

			var assertedAddress = new DanishAddress
			{
				StreetName = "Test Testesens Vej",
				HouseNumber = 7,
				Floor = 0,
				DoorOrRoomNo = 151
			};

			foreach (var testAddressString in testAddressStrings)
			{
				var testAddress = Services.DefaultIAddressParseService.ParseAddress(testAddressString);
				Assert.AreEqual(assertedAddress, testAddress);
			}
		}

		[TestMethod]
		public void FloorNumberAndRoomNumber()
		{
			var testAddressStrings = new List<string>
				{
					"Testvej 10, 04-02",
					"Testvej 10, 4.2",
					"Testvej 10.4.2",
					"Testvej 10 4 2",
					"Testvej 10 4 Dør: 0002",
					"Testvej 10 4. sal dør 2",
					"Testvej 10 .4 -2",
					"Testvej 10 4, nr. 2"
				};

			var assertedAddress = new DanishAddress
			{
				StreetName = "Testvej",
				HouseNumber = 10,
				Floor = 4,
				DoorOrRoomNo = 2
			};

			foreach (var testAddressString in testAddressStrings)
			{
				var testAddress = Services.DefaultIAddressParseService.ParseAddress(testAddressString);
				Assert.AreEqual(assertedAddress, testAddress);
			}
		}


	}
}
