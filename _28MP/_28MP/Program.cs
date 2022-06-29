using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Word = Microsoft.Office.Interop.Word;
namespace _28MP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login());
        }

       
    }
    public static class LoginInfo
    {
        public static string UserName = "";
    }
    public static class SearchinWord
    {
        public static void FindAndReplace(Word.Application wordApp, object ToFindText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllforms = false;
            object forward = false;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref ToFindText, ref matchCase, ref matchWholeWord, ref matchWildCards, ref matchSoundLike, ref nmatchAllforms,
            ref forward, ref wrap, ref format, ref replaceWithText, ref replace, ref matchKashida, ref matchDiactitics, ref matchAlefHamza, ref matchControl);

            //find inside header
            foreach (Word.Section section in wordApp.ActiveDocument.Sections)
            {
                Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                headerRange.Find.Execute(ref ToFindText, ref matchCase, ref matchWholeWord, ref matchWildCards, ref matchSoundLike, ref nmatchAllforms,
                ref forward, ref wrap, ref format, ref replaceWithText, ref replace, ref matchKashida, ref matchDiactitics, ref matchAlefHamza, ref matchControl);
            }

        }

    }

}
