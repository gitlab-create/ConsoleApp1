Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class Encryptor
    ' define the triple des provider
    Private m_des As New TripleDESCryptoServiceProvider

    ' define the string handler
    Private m_utf8 As New UTF8Encoding

    ' define the local property arrays
    Private m_key() As Byte
    Private m_iv() As Byte


    Public Sub New()
        Me.m_key = GenerateKey(16)
        Me.m_iv = GenerateKey(16)
    End Sub


    Public Function Encrypt(ByVal input() As Byte) As Byte()
        Return Transform(input, m_des.CreateEncryptor(m_key, m_iv))
    End Function

    Public Function Decrypt(ByVal input() As Byte) As Byte()
        Return Transform(input, m_des.CreateDecryptor(m_key, m_iv))
    End Function

    Public Function Encrypt(ByVal text As String) As String
        Dim input() As Byte = m_utf8.GetBytes(text)
        Dim output() As Byte = Transform(input,
                        m_des.CreateEncryptor(m_key, m_iv))
        Return Convert.ToBase64String(output)
    End Function

    Public Function Decrypt(ByVal text As String) As String
        Dim input() As Byte = Convert.FromBase64String(text)
        Dim output() As Byte = Transform(input,
                         m_des.CreateDecryptor(m_key, m_iv))
        Return m_utf8.GetString(output)
    End Function

    Private Function Transform(ByVal input() As Byte,
        ByVal CryptoTransform As ICryptoTransform) As Byte()
        ' create the necessary streams
        Dim memStream As MemoryStream = New MemoryStream
        Dim cryptStream As CryptoStream = New _
            CryptoStream(memStream, CryptoTransform,
            CryptoStreamMode.Write)
        ' transform the bytes as requested
        cryptStream.Write(input, 0, input.Length)
        cryptStream.FlushFinalBlock()
        ' Read the memory stream and convert it back into byte array
        memStream.Position = 0
        Dim result(CType(memStream.Length - 1, System.Int32)) As Byte
        memStream.Read(result, 0, CType(result.Length, System.Int32))
        ' close and release the streams
        memStream.Close()
        cryptStream.Close()
        ' hand back the encrypted buffer
        Return result
    End Function
    Public Function GenerateKey(ByVal Length As Integer) As Byte()
        Dim ReturnArray(Length - 1) As Byte
        Using RNG As New RNGCryptoServiceProvider
            RNG.GetBytes(ReturnArray)
        End Using
        Return ReturnArray
    End Function
End Class
