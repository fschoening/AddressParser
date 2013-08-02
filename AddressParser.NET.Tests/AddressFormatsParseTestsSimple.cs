using System.Collections.Generic;
using AddressParser.NET.IoCBootstrap;
using AddressParser.NET.Model.AddressTypes;
using AddressParser.NET.Model.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressParser.NET.Tests
{
	[TestClass]
	public class AddressFormatsParseTestsSimple
	{
		protected ServiceWrapper Services { get; set; }
		protected Dictionary<string, DanishAddress> AddressAssertions { get; set; }

		[TestInitialize]
		public void Init()
		{
			this.Services = IoCHelper.GetDefaultServices();
		}

		[TestMethod]
		public void SimpleAddress()
		{
			const string testAddressString = "Testvej 10";
			var testAddress = Services.DefaultIAddressParseService.ParseAddress(testAddressString);
			var assertedAddress = new DanishAddress
				{
					StreetName = "Testvej",
					HouseNumber = 10
				};

			Assert.AreEqual(assertedAddress, testAddress);
		}

		[TestMethod]
		[ExpectedException(typeof(AddressParseException))]
		public void SimpleAddressNoSpaceBeforeHouseNumber()
		{
			const string testAddressString = "Testvej10";
			var testAddress = Services.DefaultIAddressParseService.ParseAddress(testAddressString);
			var assertedAddress = new DanishAddress
			{
				StreetName = "Testvej",
				HouseNumber = 10
			};

			Assert.AreEqual(assertedAddress, testAddress);
		}

		[TestMethod]
		public void SimpleAddressWithSpacesInStreetName()
		{
			const string testAddressString = "Testens Vej 10";
			var testAddress = Services.DefaultIAddressParseService.ParseAddress(testAddressString);
			var assertedAddress = new DanishAddress
			{
				StreetName = "Testens Vej",
				HouseNumber = 10
			};

			Assert.AreEqual(assertedAddress, testAddress);
		}

		[TestMethod]
		[ExpectedException(typeof(AddressParseException))]
		public void SimpleAddressWithSpacesInStreetNameButNoSpaceBeforeHousenumber()
		{
			const string testAddressString = "Testens vej10";
			var testAddress = Services.DefaultIAddressParseService.ParseAddress(testAddressString);
			var assertedAddress = new DanishAddress
			{
				StreetName = "Testens vej",
				HouseNumber = 10
			};

			Assert.AreEqual(assertedAddress, testAddress);
		}

		[TestMethod]
		public void SimpleAddressWithSpacesAndPunctuationInStreetName()
		{
			const string testAddressString = "Skt. Testens Vej 10";
			var testAddress = Services.DefaultIAddressParseService.ParseAddress(testAddressString);
			var assertedAddress = new DanishAddress
			{
				StreetName = "Skt. Testens Vej",
				HouseNumber = 10
			};

			Assert.AreEqual(assertedAddress, testAddress);
		}
	}
}
