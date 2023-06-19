Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports System.Net
Imports Leaf.xNet
Imports Youtube_Viewers.Helpers
Imports System.IO

'Credit https://github.com/Airkek/Youtube-Viewers

Namespace Youtube_Viewer_Form
    Public Partial Class Form1
        Inherits Form
        Private Shared id As String = ""
        Private Shared threadsCount As Integer = 1000

        Private Shared scraper As ProxyQueue
        Private Shared proxyType As ProxyType = ProxyType.HTTP

        Private Shared botted As Integer = 0
        Private Shared errors As Integer = 0

        Private Shared viewers As String = "Parsing..."
        Private Shared title As String = "Parsing..."

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Shared Function buildUrl(ByVal args As Dictionary(Of String, String)) As String
            Dim url = "https://s.youtube.com/api/stats/watchtime?"
            For Each arg In args
                url += $"{arg.Key}={arg.Value}&"
            Next
            Return url
        End Function

        Private Sub Log()
            While True
                label4.Text = botted.ToString()
                label5.Text = errors.ToString()
                label7.Text = viewers.ToString()
                label9.Text = title
                Thread.Sleep(250)
            End While
        End Sub


        Private Sub Worker()
            While True
                Try
                    Using req = New HttpRequest() With {
    .Proxy = scraper.Next(),
    .Cookies = New CookieStorage()
}
                        req.UserAgentRandomize()
                        req.Cookies.Container.Add(New Uri("https://www.youtube.com"), New Cookie("CONSENT", "YES+cb.20210629-13-p0.en+FX+407"))

                        Dim sres = req.Get($"https://www.youtube.com/watch?v={textBox1.Text}").ToString()
                        Dim viewersTemp = String.Join("", RegularExpressions.Viewers.Match(sres).Groups(1).Value.Where(New Func(Of Char, Boolean)(AddressOf Char.IsDigit)))

                        If Not String.IsNullOrEmpty(viewersTemp) Then viewers = viewersTemp

                        title = RegularExpressions.Title.Match(sres).Groups(1).Value

                        Dim url = ViewUrl.Match(sres).Groups(1).Value
                        url = url.Replace("\u0026", "&").Replace("%2C", ",").Replace("\/", "/")

                        Dim query = Web.HttpUtility.ParseQueryString(url)

                        Dim cl = query.Get(query.AllKeys(0))
                        Dim ei = query.Get("ei")
                        Dim [of] = query.Get("of")
                        Dim vm = query.Get("vm")
                        Dim cpn = GetCPN()

                        Dim start = Date.UtcNow

                        Dim st = random.Next(1000, 10000)
                        Dim et = GetCmt(start)
                        Dim lio = GetLio(start)

                        Dim rt = random.Next(10, 200)

                        Dim lact = random.Next(1000, 8000)
                        Dim rtn = rt + 300

                        Dim args = New Dictionary(Of String, String) From {
    {"ns", "yt"},
    {"el", "detailpage"},
    {"cpn", cpn},
    {"docid", textBox1.Text},
    {"ver", "2"},
    {"cmt", et.ToString()},
    {"ei", ei},
    {"fmt", "243"},
    {"fs", "0"},
    {"rt", rt.ToString()},
    {"of", [of]},
    {"euri", ""},
    {"lact", lact.ToString()},
    {"live", "dvr"},
    {"cl", cl},
    {"state", "playing"},
    {"vm", vm},
    {"volume", "100"},
    {"cbr", "Firefox"},
    {"cbrver", "83.0"},
    {"c", "WEB"},
    {"cplayer", "UNIPLAYER"},
    {"cver", "2.20201210.01.00"},
    {"cos", "Windows"},
    {"cosver", "10.0"},
    {"cplatform", "DESKTOP"},
    {"delay", "5"},
    {"hl", "en_US"},
    {"rtn", rtn.ToString()},
    {"aftm", "140"},
    {"rti", rt.ToString()},
    {"muted", "0"},
    {"st", st.ToString()},
    {"et", et.ToString()},
    {"lio", lio.ToString()}
}

                        Dim urlToGet = buildUrl(args)
                        req.AcceptEncoding = "gzip, deflate"
                        req.AddHeader("Host", "www.youtube.com")
                        req.Get(urlToGet.Replace("watchtime", "playback"))

                        req.AcceptEncoding = "gzip, deflate"
                        req.AddHeader("Host", "www.youtube.com")
                        req.Get(urlToGet)

                        Interlocked.Increment(botted)

                    End Using

                Catch
                    Interlocked.Increment(errors)
                End Try

                Thread.Sleep(1)
            End While
        End Sub

        Public Shared Function GetCmt(ByVal [date] As Date) As Double
            Dim origin = New DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            Dim start = [date].ToUniversalTime() - origin
            Dim now = Date.UtcNow.ToUniversalTime() - origin
            Dim value = (now.TotalSeconds - start.TotalSeconds).ToString("#.000")
            Return Double.Parse(value)
        End Function

        Public Shared Function GetLio(ByVal [date] As Date) As Double
            Dim origin = New DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            Dim start = [date].ToUniversalTime() - origin
            Dim value = start.TotalSeconds.ToString("#.000")
            Return Double.Parse(value)
        End Function

        Private Shared random As Random = New Random()
        Public Shared Function GetCPN() As String
            Const chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_"
            Return New String(Enumerable.Repeat(chars, 16).[Select](Function(s) s(random.Next(s.Length))).ToArray())
        End Function

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)

            For i = 0 To 1499
                Dim threads As List(Of Thread) = New List(Of Thread)()

                Dim t As Thread = New Thread(AddressOf Worker)
                t.Start()
                threads.Add(t)
            Next

            Dim Logthread As List(Of Thread) = New List(Of Thread)()

            Dim logWorker As Thread = New Thread(AddressOf Log)
            logWorker.Start()
            Logthread.Add(logWorker)
        End Sub

        Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim dialog As OpenFileDialog = New OpenFileDialog()
            dialog.Filter = "Proxy list (*.txt)|*.txt"

            If dialog.ShowDialog() <> DialogResult.OK Then
                Return
            End If

            scraper = New ProxyQueue(File.ReadAllText(dialog.FileName), proxyType)

            label12.Text = scraper.Length.ToString()
        End Sub

        Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs)
            Environment.Exit(1)
        End Sub
    End Class
End Namespace
