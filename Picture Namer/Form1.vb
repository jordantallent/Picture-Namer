Public Class Form1

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub



    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        If TextBox2.Text <> "" Then
            Dim count = 1
            For Each foundFile As String In My.Computer.FileSystem.GetFiles(TextBox1.Text, FileIO.SearchOption.SearchAllSubDirectories)
                Dim type = My.Computer.FileSystem.GetFileInfo(foundFile).ToString.Substring(My.Computer.FileSystem.GetFileInfo(foundFile).ToString.LastIndexOf("."))
                My.Computer.FileSystem.RenameFile(foundFile, TextBox2.Text & count & type)
                count = count + 1
            Next
            If CheckBox1.Checked = True Then
                System.Diagnostics.Process.Start(TextBox1.Text)
            End If

        Else
            MessageBox.Show("invalid name")
        End If

    End Sub
End Class
