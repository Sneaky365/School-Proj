namespace LoginPage;

partial class LoginForm
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
        button1 = new Button();
        label1 = new Label();
        label2 = new Label();
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        linkLabel1 = new LinkLabel();
        button2 = new Button();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(314, 270);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 0;
        button1.Text = "Login";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(192, 135);
        label1.Name = "label1";
        label1.Size = new Size(60, 15);
        label1.TabIndex = 1;
        label1.Text = "Username";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(192, 194);
        label2.Name = "label2";
        label2.Size = new Size(57, 15);
        label2.TabIndex = 2;
        label2.Text = "Password";
        // 
        // textBox1
        // 
        textBox1.Location = new Point(301, 135);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(100, 23);
        textBox1.TabIndex = 3;
        // 
        // textBox2
        // 
        textBox2.Location = new Point(301, 194);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(100, 23);
        textBox2.TabIndex = 3;
        // 
        // linkLabel1
        // 
        linkLabel1.AutoSize = true;
        linkLabel1.Location = new Point(262, 237);
        linkLabel1.Name = "linkLabel1";
        linkLabel1.Size = new Size(191, 15);
        linkLabel1.TabIndex = 4;
        linkLabel1.TabStop = true;
        linkLabel1.Text = "Don't have an account? Click Here!";
        linkLabel1.LinkClicked += linkLabel1_LinkClicked;
        // 
        // button2
        // 
        button2.Location = new Point(575, 82);
        button2.Name = "button2";
        button2.Size = new Size(75, 23);
        button2.TabIndex = 5;
        button2.Text = "Home";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // LoginForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(button2);
        Controls.Add(linkLabel1);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(button1);
        Name = "LoginForm";
        Text = "Form1";
        Load += LoginForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private Label label1;
    private Label label2;
    private TextBox textBox1;
    private TextBox textBox2;
    private LinkLabel linkLabel1;
    private Button button2;
}
