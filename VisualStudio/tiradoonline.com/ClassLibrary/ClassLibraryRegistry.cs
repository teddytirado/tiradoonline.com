using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryNameSpace
{
    public class ClassLibraryRegistry
    {
        public string registryFolder = @"HKEY_CURRENT_USER\Software\tiradoonline.com";
        string _DatabaseConnectionString;

        public ClassLibraryRegistry()
        {
            _DatabaseConnectionString = (string)Registry.GetValue(registryFolder, "DatabaseConnectionString", null);
        }

        public string DatabaseConnectionString
        {
            get
            {
                return this._DatabaseConnectionString;
            }
            set
            {
                Registry.SetValue(registryFolder, "DatabaseConnectionString", value);
                this._DatabaseConnectionString = value;
            }
        }
    }
}
