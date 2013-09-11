using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressParser.NET.IoCBootstrap;
using AddressParser.NET.Model;
using AddressParser.NET.Model.AddressTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressParser.NET.Tests
{
	[TestClass]
	public class AddressFormatsParseTestSide
	{
		protected ServiceWrapper Services { get; set; }
		protected Dictionary<string, DanishAddress> AddressAssertions { get; set; }

		[TestInitialize]
		public void Init()
		{
			this.Services = IoCHelper.GetDefaultServices();
		}

		[TestMethod]
		public void SideOnly()
		{
			var testAddressStrings = new List<string>
				{
					"Testvej 10, t.h.",
					"Testvej 10 th.",
					"Testvej 10, TH",
				};

			var assertedAddress = new DanishAddress
			{
				StreetName = "Testvej",
				HouseNumber = 10,
				//Floor = 0,
				Side = ApartmentSide.TH
			};

			foreach (var testAddressString in testAddressStrings)
			{
				var testAddress = Services.DefaultIAddressParseService.ParseAddress(testAddressString);
				Assert.AreEqual(assertedAddress, testAddress);
			}
		}

		[TestMethod]
		public void LetterFloorAndSide()
		{
			var testAddressStrings = new List<string>
				{
					"Testvej 10b 3. sal mf",
					"Testvej 10B - 3. mf.",
					"Testvej 10 b - 3 mf",
					"Testvej 10b, 3. mf",
					"Testvej 10b, 3. sal, MF",
					"Testvej 10b, 3 mf",
					"Testvej 10b 3sal mf."
				};

			var assertedAddress = new DanishAddress
			{
				StreetName = "Testvej",
				HouseNumber = 10,
				HouseLetter = "b",
				Floor = 3,
				Side = ApartmentSide.MF
			};

			foreach (var testAddressString in testAddressStrings)
			{
				var testAddress = Services.DefaultIAddressParseService.ParseAddress(testAddressString);
				Assert.AreEqual(assertedAddress, testAddress);
			}
		}
	}
}
