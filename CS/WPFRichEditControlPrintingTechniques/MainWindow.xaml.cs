using DevExpress.Xpf.Printing;
using DevExpress.XtraRichEdit;
using System.Windows.Controls;
using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.Bars;
using System.Drawing.Printing;

namespace WPFRichEditControlPrintingTechniques
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXRibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            richEdit.LoadDocument("Grimm.docx", DocumentFormat.OpenXml);
        }
        private void BarButtonItem_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            UsePrintingLibrary();
        }
        private void UsePrintingLibrary()
        {
            #region #PrintableComponentLink
            //Initialize a new server and printer 
            PrintDialog printDialog = new PrintDialog();
            RichEditDocumentServer docServer = new RichEditDocumentServer();

            //Pass the document content to the server  
            docServer.RtfText = richEdit.RtfText;

            //Change the document layout
            docServer.Document.Sections[0].Page.Landscape = true;
            docServer.Document.Sections[0].Page.PaperKind = PaperKind.A4;            

            //Create a new component link 
            LegacyPrintableComponentLink printableComponent = new LegacyPrintableComponentLink(docServer);
           
            //Create a document to print 
            printableComponent.CreateDocument(false);

            //Silently print the document
            printableComponent.PrintDirect();
            #endregion #PrintableComponentLink
        }
    }
}
