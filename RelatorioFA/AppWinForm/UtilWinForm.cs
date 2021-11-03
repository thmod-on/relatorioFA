using System.Windows.Forms;

namespace RelatorioFA.AppWinForm
{
    public class UtilWinForm
    {
        public static string SetOutputDocPath()
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };

            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                return folderDlg.SelectedPath;
            }
            return null;
        }
    }
}
