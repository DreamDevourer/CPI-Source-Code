// IGameData
using ClubPenguin.Core.StaticGameData;

public interface IGameData
{
	T Get<T>();

	TDefinition GetDefinitionById<TDefinition, TId>(TypedStaticGameDataKey<TDefinition, TId> staticGameDataKey) where TDefinition : StaticGameDataDefinition;

	bool IsAvailable<T>();
}
