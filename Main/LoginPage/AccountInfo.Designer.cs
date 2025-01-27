namespace Data_Layer;

partial class AccountInfo
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountInfo));
        pictureBox1 = new PictureBox();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        button1 = new Button();
        label4 = new Label();
        textBox3 = new TextBox();
        button2 = new Button();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.Location = new Point(86, 258);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(131, 121);
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.BackColor = Color.Transparent;
        label1.Font = new Font("Comic Sans MS", 12F);
        label1.ForeColor = Color.White;
        label1.Location = new Point(263, 331);
        label1.Name = "label1";
        label1.Size = new Size(31, 23);
        label1.TabIndex = 1;
        label1.Text = "ID";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.BackColor = Color.Transparent;
        label2.Font = new Font("Comic Sans MS", 12F);
        label2.ForeColor = Color.White;
        label2.Location = new Point(300, 98);
        label2.Name = "label2";
        label2.Size = new Size(80, 23);
        label2.TabIndex = 2;
        label2.Text = "Username";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.BackColor = Color.Transparent;
        label3.Font = new Font("Comic Sans MS", 12F);
        label3.ForeColor = Color.White;
        label3.Location = new Point(300, 289);
        label3.Name = "label3";
        label3.Size = new Size(116, 23);
        label3.TabIndex = 3;
        label3.Text = "Games Played?";
        // 
        // textBox1
        // 
        textBox1.Enabled = false;
        textBox1.Location = new Point(300, 334);
        textBox1.Name = "textBox1";
        textBox1.ReadOnly = true;
        textBox1.Size = new Size(276, 23);
        textBox1.TabIndex = 4;
        // 
        // textBox2
        // 
        textBox2.Enabled = false;
        textBox2.Location = new Point(386, 101);
        textBox2.Name = "textBox2";
        textBox2.ReadOnly = true;
        textBox2.Size = new Size(100, 23);
        textBox2.TabIndex = 5;
        // 
        // button1
        // 
        button1.BackColor = Color.Transparent;
        button1.FlatAppearance.BorderSize = 0;
        button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
        button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
        button1.FlatStyle = FlatStyle.Flat;
        button1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
        button1.ForeColor = Color.White;
        button1.Location = new Point(-2, -1);
        button1.Name = "button1";
        button1.Size = new Size(86, 85);
        button1.TabIndex = 6;
        button1.Text = "↶";
        button1.TextAlign = ContentAlignment.TopLeft;
        button1.UseVisualStyleBackColor = false;
        button1.Click += button1_Click;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.BackColor = Color.Transparent;
        label4.Font = new Font("Comic Sans MS", 12F);
        label4.ForeColor = Color.White;
        label4.Location = new Point(277, 148);
        label4.Name = "label4";
        label4.Size = new Size(118, 23);
        label4.TabIndex = 7;
        label4.Text = "Highest Score:";
        // 
        // textBox3
        // 
        textBox3.Enabled = false;
        textBox3.Location = new Point(401, 151);
        textBox3.Name = "textBox3";
        textBox3.ReadOnly = true;
        textBox3.Size = new Size(100, 23);
        textBox3.TabIndex = 8;
        // 
        // button2
        // 
        button2.Location = new Point(675, 396);
        button2.Name = "button2";
        button2.Size = new Size(75, 23);
        button2.TabIndex = 9;
        button2.Text = "Log out";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // AccountInfo
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(800, 450);
        Controls.Add(button2);
        Controls.Add(textBox3);
        Controls.Add(label4);
        Controls.Add(button1);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(pictureBox1);
        DoubleBuffered = true;
        Name = "AccountInfo";
        Text = "AccountInfo";
        Activated += AccountInfo_Activated;
        Load += AccountInfo_Load;
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PictureBox pictureBox1;
    private Label label1;
    private Label label2;
    private Label label3;
    private TextBox textBox1;
    private TextBox textBox2;
    private Button button1;
    private Label label4;
    private TextBox textBox3;
    private Button button2;
}