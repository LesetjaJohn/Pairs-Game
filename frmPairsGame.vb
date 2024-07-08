Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmPairsGame

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        btnChange.Text = "Deal" 'Changing button text

        Dim partialPath As String = ".\Images\owl" 'Repeating part of image path
        Dim fullPath As String
        Dim b As Control
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim cnt As Integer = 1
        Dim generatedNum(1, 8) As Integer
        generatedNum = PopulateArr() 'Assigning array values

        For Each b In Controls 'Accessing the controls on the form
            If cnt > 2 Then 'Confirm ignoring the first 2 buttons
                If i < 8 Then
                    i += 1
                Else
                    i = 0
                    j = 1
                End If

                fullPath = partialPath + CStr(generatedNum(j, i)) + ".jpg" 'Generating full path of the image file
                b.BackgroundImage = Image.FromFile(fullPath)
                b.BackgroundImageLayout = ImageLayout.Stretch
            End If

            cnt += 1
        Next

        btnStart.Enabled = True 'Enabling Start button
    End Sub

    Function PopulateArr() As Integer(,)

        Dim arr(1, 8) As Integer
        Dim str As String = ""
        For j = 0 To 1
            For i = 0 To 8
                Dim randomNum As Integer
                randomNum = Int((9 * Rnd()) + 1)

                If i = 0 Then
                    arr(j, i) = randomNum
                    str = CStr(randomNum)
                    Continue For
                End If

                If Not CBool(InStr(str, CStr(randomNum))) Then 'From second iteration
                    arr(j, i) = randomNum
                    str += CStr(randomNum)
                Else
                    i -= 1
                End If
            Next
        Next


        Return arr
    End Function

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        btnChange.Text = "New deal" 'Changing button text
        btnStart.Enabled = False

        Dim b As Control
        Dim cnt As Integer = 1

        For Each b In Controls 'Accessing the controls on the form
            Dim randomNum As Integer = Int((9 * Rnd()) + 1) 'Random number for random image file

            If TypeOf b Is Button And cnt > 2 Then 'Confirm if control is button and ignoring the first 2 buttons

                b.BackgroundImage = Image.FromFile(".\Images\default.png")
                b.BackgroundImageLayout = ImageLayout.Stretch

            End If
            cnt += 1
        Next
    End Sub
End Class