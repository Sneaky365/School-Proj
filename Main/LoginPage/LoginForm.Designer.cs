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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
        button1 = new Button();
        label1 = new Label();
        label2 = new Label();
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        linkLabel1 = new LinkLabel();
        button2 = new Button();
        button3 = new Button();
        label3 = new Label();
        SuspendLayout();
        // 
        // button1
        // 
        button1.BackColor = Color.Transparent;
        button1.FlatAppearance.BorderSize = 0;
        button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
        button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
        button1.FlatStyle = FlatStyle.Flat;
        button1.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        button1.ForeColor = Color.White;
        button1.Location = new Point(542, 277);
        button1.Name = "button1";
        button1.Size = new Size(129, 66);
        button1.TabIndex = 0;
        button1.Text = "Login✓";
        button1.UseVisualStyleBackColor = false;
        button1.Click += button1_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.BackColor = Color.Transparent;
        label1.ForeColor = Color.White;
        label1.Location = new Point(236, 231);
        label1.Name = "label1";
        label1.Size = new Size(60, 15);
        label1.TabIndex = 1;
        label1.Text = "Username";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.BackColor = Color.Transparent;
        label2.ForeColor = Color.White;
        label2.Location = new Point(236, 280);
        label2.Name = "label2";
        label2.Size = new Size(57, 15);
        label2.TabIndex = 2;
        label2.Text = "Password";
        // 
        // textBox1
        // 
        textBox1.BackColor = Color.White;
        textBox1.Location = new Point(312, 228);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(100, 23);
        textBox1.TabIndex = 3;
        // 
        // textBox2
        // 
        textBox2.BackColor = Color.White;
        textBox2.Location = new Point(312, 277);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(100, 23);
        textBox2.TabIndex = 3;
        // 
        // linkLabel1
        // 
        linkLabel1.AutoSize = true;
        linkLabel1.BackColor = Color.Transparent;
        linkLabel1.Location = new Point(259, 315);
        linkLabel1.Name = "linkLabel1";
        linkLabel1.Size = new Size(191, 15);
        linkLabel1.TabIndex = 4;
        linkLabel1.TabStop = true;
        linkLabel1.Text = "Don't have an account? Click Here!";
        linkLabel1.LinkClicked += linkLabel1_LinkClicked;
        // 
        // button2
        // 
        button2.BackColor = Color.Transparent;
        button2.FlatAppearance.BorderSize = 0;
        button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
        button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
        button2.FlatStyle = FlatStyle.Flat;
        button2.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        button2.ForeColor = Color.White;
        button2.Location = new Point(12, 12);
        button2.Name = "button2";
        button2.Size = new Size(119, 68);
        button2.TabIndex = 5;
        button2.Text = "↶ Home";
        button2.UseVisualStyleBackColor = false;
        button2.Click += button2_Click;
        // 
        // button3
        // 
        button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
        button3.BackgroundImageLayout = ImageLayout.Stretch;
        button3.Location = new Point(444, 277);
        button3.Name = "button3";
        button3.Size = new Size(23, 23);
        button3.TabIndex = 6;
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.BackColor = Color.Transparent;
        label3.Font = new Font("Comic Sans MS", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
        label3.ForeColor = Color.White;
        label3.Location = new Point(279, 50);
        label3.Name = "label3";
        label3.Size = new Size(143, 68);
        label3.TabIndex = 7;
        label3.Text = "Login";
        // 
        // LoginForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
        BackgroundImageLayout = ImageLayout.Center;
        ClientSize = new Size(694, 365);
        Controls.Add(label3);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(linkLabel1);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(button1);
        DoubleBuffered = true;
        Name = "LoginForm";
        Activated += LoginForm_Activated;
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
    private Button button3;
    private Label label3;
}
