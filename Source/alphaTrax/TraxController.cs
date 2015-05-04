using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Windows.Forms;
using System.Drawing;

namespace alphaTrax
{
    public class TraxController
    {
        string filename = "trax.edf";

        public void HookFiles(string baseDir, string hookedFiles)
        {
            var defFile = Path.Combine(baseDir, filename);
            MessageBox.Show(string.Format("{0} to {1}", hookedFiles, defFile));
            System.IO.File.WriteAllText(defFile, "Hooks:" + hookedFiles);
        }

        public string GetHookedFiles(string baseDir)
        {
            var defFile = Path.Combine(baseDir, filename);
            string hooks = null;
            string[] lines = System.IO.File.ReadAllLines(defFile);

            
            foreach (string line in lines)
            {
                if (line.Contains("Hooks:"))
                    hooks = line.Replace("Hooks:", "");
            }

            return hooks;
        }
    }
}
