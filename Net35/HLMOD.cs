using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Net35
{
    public class HLMOD
    {
        private string name, modfolder, version, execFile;
        private Image icon;

        public string Name { get { return name; } }
        public string ModFolder { get { return modfolder; } }
        public string Version { get { return version; } }
        public string Executable { get { return execFile; } set { execFile = value; } }
        public Image Icon { get { return icon; } }

        public HLMOD(string name, string modfolder, string version, string execFile, Image icon)
        {
            this.name = name;
            this.modfolder = modfolder;
            this.version = version;
            this.execFile = execFile;
            this.icon = icon;
        }
    }
}
