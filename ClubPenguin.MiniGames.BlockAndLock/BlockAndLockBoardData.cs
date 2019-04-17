// BlockAndLockBoardData
using ClubPenguin.MiniGames.BlockAndLock;
using UnityEngine;

public class BlockAndLockBoardData : Component
{
	public PieceCategory Category;

	public int Id;

	public BlockAndLockBoardData(PieceCategory category, int id)
	{
		Category = category;
		Id = id;
	}
}
