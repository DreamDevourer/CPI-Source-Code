// MoveData
using ClubPenguin.MiniGames.BlockAndLock;
using UnityEngine;

public class MoveData : Component
{
	public Grid2 stopPos;

	public bool hitPiece;

	public MoveData(Grid2 stopPos, bool hitPiece)
	{
		this.stopPos = stopPos;
		this.hitPiece = hitPiece;
	}
}
