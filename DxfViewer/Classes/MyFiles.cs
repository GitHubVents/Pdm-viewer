using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Forms.Integration;
using EdmLib;

namespace DxfAndPDFViewer.Classes
{
    class MyFiles : MyPrograms //, IDisposable
    {
        WindowsFormsHost hostWin;
        UIElement pdfViewer;
        UIElement eDrwViewer;
        EDRWControl edrw = new EDRWControl();
        PDFControl pdf = new PDFControl();
        // Метка открытия типа файлов: m-0 = SolidWorks, m-1 = Pdf
        public MyFiles(Grid HostControl)
        {
            pdfViewer = new WindowsFormsHost { Child = pdf };
            eDrwViewer = new WindowsFormsHost { Child = edrw };
            HostControl.Children.Insert(0, pdfViewer);
            HostControl.Children.Insert(1, eDrwViewer);
            pdfViewer.Visibility = Visibility.Hidden;
            eDrwViewer.Visibility = Visibility.Hidden;
        }
        public void OpenFile(int m, EpdmVault.ColumnsBind item)
        {
            try
            {
                switch (m)
                {
                    case 1:
                        GetAndStartProcess("SLDWORKS", item.FilePath);
                        break;
                    case 2:
                        GetAndStartProcess("PDF", item.FilePath);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }
        public void ShowFileOnControl(int m, EpdmVault.ColumnsBind item)
        {
            try
            {
                GetFileCopy(item);
                hostWin = new WindowsFormsHost();
                switch (m)
                {
                    case 1:
                        m = 1;
                        edrw.OpenFile(item.FilePath);
                        pdfViewer.Visibility = Visibility.Hidden;
                        eDrwViewer.Visibility = Visibility.Visible;

                        break;
                    case 2:
                        m = 2;

                        pdf.OpenFile(item.FilePath);
                        eDrwViewer.Visibility = Visibility.Hidden;
                        pdfViewer.Visibility = Visibility.Visible;

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ", \n" + ex.StackTrace);
            }
        }
        void GetFileCopy(EpdmVault.ColumnsBind item)
        {
            var LocWin = new LoadLocalFile();
            LocWin.Show();
             var oFolder = default(IEdmFolder5);
            var aFile = EpdmVault.vault.GetFileFromPath(item.FilePath, out oFolder);
            if (aFile == null)
            {
                MessageBox.Show("Файл не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            aFile.GetFileCopy(0, "", item.FolderId, (int)EdmGetFlag.EdmGet_MakeReadOnly + (int)EdmGetFlag.EdmGet_Simple);
            LocWin.Close();
        }
        public void Dispose()
        {
            try
            {
                if (hostWin != null)
                {
                    //hostWin.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ", \n" + ex.StackTrace);
            }

        }
        ~MyFiles()
        {
            Dispose();
        }
    }
}