// CompetitionRules<T>
using ClubPenguin.Compete;
using System.Collections.Generic;

public abstract class CompetitionRules<T>
{
	public abstract void AssignPointsToCompetitors(List<Competitor<T>> competitors);
}
