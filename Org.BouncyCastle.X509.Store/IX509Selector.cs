// IX509Selector
using System;

public interface IX509Selector : ICloneable
{
	bool Match(object obj);
}
