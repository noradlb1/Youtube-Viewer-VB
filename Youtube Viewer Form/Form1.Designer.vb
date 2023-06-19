
Namespace Youtube_Viewer_Form
    Partial Class Form1
        ''' <summary>
        '''  Required designer variable.
        ''' </summary>
        Private components As ComponentModel.IContainer = Nothing

        ''' <summary>
        '''  Clean up any resources being used.
        ''' </summary>
        ''' <paramname="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

        ''' <summary>
        '''  Required method for Designer support - do not modify
        '''  the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            button1 = New Windows.Forms.Button()
            button2 = New Windows.Forms.Button()
            textBox1 = New Windows.Forms.TextBox()
            label1 = New Windows.Forms.Label()
            button3 = New Windows.Forms.Button()
            label2 = New Windows.Forms.Label()
            label3 = New Windows.Forms.Label()
            label4 = New Windows.Forms.Label()
            label5 = New Windows.Forms.Label()
            label6 = New Windows.Forms.Label()
            label7 = New Windows.Forms.Label()
            label8 = New Windows.Forms.Label()
            label9 = New Windows.Forms.Label()
            label10 = New Windows.Forms.Label()
            label11 = New Windows.Forms.Label()
            label12 = New Windows.Forms.Label()
            SuspendLayout()
            ' 
            ' button1
            ' 
            button1.Location = New Drawing.Point(175, 262)
            button1.Name = "button1"
            button1.Size = New Drawing.Size(129, 39)
            button1.TabIndex = 0
            button1.Text = "Start"
            button1.UseVisualStyleBackColor = True
            AddHandler button1.Click, New EventHandler(AddressOf button1_Click)
            ' 
            ' button2
            ' 
            button2.Location = New Drawing.Point(322, 85)
            button2.Name = "button2"
            button2.Size = New Drawing.Size(97, 31)
            button2.TabIndex = 1
            button2.Text = "Load Proxy"
            button2.UseVisualStyleBackColor = True
            AddHandler button2.Click, New EventHandler(AddressOf button2_Click)
            ' 
            ' textBox1
            ' 
            textBox1.Location = New Drawing.Point(62, 113)
            textBox1.Name = "textBox1"
            textBox1.Size = New Drawing.Size(133, 23)
            textBox1.TabIndex = 2
            ' 
            ' label1
            ' 
            label1.AutoSize = True
            label1.Location = New Drawing.Point(101, 85)
            label1.Name = "label1"
            label1.Size = New Drawing.Size(50, 15)
            label1.TabIndex = 3
            label1.Text = "Video Id"
            ' 
            ' button3
            ' 
            button3.Location = New Drawing.Point(359, 278)
            button3.Name = "button3"
            button3.Size = New Drawing.Size(75, 23)
            button3.TabIndex = 4
            button3.Text = "Exit"
            button3.UseVisualStyleBackColor = True
            AddHandler button3.Click, New EventHandler(AddressOf button3_Click)
            ' 
            ' label2
            ' 
            label2.AutoSize = True
            label2.Font = New Drawing.Font("Stencil", 24F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
            label2.Location = New Drawing.Point(30, 20)
            label2.Name = "label2"
            label2.Size = New Drawing.Size(202, 38)
            label2.TabIndex = 5
            label2.Text = "CBT VIEWER"
            ' 
            ' label3
            ' 
            label3.AutoSize = True
            label3.Font = New Drawing.Font("Yu Gothic UI", 12F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
            label3.Location = New Drawing.Point(46, 198)
            label3.Name = "label3"
            label3.Size = New Drawing.Size(40, 21)
            label3.TabIndex = 6
            label3.Text = "Bot :"
            ' 
            ' label4
            ' 
            label4.AutoSize = True
            label4.Font = New Drawing.Font("Yu Gothic UI", 11.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
            label4.Location = New Drawing.Point(92, 199)
            label4.Name = "label4"
            label4.Size = New Drawing.Size(17, 20)
            label4.TabIndex = 7
            label4.Text = "0"
            ' 
            ' label5
            ' 
            label5.AutoSize = True
            label5.Font = New Drawing.Font("Yu Gothic UI", 11.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
            label5.Location = New Drawing.Point(101, 230)
            label5.Name = "label5"
            label5.Size = New Drawing.Size(17, 20)
            label5.TabIndex = 9
            label5.Text = "0"
            ' 
            ' label6
            ' 
            label6.AutoSize = True
            label6.Font = New Drawing.Font("Yu Gothic UI", 12F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
            label6.Location = New Drawing.Point(46, 229)
            label6.Name = "label6"
            label6.Size = New Drawing.Size(52, 21)
            label6.TabIndex = 8
            label6.Text = "Error :"
            ' 
            ' label7
            ' 
            label7.AutoSize = True
            label7.Font = New Drawing.Font("Yu Gothic UI", 11.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
            label7.Location = New Drawing.Point(124, 262)
            label7.Name = "label7"
            label7.Size = New Drawing.Size(17, 20)
            label7.TabIndex = 11
            label7.Text = "0"
            ' 
            ' label8
            ' 
            label8.AutoSize = True
            label8.Font = New Drawing.Font("Yu Gothic UI", 12F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
            label8.Location = New Drawing.Point(46, 261)
            label8.Name = "label8"
            label8.Size = New Drawing.Size(72, 21)
            label8.TabIndex = 10
            label8.Text = "Viewers :"
            ' 
            ' label9
            ' 
            label9.AutoSize = True
            label9.Font = New Drawing.Font("Yu Gothic UI", 11.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
            label9.Location = New Drawing.Point(94, 168)
            label9.Name = "label9"
            label9.Size = New Drawing.Size(45, 20)
            label9.TabIndex = 13
            label9.Text = "None"
            ' 
            ' label10
            ' 
            label10.AutoSize = True
            label10.Font = New Drawing.Font("Yu Gothic UI", 12F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
            label10.Location = New Drawing.Point(46, 167)
            label10.Name = "label10"
            label10.Size = New Drawing.Size(42, 21)
            label10.TabIndex = 12
            label10.Text = "Title:"
            ' 
            ' label11
            ' 
            label11.AutoSize = True
            label11.Font = New Drawing.Font("Yu Gothic UI", 12F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
            label11.Location = New Drawing.Point(312, 138)
            label11.Name = "label11"
            label11.Size = New Drawing.Size(67, 21)
            label11.TabIndex = 14
            label11.Text = "Proxies :"
            ' 
            ' label12
            ' 
            label12.AutoSize = True
            label12.Font = New Drawing.Font("Yu Gothic UI", 11.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
            label12.Location = New Drawing.Point(382, 139)
            label12.Name = "label12"
            label12.Size = New Drawing.Size(17, 20)
            label12.TabIndex = 15
            label12.Text = "0"
            ' 
            ' Form1
            ' 
            AutoScaleDimensions = New Drawing.SizeF(7F, 15F)
            AutoScaleMode = Windows.Forms.AutoScaleMode.Font
            ClientSize = New Drawing.Size(444, 312)
            Controls.Add(label12)
            Controls.Add(label11)
            Controls.Add(label9)
            Controls.Add(label10)
            Controls.Add(label7)
            Controls.Add(label8)
            Controls.Add(label5)
            Controls.Add(label6)
            Controls.Add(label4)
            Controls.Add(label3)
            Controls.Add(label2)
            Controls.Add(button3)
            Controls.Add(label1)
            Controls.Add(textBox1)
            Controls.Add(button2)
            Controls.Add(button1)
            FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Name = "Form1"
            StartPosition = Windows.Forms.FormStartPosition.CenterScreen
            ResumeLayout(False)
            PerformLayout()

        End Sub

#End Region

        Private button1 As Windows.Forms.Button
        Private button2 As Windows.Forms.Button
        Private textBox1 As Windows.Forms.TextBox
        Private label1 As Windows.Forms.Label
        Private button3 As Windows.Forms.Button
        Private label2 As Windows.Forms.Label
        Private label3 As Windows.Forms.Label
        Private label4 As Windows.Forms.Label
        Private label5 As Windows.Forms.Label
        Private label6 As Windows.Forms.Label
        Private label7 As Windows.Forms.Label
        Private label8 As Windows.Forms.Label
        Private label9 As Windows.Forms.Label
        Private label10 As Windows.Forms.Label
        Private label11 As Windows.Forms.Label
        Private label12 As Windows.Forms.Label
    End Class
End Namespace
