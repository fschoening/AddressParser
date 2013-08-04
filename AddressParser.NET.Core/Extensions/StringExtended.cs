using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressParser.NET.Core.Extensions
{
	public static class StringExtended
	{
		public static string CapitalizeFirstLowercaseRest(this string s)
		{
			if (string.IsNullOrEmpty(s))
				return s;

			var a = s.ToCharArray();
			a[0] = char.ToUpper(a[0]);
			return new string(a);
		}
	}
}
