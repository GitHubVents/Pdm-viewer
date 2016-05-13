using System.Windows.Forms;

namespace DxfAndPDFViewer
{
    public partial class EDRWControl : UserControl
    {
        public EDRWControl()
        {
            InitializeComponent();
        }
        public void CloseFile(string path)
        {
            axEModelViewControl1.CloseActiveDoc(path);
            axEModelViewControl1.Refresh();
        }
        public void OpenFile(string path)
        {
            axEModelViewControl1.OpenDoc(path, false, false, true, "");
        }
    }
}
