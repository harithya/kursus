Imports System.Data.OleDb

Public Class Form1

    Public dataSet As DataSet
    Public Function showTable()

        dataAdapter = New OleDbDataAdapter("SELECT * FROM kursus", connect)
        dataSet = New DataSet
        dataAdapter.Fill(dataSet, "kursus")
        data.DataSource = dataSet.Tables("kursus")

    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call connection()
        Call showTable()

        Dim i As Integer

        Dim paket(2) As String
        paket(0) = 1
        paket(1) = 3
        paket(2) = 6

        For i = 0 To 2
            inpPaket.Items.Add(paket(i))
        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call connection()
        command = New OleDbCommand("INSERT INTO kursus (paket, harga, nama) VALUES (@paket, @harga, @nama) ", connect)
        command.Parameters.Add("@paket", OleDbType.Integer).Value = inpPaket.Text
        command.Parameters.Add("@harga", OleDbType.Integer).Value = inpHarga.Text
        command.Parameters.Add("@nama", OleDbType.Char).Value = inpNama.Text

        command.ExecuteNonQuery()
        MsgBox("Berhasil")
        Call showTable()

    End Sub

    Private Sub inpPaket_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles inpPaket.SelectedIndexChanged

        Dim harga As Double

        If inpPaket.Text = 1 Then
            harga = 1000
        ElseIf inpPaket.Text = 3 Then
            harga = 2000
        ElseIf inpPaket.Text = 6 Then
            harga = 3000
        Else
            harga = 0
        End If

        inpHarga.Text = harga


    End Sub


End Class
