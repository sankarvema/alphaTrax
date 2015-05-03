using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace alphaTrax
{
    public class TraxController
    {
        string filename = "trax.def";

        public void HookFiles(string files)
        {
            System.IO.File.WriteAllText(filename, files);
        }
    }
}
