Imports System.Net.Sockets
Imports System.Net
Imports System
Imports System.Threading
Imports ISO8583_Lib.Function_Shared.clsLogger

Namespace SocketServer

    Public Class clsSocketSvr

        Public Event Work_Progress(ByVal msg As String)
        Public Event Work_Progress_Debug(ByVal msg As String)

        Dim WithEvents client As clsSocketClient

        Dim serverSocket As TcpListener
        Dim clientSocket As TcpClient
        Dim s1 As String
        Public Sub New()

        End Sub

        Public Sub StartServer(ByRef out_client As TcpClient)

            Dim LocalIP As IPAddress
            LocalIP = IPAddress.Parse(GetIPAddress)

            Dim LocalPort As Integer = stConfigHostParam.Port

            Dim counter As Integer = 0
            s1=""
            s1="SocketServer StartServer step 1 port = " & LocalPort
            Log_Txt(s1)
            Try

                serverSocket = New TcpListener(LocalIP, LocalPort)
                s1 = ""
                s1 = "SocketServer StartServer step 2 "
                Log_Txt(s1)
                serverSocket.Start()
                s1 = ""
                s1 = "SocketServer StartServer step 3 "
                Log_Txt(s1)
                RaiseEvent Work_Progress("Server started")
                RaiseEvent Work_Progress("Server connected to " & GetIPAddress() & " on Port Number " & LocalPort.ToString)



                While (True)

                    clientSocket = serverSocket.AcceptTcpClient()
                    out_client = clientSocket

                    If stConfigDataArchive.EnableLoggingOption = 1 Then
                        RaiseEvent Work_Progress("One connections from " & IPAddress.Parse(CType(clientSocket.Client.RemoteEndPoint, IPEndPoint).Address.ToString()).ToString)

                    End If

                    client = New clsSocketClient
                    AddHandler client.Work_Progress, AddressOf Log
                    ' AddHandler client.Work_Progress_Debug, AddressOf Log_Debug

                    client.Listen(clientSocket)
                    'Thread.Sleep(1000)
                    'Thread.Sleep(500)
                End While

            Catch ex As SocketException
                ' Bypass error message that raised when trying to perform Reconnect Server(frmSettingHost)
                If ex.SocketErrorCode <> SocketError.Interrupted Then
                    RaiseEvent Work_Progress(ex.SocketErrorCode & ":" & ex.Message)
                End If
                s1 = ""
                s1 = "SocketServer StartServer error 1 "
                Log_Txt(s1)
            Catch ex As ThreadAbortException

            Catch ex As SqlClient.SqlException
                Log_Txt("[SqlException] " & ex.ToString)

            Catch ex As Exception
                RaiseEvent Work_Progress(ex.ToString)
                s1=""
                s1="SocketServer StartServer error 2 "
                Log_Txt(s1)
            End Try
        End Sub

        Public Sub StopServer()
            Try
                'clientSocket.Close()

                With serverSocket
                    '.Server.Shutdown(SocketShutdown.Both)
                    ' .Server.Close()
                    .Stop()
                End With

            Catch ex As ThreadAbortException
            Catch ex As Exception
                Log_Txt("[MyFileOpen] " & ex.Message)
            Finally

            End Try

            Try
                RaiseEvent Work_Progress("Server Stopped")
                'GC.Collect()

            Catch ex As ThreadAbortException
                'Catch ex As Exception

            End Try

        End Sub
        ' Sub Log_Txt(ByVal msg As String)
        '    'RaiseEvent Work_Progress(msg)
        '    'return
        '    Dim FileNum As Integer
        '    Dim strTemp, datestr, timestr, filename As String

        '    FileNum = FreeFile()
        '    timestr = Format(Now, "HHmmss")
        '    datestr = Format(Now, "yyMMdd")
        '    filename = StartupPathFolder & "\APLOG\vblog" & datestr & ".txt"
        '    'FileOpen(FileNum, filename, OpenMode.Append,OpenShare.Shared)
        '    Dim Index As Integer = 0Private
        '    While Index < 100
        '        Index = Index + 1
        '        If MyFileOpen(FileNum, filename, msg) Then
        '            Exit While
        '        Else
        '            Thread.Sleep(100)
        '            Continue While
        '        End If
        '    End While


        'End Sub
        'Private Shared LogLock As New Object
        'Private Function MyFileOpen(ByVal piFNo As Integer, ByVal psFileName As String, ByVal psMsg As String) As Boolean
        '    Dim strTemp, datestr, timestr, filename As String

        '    timestr = Format(Now, "HHmmss")
        '    Try
        '        SyncLock LogLock
        '            FileOpen(piFNo, psFileName, OpenMode.Append, OpenShare.Shared)
        '            strTemp = timestr & ":" & psMsg
        '            PrintLine(piFNo, strTemp)
        '            FileClose(piFNo)
        '            Return True
        '        End SyncLock

        '    Catch ex As Exception
        '        'Log_Txt(ex.Message)
        '        Return False
        '    End Try

        'End Function
#Region "[ Methods ]"

        Private Function GetIPAddress() As String

            Try
                Dim addressBytes As Byte() = IPAddress.Parse(stConfigHostParam.Host).GetAddressBytes()
                Dim objIPAddress As IPAddress = New IPAddress(addressBytes)
                GetIPAddress = objIPAddress.ToString
            Catch ex As SqlClient.SqlException
                Log_Txt("[SqlException] " & ex.ToString)
            Catch ex As Exception
                Dim addressBytes2 As Byte() = IPAddress.Parse("127.0.0.1").GetAddressBytes()
                Dim objIPAddress2 As IPAddress = New IPAddress(addressBytes2)
                GetIPAddress = objIPAddress2.ToString
                Log_Txt("[Error] " & ex.Message & ", use IP [127.0.0.1]")
            End Try

        End Function

        Public Sub StartDataArchive()

            Try

                client = New clsSocketClient
                AddHandler client.Work_Progress, AddressOf Log
                client.DataArchive()

            Catch ex As ThreadAbortException
                RaiseEvent Work_Progress(ex.ToString)
            Catch ex As Exception
                RaiseEvent Work_Progress(ex.ToString)

            End Try
        End Sub

#End Region

#Region "[ Events Handling] "

        'Private Sub Log_Debug(ByVal msg As String)
        '    RaiseEvent Work_Progress_Debug(msg)
        'End Sub


        Private Sub Log(ByVal msg As String)
            RaiseEvent Work_Progress(msg)
        End Sub

#End Region

    End Class

End Namespace


