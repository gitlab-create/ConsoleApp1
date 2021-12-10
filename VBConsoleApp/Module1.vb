Module Module1

    Sub Main()
        Dim encryptor As New Encryptor()
        Dim encryptedString = encryptor.Encrypt("")
        Dim decryptedString = encryptor.Decrypt(encryptedString)

        Console.Write("encryptedString: " + encryptedString)
        Console.Write("decryptedString: " + decryptedString)
        Console.ReadLine()


    End Sub

End Module
