Imports DevExpress.Xpf.Printing
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.Printing
Imports System.Printing
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports DevExpress.Xpf.Ribbon
Imports DevExpress.Xpf.Bars
Imports System.Drawing.Printing
Imports DevExpress.Drawing.Printing

Namespace WPFRichEditControlPrintingTechniques
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits DXRibbonWindow

        Public Sub New()
            InitializeComponent()
            richEdit.LoadDocument("Grimm.docx", DocumentFormat.OpenXml)
        End Sub


        Private Sub BarButtonItem_ItemClick_1(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            UsePrintingLibrary()
        End Sub
        Private Sub UsePrintingLibrary()
            '            #Region "#PrintableComponentLink"
            'Initialize a new server and printer 
            Dim printDialog As New PrintDialog()
            Dim docServer As New RichEditDocumentServer()

            'Pass the document content to the server  
            docServer.RtfText = richEdit.RtfText

            'Change the document layout
            docServer.Document.Sections(0).Page.Landscape = True
            docServer.Document.Sections(0).Page.PaperKind = DXPaperKind.A4

            'Create a new component link 
            Dim printableComponent As New LegacyPrintableComponentLink(docServer)

            'Create a document to print 
            printableComponent.CreateDocument(False)

            'Silently print the document
            printableComponent.PrintDirect()
            '            #End Region ' #PrintableComponentLink
        End Sub
    End Class
End Namespace
