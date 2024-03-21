using ECommerceAPI.Infrastructure.Operations;

namespace ECommerceAPI.Infrastructure.Services.Storage;

public class Storage
{
    protected delegate bool HasFile(string pathOrContainerName, string fileName);
    protected string FileRenameAsync(string pathOrContainerName, string fileName, HasFile hasFileMethod, bool first = true)
    {
        string extension = Path.GetExtension(fileName);
        string oldName = Path.GetFileNameWithoutExtension(fileName);

        string newName = NameOperation.CharacterRegulatory(oldName);
        int index = 0;
        string newFileName = $"{newName}-{index}{extension}";


        while (hasFileMethod(pathOrContainerName, fileName))
        {
            index++;
            newFileName = $"{newName}-{index}{extension}";
        }
        return newFileName;
    }
}
