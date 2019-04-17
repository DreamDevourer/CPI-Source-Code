// RoomItem
using ClubPenguin;
using ClubPenguin.Net.Domain.Igloo;
using System;
using System.Collections.Generic;

[Serializable]
public class RoomItem
{
	public WorldTransform worldTransform;

	private List<CustomItemProperty> _customProperties;

	public int pieceNumber;

	public List<CustomItemProperty> customProperties
	{
		get
		{
			if (_customProperties == null)
			{
				_customProperties = new List<CustomItemProperty>();
			}
			return _customProperties;
		}
		set
		{
			_customProperties = value;
		}
	}

	public static RoomItem FromPlaceableObject(PlaceableObject placeableObject)
	{
		RoomItem roomItem = new RoomItem();
		roomItem.pieceNumber = placeableObject.PieceNumber;
		roomItem.worldTransform = WorldTransform.FromTransform(placeableObject.transform);
		return roomItem;
	}

	public override string ToString()
	{
		return $"WorldTransform: {worldTransform}, CustomItemProperties: {customProperties}, PieceNumber: {pieceNumber}";
	}

	protected bool Equals(RoomItem other)
	{
		return worldTransform.Equals(other.worldTransform) && object.Equals(_customProperties, other._customProperties) && pieceNumber == other.pieceNumber;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj.GetType() != GetType())
		{
			return false;
		}
		return Equals((RoomItem)obj);
	}

	public override int GetHashCode()
	{
		int hashCode = worldTransform.GetHashCode();
		hashCode = ((hashCode * 397) ^ ((_customProperties != null) ? _customProperties.GetHashCode() : 0));
		return (hashCode * 397) ^ pieceNumber;
	}
}
