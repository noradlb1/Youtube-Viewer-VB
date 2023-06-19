Imports System
Imports System.Windows.Forms

Namespace Youtube_Viewer_Form
    Friend Module Program
        ''' <summary>
        '''  The main entry point for the application.
        ''' </summary>
        <STAThread>
        Private Sub Main()
            Application.SetHighDpiMode(HighDpiMode.SystemAware)
            Call Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Call Application.Run(New Form1())
        End Sub
    End Module
End Namespace
