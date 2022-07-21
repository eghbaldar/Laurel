Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Image = OverlayImgs(My.Resources.poter2,
                                        My.Resources.Original_Laurel)
    End Sub
    Function OverlayImgs(ByVal BackgroundImg As System.Drawing.Bitmap,
                         ByVal OverlayImg As System.Drawing.Bitmap) As System.Drawing.Bitmap
        Dim g = System.Drawing.Graphics.FromImage(BackgroundImg)

        g.DrawImage(OverlayImg, 0, 0, Convert.ToSingle(OverlayImg.Width / 10), Convert.ToSingle(OverlayImg.Height / 10))
        g.DrawImage(OverlayImg, Convert.ToSingle(OverlayImg.Width / 10) _
                    , 0, Convert.ToSingle(OverlayImg.Width / 10), Convert.ToSingle(OverlayImg.Height / 10))

        Return BackgroundImg

    End Function

End Class
