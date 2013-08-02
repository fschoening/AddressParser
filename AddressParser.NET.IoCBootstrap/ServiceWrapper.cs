using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressParser.Model.Interfaces;

namespace AddressParser.IoCBootstrap
{
	public class ServiceWrapper
	{
		public ITestDataLoader DefaultITestDataLoader { get; set; }
		public IAddressParseService DefaultIAddressParseService { get; set; }
	}
}
