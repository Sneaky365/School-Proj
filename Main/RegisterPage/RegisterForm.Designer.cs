﻿namespace RegisterPage;

partial class RegisterForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        label1 = new Label();
        label2 = new Label();
        button1 = new Button();
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(198, 144);
        label1.Name = "label1";
        label1.Size = new Size(60, 15);
        label1.TabIndex = 0;
        label1.Text = "Username";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(198, 191);
        label2.Name = "label2";
        label2.Size = new Size(57, 15);
        label2.TabIndex = 1;
        label2.Text = "Password";
        // 
        // button1
        // 
        button1.Location = new Point(340, 288);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 2;
        button1.Text = "Submit";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(326, 144);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(100, 23);
        textBox1.TabIndex = 3;
        // 
        // textBox2
        // 
        textBox2.Location = new Point(326, 191);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(100, 23);
        textBox2.TabIndex = 4;
        // 
        // RegisterForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(button1);
        Controls.Add(label2);
        Controls.Add(label1);
        Name = "RegisterForm";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private Label label2;
    private Button button1;
    private TextBox textBox1;
    private TextBox textBox2;
}
