using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressParser.Impl.Parsing
{
	public static class Regexes
	{
		public static Regex DefaultAddress = new Regex(@"", RegexOptions.IgnoreCase | RegexOptions.Compiled);
	}
}
