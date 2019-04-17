// InputResult<TResult>
public abstract class InputResult<TResult>
{
	public abstract void CopyTo(TResult copyToInputResult);

	public abstract void Reset();
}
