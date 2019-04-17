// IDatabaseDirectoryCreator
public interface IDatabaseDirectoryCreator
{
	string CreateSdkDirectory(string documentCollectionName);

	string CreateUserDirectory();

	string CreateUserDirectory(string documentCollectionName);

	string GetSdkDatabasesDirectory();
}
