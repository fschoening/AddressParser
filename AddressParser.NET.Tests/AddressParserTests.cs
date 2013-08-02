using System;
using System.Collections.Generic;
using AddressParser.NET.IoCBootstrap;
using AddressParser.NET.Model.AddressTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressParser.NET.Tests
{
	[TestClass]
	public class AddressParserTests
	{
		[TestInitialize]
		public void Init()
		{
			this.Services = IoCHelper.GetDefaultServices();
			
		}

		protected ServiceWrapper Services { get; set; }

		protected Dictionary<string, DanishAddress> AddressAssertions { get; set; }

		//[TestMethod]
		public void TestParseSampleAddresses()
		{
			var testAddresses = Services.DefaultITestDataLoader.GetTestAddresses(@"D:\Schoening.it\_stuff\test_adresser_01.txt");

			foreach (var testAddress in testAddresses)
			{
				try
				{

				}
				catch (Exception e)
				{
					Assert.IsTrue(false, string.Format("Parser threw exception of type '{0}'", e.Message));
				}
			}
		}
	}
}