Imports System.Drawing.Imaging
Imports System.Drawing.Text
Imports System.Text

Public Class Form2
    ' Button to load the poster image
    Private Sub btnLoadPoster_Click(sender As Object, e As EventArgs) Handles btnLoadPoster.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Load the poster into a PictureBox for preview
            picPoster.Image = Image.FromFile(openFileDialog.FileName)
        End If
    End Sub

    ' Button to add text with laurels and export as a jpg
    Private Sub btnAddTextAndExport_Click(sender As Object, e As EventArgs) Handles btnAddTextAndExport.Click

        If picPoster.Image IsNot Nothing Then
            ' Create a new bitmap based on the loaded image
            Dim poster As New Bitmap(picPoster.Image)

            ' Load the custom laurel PNG file
            Dim openLaurelDialog As New OpenFileDialog()
            openLaurelDialog.Filter = "PNG Files|*.png"
            openLaurelDialog.Title = "Select a Laurel PNG Template"

            Dim laurelImage As Bitmap = Nothing
            If openLaurelDialog.ShowDialog() = DialogResult.OK Then
                laurelImage = New Bitmap(openLaurelDialog.FileName)
            End If

            If laurelImage Is Nothing Then
                MessageBox.Show("Please select a laurel image!")
                Return
            End If

            ' Create a Graphics object to draw on the poster
            Using g As Graphics = Graphics.FromImage(poster)
                ' Set high-quality rendering
                g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit

                ' Placeholder for film festival names
                Dim festivals As String() = {
                    "Cannes Short Film Festival",
                    "Sundance Film Festival",
                    "Berlin International Film Festival",
                    "Toronto International Film Festival",
                    "Venice Film Festival",
                    "Cannes Film Festival",
                    "Slamdance Film Festival",
                    "Tribeca Film Festival",
                    "SXSW Film Festival",
                    "Cannes Film Festival",
                    "Slamdance Film Festival",
                    "Tribeca Film Festival",
                    "SXSW Film Festival",
                    "Cannes Film Festival",
                    "Slamdance Film Festival",
                    "Tribeca Film Festival",
                    "SXSW Film Festival"
                }

                ' Define margins for drawing
                Dim margin As Integer = 10

                ' Define the number of columns and rows based on the number of festivals
                Dim numColumns As Integer = Math.Ceiling(Math.Sqrt(festivals.Length)) ' Square root to approximate grid
                Dim numRows As Integer = Math.Ceiling(festivals.Length / numColumns)

                ' Calculate grid cell width and height
                Dim cellWidth As Integer = (poster.Width - (margin * (numColumns + 1))) \ numColumns
                Dim cellHeight As Integer = (poster.Height - (margin * (numRows + 1))) \ numRows

                ' Define font and brush for text
                Dim fontSize As Integer = Math.Min(cellHeight \ 6, 20) ' Adjust font size based on the grid size
                Dim font As New Font("Arial", fontSize, FontStyle.Bold)
                Dim brush As New SolidBrush(Color.White)
                ' Draw each festival name inside the laurel PNG template
                Dim index As Integer = 0
                For row As Integer = 0 To numRows - 1
                    For col As Integer = 0 To numColumns - 1
                        If index >= festivals.Length Then Exit For ' Exit if all festivals are drawn

                        ' Calculate the position of the laurel image
                        Dim startX As Integer = margin + col * (cellWidth + margin)
                        Dim startY As Integer = margin + row * (cellHeight + margin)

                        ' Calculate the scale factor to fit the laurel into the cell while maintaining aspect ratio
                        Dim scaleX As Single = cellWidth / laurelImage.Width
                        Dim scaleY As Single = cellHeight / laurelImage.Height
                        Dim scale As Single = Math.Min(scaleX, scaleY)

                        ' Calculate the new size of the laurel image
                        Dim newLaurelWidth As Integer = CInt(laurelImage.Width * scale)
                        Dim newLaurelHeight As Integer = CInt(laurelImage.Height * scale)
                        Dim laurelRect As New Rectangle(startX + (cellWidth - newLaurelWidth) \ 2, startY + (cellHeight - newLaurelHeight) \ 2, newLaurelWidth, newLaurelHeight)

                        ' Draw the laurel image centered in the cell
                        g.DrawImage(laurelImage, laurelRect)

                        ' Split festival name into lines
                        Dim festivalName As String = festivals(index)
                        Dim lines As String() = SplitTextIntoLines(g, festivalName, newLaurelWidth)

                        ' Calculate the total height of the text to center it vertically
                        Dim totalTextHeight As Integer = lines.Sum(Function(line) g.MeasureString(line, font).Height)
                        Dim startYForText As Integer = laurelRect.Y + (newLaurelHeight - totalTextHeight - 180) \ 2

                        ' Draw the festival name lines inside the laurel
                        For Each line In lines
                            Dim textSize As SizeF = g.MeasureString(line, font)
                            Dim textX As Integer = laurelRect.X + (newLaurelWidth - textSize.Width) / 2
                            Dim textY As Integer = startYForText
                            g.DrawString(line, font, brush, New PointF(textX, textY))
                            startYForText += textSize.Height ' Move down for the next line
                        Next

                        index += 1
                    Next
                Next

                ' Define the bottom text with multiple lines
                Dim bottomTextLines As String() = {
                    "IRAN FILM PORT",
                    "Iranian Film Agency and Distribution Company",
                    "www.iranfilmport.com | @iranfilmport"
                }

                ' Define font and brush for bottom text
                Dim bottomTextFont As New Font("Arial", 16, FontStyle.Bold)
                Dim bottomTextBrush As New SolidBrush(Color.White)
                Dim bottomTextLineHeight As Single = g.MeasureString(bottomTextLines(0), bottomTextFont).Height

                ' Calculate the starting Y position for the bottom text
                Dim bottomTextY As Single = poster.Height - (bottomTextLines.Length * bottomTextLineHeight) - 20 ' 20 pixels from the bottom

                ' Draw each line of the bottom text
                For i As Integer = 0 To bottomTextLines.Length - 1
                    Dim line As String = bottomTextLines(i)
                    Dim textSize As SizeF = g.MeasureString(line, bottomTextFont)
                    Dim textX As Single = (poster.Width - textSize.Width) / 2
                    g.DrawString(line, bottomTextFont, bottomTextBrush, textX, bottomTextY)
                    bottomTextY += bottomTextLineHeight ' Move down for the next line
                Next

            End Using



            ' Show save dialog to save the image as JPG
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "JPEG Image|*.jpg"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                ' Save the modified poster as a JPG file
                poster.Save(saveFileDialog.FileName, ImageFormat.Jpeg)
                MessageBox.Show("Poster saved successfully!")
            End If
        Else
            MessageBox.Show("Please load a poster image first!")
        End If


    End Sub
    Private Function SplitTextIntoLines(g As Graphics, text As String, maxWidth As Integer) As String()
        Dim words As String() = text.Split(" "c)
        Dim lines As New List(Of String)()
        Dim currentLine As New StringBuilder()

        For Each word In words
            Dim testLine As String = If(currentLine.Length = 0, word, currentLine.ToString() & " " & word)
            Dim textSize As SizeF = g.MeasureString(testLine, New Font("Arial", 24, FontStyle.Bold))

            If textSize.Width > maxWidth Then
                If currentLine.Length > 0 Then
                    lines.Add(currentLine.ToString())
                    currentLine.Clear()
                End If
                currentLine.Append(word)
            Else
                currentLine.Append(If(currentLine.Length = 0, word, " " & word))
            End If
        Next

        If currentLine.Length > 0 Then
            lines.Add(currentLine.ToString())
        End If

        Return lines.ToArray()
    End Function
End Class