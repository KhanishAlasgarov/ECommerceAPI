using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Extensions
{
    public static class StorageExtension
    {
        public static string FileRename(this IFormFile file, string pathOrContainerName, Func<string, string, bool> hasFile)
        {
            string extension = Path.GetExtension(file.FileName);
            string oldName = Path.GetFileNameWithoutExtension(file.FileName);

            string newName = oldName.CharacterRegulatory();
            int index = 0;
            string newFileName = $"{newName}-{index}{extension}";


            while (hasFile(pathOrContainerName, newFileName))
            {
                index++;
                newFileName = $"{newName}-{index}{extension}";
            }
            return newFileName;
        }

        private static string CharacterRegulatory(this string name)
           => name.Replace("\"", "")
               .Replace("!", "")
               .Replace("'", "")
               .Replace("^", "")
               .Replace("+", "")
               .Replace("%", "")
               .Replace("&", "")
               .Replace("/", "")
               .Replace("(", "")
               .Replace(")", "")
               .Replace("=", "")
               .Replace("?", "")
               .Replace("_", "")
               .Replace(" ", "-")
               .Replace("@", "")
               .Replace("€", "")
               .Replace("¨", "")
               .Replace("~", "")
               .Replace(",", "")
               .Replace(";", "")
               .Replace(":", "")
               .Replace(".", "-")
               .Replace("Ö", "o")
               .Replace("ö", "o")
               .Replace("Ü", "u")
               .Replace("ü", "u")
               .Replace("ı", "i")
               .Replace("İ", "i")
               .Replace("ğ", "g")
               .Replace("Ğ", "g")
               .Replace("æ", "")
               .Replace("ß", "")
               .Replace("â", "a")
               .Replace("î", "i")
               .Replace("ş", "s")
               .Replace("Ş", "s")
               .Replace("Ç", "c")
               .Replace("ç", "c")
               .Replace("<", "")
               .Replace(">", "")
               .Replace("|", "");
    }
}
