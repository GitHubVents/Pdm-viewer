using System.Windows;
using System.IO;
using System;
using System.Windows.Controls;
using DxfAndPDFViewer.Classes;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Deployment.Application;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;
using DxfAndPDFViewer;
using EdmLib;

namespace DxfViewer
{
    public partial class MainWindow : Window // , IDisposable
    {
        MyFiles myFiles { get; set; }
        //Task myTask;
        public int m { get; set; }
        EpdmVault.ColumnsBind selectItem
        {
            get
            {
                try
                {
                    return DgFiles.SelectedItem as EpdmVault.ColumnsBind;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            {
                Title = $"Поиск PDM ver: { GetPublishedVersion() }";
            };
            try
            {
                myFiles = new MyFiles(HostControl);
                //myFiles.FindAndKillProcess("AcroRd32");
                //myFiles.FindAndKillProcess("AddInSrv");
                GenerateContextMenu();
                var rowStyle = new Style(typeof(DataGridRow));
                rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent, new MouseButtonEventHandler(Row_DoubleClick)));
                DgFiles.RowStyle = rowStyle;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + ", \n" + ex.StackTrace);
            }
        }
        private string GetPublishedVersion()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            return "Not network deployed";
        }
        private void DgFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (selectItem == null) return;
                var extension = Path.GetExtension(selectItem.FilePath);
                switch (extension.ToLower())
                {
                    case ".dxf":
                    case ".eprt":
                    case ".easm":
                    case ".edrw":
                    case ".sldprt":
                    case ".sldasm":
                    case ".slddrw":
                        m = 1;
                        myFiles.ShowFileOnControl(m, selectItem);
                        break;
                    case ".pdf":
                        m = 2;
                        myFiles.ShowFileOnControl(m, selectItem);
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + ", \n" + ex.StackTrace);
            }
        }
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtBoxSearch.Text)) return;
                DgFiles.ItemsSource = null;
                DgFiles.ItemsSource = EpdmVault.SearchDoc(TxtBoxSearch.Text);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + ", \n" + ex.StackTrace);
            }
        }
        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtnSearch_Click( sender, null);
            }
        }
        private void GenerateContextMenu()
        {
            DgFiles.ContextMenu = ContextM.BuildContextMenu(OpenFile_Click, OpenPdmFolder_Click);
        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenFile(m);
        }
        void OpenFile(int m)
        {
            myFiles.OpenFile(m, selectItem);
        }
        // Меню открыть файл
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFile(m);
        }
        // Открыл папку с файлом
        private void OpenPdmFolder_Click(object sender, RoutedEventArgs e)
        {
            EpdmVault.Vault8.OpenContainingFolder(Convert.ToInt32(selectItem.FileId), 0);
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            myFiles.FindAndKillProcess("AddInSrv");
            myFiles.FindAndKillProcess("AcroRd32");
        }
    }
}