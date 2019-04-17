// CmsProcessable
using System;
using System.IO;

public interface CmsProcessable
{
	void Write(Stream outStream);

	[Obsolete]
	object GetContent();
}
