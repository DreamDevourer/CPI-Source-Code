// WriteDelegate<T>
using JsonFx.Json;

public delegate void WriteDelegate<T>(JsonWriter writer, T value);
