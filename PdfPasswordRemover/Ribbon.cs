using Microsoft.Office.Core;
using Microsoft.Office.Interop.Outlook;
using PdfPasswordRemover.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;

// TODO:  Follow these steps to enable the Ribbon (XML) item:

// 1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new Ribbon();
//  }

// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


namespace PdfPasswordRemover
{
    [ComVisible(true)]
    public class Ribbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        public Ribbon()
        {
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("PdfPasswordRemover.Ribbon.xml");
        }

        public Bitmap GetPwdIcon(IRibbonControl control)
        {
            return Resources.PwdPng;
        }

        public Bitmap GetUnlockIcon(IRibbonControl control)
        {
            return Resources.UnlockPng;
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit https://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        public void OnRemovePwd(IRibbonControl control)
        {
            var oApp = new Application();
            var explorer = oApp.ActiveExplorer();

            if (explorer.Selection.Count > 0)
            {
                var selectedItem = explorer.Selection[1];
                var mailItem = selectedItem as MailItem;

                if(mailItem != null && mailItem.Attachments.Count > 0)
                {
                    var attachment = mailItem.Attachments[1];
                    attachment.SaveAsFile(Path.Combine(Environment.CurrentDirectory, attachment.FileName));
                    var unlockedFilename = PDFManager.removePassword(Path.Combine(Environment.CurrentDirectory, attachment.FileName), PwdManager.Instance.Password);
                    Process.Start(Path.Combine(Environment.CurrentDirectory, unlockedFilename));
                }
            }
        }

        public void OnSetPwd(IRibbonControl control)
        {
            new PwdWindow().ShowDialog();
        }

        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
