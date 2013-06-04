namespace AddressParser.Model.AddressTypes
{
	public class DanishAddress
	{
		public string StreetName { get; set; }
		public int HouseNumber { get; set; }
		public string HouseLetter { get; set; }
		public int? Floor { get; set; }
	}
}
