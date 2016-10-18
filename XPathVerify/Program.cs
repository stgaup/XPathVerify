using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using XPathLib;

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
            bool? isMissing = args.Length > 3 ? bool.Parse(args[3]) : false;

            FileUtil.Do(rootPath, wildcard, xPath, isMissing, single);

        }

        static bool single(string fullFilePath, string xPath)
        {
            var doc = XDocument.Load(fullFilePath);
            var elements = doc.XPathSelectElements(xPath);
            return elements.Count() > 0;
        }
    }
}
