using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XPathVerify
{
    class Program
    {
        static void Main(string[] args)
        {
            //args:

            // 0: RootFilePath
            var rootPath = args[0];

            // 1: FileNameWildcard
            var wildcard = args[1];

            // 2: XPath
            var xPath = args[2];

            // 3: missing
            var isMissing = args.Length > 3 ? args[3] : null;

            var files = Directory.GetFiles(rootPath, wildcard, SearchOption.AllDirectories);

            foreach(var fileName in files)
            {
                var r = single(fileName, xPath);
                if (string.IsNullOrWhiteSpace(isMissing) //all files of the type
                    || (isMissing.ToLowerInvariant() == "y" && !r)
                    || (isMissing.ToLowerInvariant() == "n" && r))
                    if (string.IsNullOrWhiteSpace(isMissing))
                        Console.WriteLine($"Found:{(r ? "y" : "n")} >>> {fileName}");
                    else
                        Console.WriteLine(fileName);
            }
        }

        static bool single(string fullFilePath, string xPath)
        {
            var doc = XDocument.Load(fullFilePath);
            var elements = doc.XPathSelectElements(xPath);
            return elements.Count() > 0;
        }
    }
}
