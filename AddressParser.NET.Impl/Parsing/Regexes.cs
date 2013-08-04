using System.Text.RegularExpressions;

namespace AddressParser.NET.Impl.Parsing
{
	public static class Regexes
	{
		private const RegexOptions _regexOptions = RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace;
		public static Regex ImmaParseAnAddress = new Regex(@"
^(?<StreetName>[\p{L} .]+)
[\s]+?
(?<HouseNumber>\d+)

(?:[\s,.]*
(?:hus[\s,.-]*?)?(?<HouseLetter>\p{L})
)?

(?:[\s,.-]*?
(?<Floor>-?\d+[.\s]*?(?:sal)?|s\.?t\.?u?e?n?|kld?r?\.?)
)?

(?:[\s,.-]*?
(?:
(?<Side>t[.\s]*[hv]\.?|m\.?f\.?)
|
(?:(?:dør|nr|le?j?l?i?g?h?e?d?|stue)[.:]?\s*)?(?<DoorOrRoomNo>\d+)\.?
)
)?
$", _regexOptions);
	}
}
