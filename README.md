Reads XML files and checks if the given XPath exists.

Usage:  
XPathVerify.exe [RootPath] [XPath] [IsMissing]  

RootPath - Where in the file system to start looking.  
XPath - The XPath of the element to look for.
IsMissing (y/n) (optional) - Only output the files that are missing? If omitted, all files will be listed with an indication of wether or not they contain the xml element which the XPath is pointing to.


Examples:

Find all web.config files which have a targetFramework of 4.6.1:  
XPathVerify.exe C:\DevProjects\MyProject web*.config /configuration/system.web/compilation[@targetFramework='4.6.1'] n

Find all web.config files which do not have a targetFramework of 4.6.1:  
XPathVerify.exe C:\DevProjects\MyProject web*.config /configuration/system.web/compilation[@targetFramework='4.6.1'] y

Find all web.config files, and write out wether or not they have the correct target framework:  
XPathVerify.exe C:\DevProjects\MyProject web*.config /configuration/system.web/compilation[@targetFramework='4.6.1'] n

Find out how many web.config files have the targetFramework set to 4.6.1, by piping to the dos FIND-command:  
XPathVerify.exe C:\DevProjects\MyProject web*.config /configuration/system.web/compilation[@targetFramework='4.6.1'] n | 
find /c /v ""  

Just for fun...
