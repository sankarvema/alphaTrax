using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpShell;
using SharpShell.SharpContextMenu;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using SharpShell.Attributes;
using System.IO;

namespace alphaTrax
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.ClassOfExtension, ".jpg")]
    public class HookFileContextMenu : SharpContextMenu
    {
        protected override bool CanShowMenu()
        {
            return true;
        }

        protected override System.Windows.Forms.ContextMenuStrip CreateMenu()
        {
            //  Create the menu strip.
            var menu = new ContextMenuStrip();

            //  Create a 'count lines' item.
            var itemHookFile = new ToolStripMenuItem
            {
                Text = "Hook File(s)",
                //Image = Properties.Resources.CountLines
            };

            //  When we click, we'll count the lines.
            itemHookFile.Click += (sender, args) => HookFiles();

            //  Add the item to the context menu.
            menu.Items.Add(itemHookFile);

            //  Return the menu.
            return menu;
        }

        private void HookFiles()
        {
            string files = null;

            //  Go through each file.
            var counter = 0;
            foreach (var filePath in SelectedItemPaths)
            {
                //  Count the lines.
                files += Path.GetFileName(filePath) + ",";
                counter++;
            }

            TraxController cnt = new TraxController();
            cnt.HookFiles(files);

            MessageBox.Show(string.Format("{0} file(s) hooked to folder preview", counter.ToString()));
        }
    }
}
