namespace AddressParser.NET.Model.AddressTypes
{
	public class DanishAddress
	{
		public string StreetName { get; set; }
		public int HouseNumber { get; set; }
		public string HouseLetter { get; set; }
		public int? Floor { get; set; }
		public ApartmentSide? Side { get; set; }
		public int? DoorOrRoomNo { get; set; }

		public override string ToString()
		{
			return string.Format("{0};{1};{2};{3};{4};{5};", 
				StreetName,
				HouseNumber,
				HouseLetter,
				Floor,
				Side,
				DoorOrRoomNo
				);
		}
	}
}
