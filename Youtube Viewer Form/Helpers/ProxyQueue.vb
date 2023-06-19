Imports System
Imports System.Collections.Concurrent
Imports System.Collections.Generic
Imports Leaf.xNet

Namespace Youtube_Viewers.Helpers
    Friend Class ProxyQueue
        Private ReadOnly locker As Object = New Object()
        Private plist As ProxyClient()
        Private proxies As ConcurrentQueue(Of ProxyClient)

        Public Sub New(ByVal pr As String, ByVal type As ProxyType)
            Me.Type = type
            SafeUpdate(pr)
            proxies = New ConcurrentQueue(Of ProxyClient)(plist)
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return proxies.Count
            End Get
        End Property
        Public ReadOnly Property Length As Integer
            Get
                Return plist.Length
            End Get
        End Property

        Public ReadOnly Property Type As ProxyType

        Private Function GetProxies(ByVal str As String) As List(Of String)
            Dim res = New HashSet(Of String)()

            For Each proxy In MatchAndFormatProxies(str)
                Try
                    If Not res.Contains(proxy) Then res.Add(proxy)
                Catch
                    ' ignored
                End Try
            Next

            Return New List(Of String)(res)
        End Function

        Private Function MatchAndFormatProxies(ByVal str As String) As List(Of String)
            Dim res = New List(Of String)()

            Dim list = str.Split({vbLf, vbCrLf}, StringSplitOptions.None)

            For Each lineStock In list
                Dim line = lineStock.Trim()

                Try
                    Dim formatted = FormatLine(line)
                    If Not String.IsNullOrEmpty(formatted) Then res.Add(formatted)
                Catch
                    ' ignored
                End Try
            Next

            Return res
        End Function

        Private Function FormatLine(ByVal line As String) As String
            Dim lineSplit = line.Split(":"c)
            If lineSplit.Length < 2 OrElse lineSplit.Length > 4 Then Return String.Empty

            Dim formatted = String.Empty

            If line.Contains("@") AndAlso lineSplit.Length = 3 Then
                lineSplit = line.Split("@"c)
                Dim userPass = lineSplit(0)
                Dim address = lineSplit(1)

                Dim port = Integer.Parse(address.Split(":"c)(1))

                If port > 65535 OrElse port < 1 Then Return String.Empty

                formatted = $"{Type.ToString().ToLower()}://{address}:{userPass}"
            Else
                If lineSplit(0).Contains(".") AndAlso lineSplit(0).Split("."c).Length = 4 Then
                    Dim port = Integer.Parse(lineSplit(1))

                    If port > 65535 OrElse port < 1 Then Return String.Empty

                    formatted = $"{Type.ToString().ToLower()}://{line}"
                ElseIf lineSplit.Length = 4 AndAlso lineSplit(2).Contains(".") AndAlso lineSplit(0).Split("."c).Length = 4 Then
                    Dim port = Integer.Parse(lineSplit(3))

                    If port > 65535 OrElse port < 1 Then Return String.Empty

                    formatted = $"{Type.ToString().ToLower()}://{lineSplit(2)}:{lineSplit(3)}:{lineSplit(0)}:{lineSplit(1)}"
                End If
            End If

            Return formatted
        End Function

        Public Sub SafeUpdate(ByVal pr As String)
            SyncLock locker
                Dim prxs = New List(Of ProxyClient)()
                GetProxies(pr).ForEach(Sub(x) prxs.Add(ProxyClient.Parse(x)))
                plist = prxs.ToArray()
            End SyncLock
        End Sub

        Public Function [Next]() As ProxyClient
            If proxies.Count = 0 Then
                SyncLock locker
                    If proxies.Count = 0 Then proxies = New ConcurrentQueue(Of ProxyClient)(plist)
                End SyncLock
            End If

            Dim res As ProxyClient

            If proxies.TryDequeue(res) AndAlso res IsNot Nothing Then Return res
            Throw New HttpException()
        End Function
    End Class
End Namespace
