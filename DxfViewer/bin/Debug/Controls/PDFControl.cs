using System.Windows.Forms;

namespace DxfAndPDFViewer
{
    public partial class PDFControl : UserControl
    {
        public PDFControl()
        {
            InitializeComponent();
        }
        //setPageMode({ pageMode: "none"}); ---> the Navigation Panel is NOT visible(see Tim's screenshot in previous post)
        //setPageMode({ pageMode: "thumbnails"}); ---> the Navigation Panel is visible and expanded displaying thumbnails
        //setPageMode({ pageMode: "bookmarks"});
        public void OpenFile(string path)
        {
            axAcroPDF1.LoadFile(path);
            axAcroPDF1.setPageMode("none");
            axAcroPDF1.setShowToolbar(false);
            //axAcroPDF1.ShowPropertyPages();
        }
    }
}