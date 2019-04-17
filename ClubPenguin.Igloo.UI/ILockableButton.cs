// ILockableButton
public interface ILockableButton
{
	void SetMemberLocked();

	void SetLevelLocked(int level);

	void SetProgressionLocked(string mascotName);

	void SetUnlocked();
}
