using System;

namespace AddressParser.NET.Model.AddressTypes
{
	public class DanishAddress : IEquatable<DanishAddress>
	{
		public string StreetName { get; set; }
		public int HouseNumber { get; set; }
		public string HouseLetter { get; set; }
		public int? Floor { get; set; }
		public ApartmentSide? Side { get; set; }
		public int? DoorOrRoomNo { get; set; }

		public bool Equals(DanishAddress other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return
				string.Equals(StreetName, other.StreetName)
				&& HouseNumber == other.HouseNumber
				&& string.Equals(HouseLetter, other.HouseLetter)
				&& Floor == other.Floor
				&& Side == other.Side
				&& DoorOrRoomNo == other.DoorOrRoomNo;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((DanishAddress) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (StreetName != null ? StreetName.GetHashCode() : 0);
				hashCode = (hashCode*397) ^ HouseNumber;
				hashCode = (hashCode*397) ^ (HouseLetter != null ? HouseLetter.GetHashCode() : 0);
				hashCode = (hashCode*397) ^ Floor.GetHashCode();
				hashCode = (hashCode*397) ^ Side.GetHashCode();
				hashCode = (hashCode*397) ^ DoorOrRoomNo.GetHashCode();
				return hashCode;
			}
		}

		public static bool operator ==(DanishAddress left, DanishAddress right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(DanishAddress left, DanishAddress right)
		{
			return !Equals(left, right);
		}

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
