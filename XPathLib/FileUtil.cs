using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPathLib
{
    public static class FileUtil
    {
        public static void Do(string rootPath, string wildcard, string xPath, bool? isMissing, Func<string,string,bool> action)
        {

            var files = Directory.GetFiles(rootPath, wildcard, SearchOption.AllDirectories);

            foreach (var fileName in files)
            {
                var r = action(fileName, xPath);
                if (!isMissing.HasValue //all files of the type
                    || (isMissing.Value && !r)
                    || (!isMissing.Value && r))
                    if (!isMissing.HasValue)
                        Console.WriteLine($"Found:{(r ? "y" : "n")} >>> {fileName}");
                    else
                        Console.WriteLine(fileName);
            }
        }
    }

}
