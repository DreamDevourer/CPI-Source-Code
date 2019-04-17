// FieldNameGetter
using System;
using System.Linq.Expressions;

public static class FieldNameGetter
{
	public static string Get<T, TMember>(Expression<Func<T, TMember>> expression)
	{
		return ((MemberExpression)expression.Body).Member.Name;
	}
}
