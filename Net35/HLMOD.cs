using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Net35
{
    public class HLMOD
    {
        private string name, modfolder, version;
        private Image icon;

        public string Name { get { return name; } }
        public string ModFolder { get { return modfolder; } }
        public string Version { get { return version; } }
        public Image Icon { get { return icon; } }

        public HLMOD(string name, string modfolder, string version, Image icon)
        {
            this.name = name;
            this.modfolder = modfolder;
            this.version = version;
            this.icon = icon;
        }
    }
}
