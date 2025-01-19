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
        pictureBox1 = new PictureBox();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.Location = new Point(82, 64);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(131, 121);
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(310, 64);
        label1.Name = "label1";
        label1.Size = new Size(60, 15);
        label1.TabIndex = 1;
        label1.Text = "Username";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(310, 115);
        label2.Name = "label2";
        label2.Size = new Size(80, 15);
        label2.TabIndex = 2;
        label2.Text = "Highest Score";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(310, 170);
        label3.Name = "label3";
        label3.Size = new Size(86, 15);
        label3.TabIndex = 3;
        label3.Text = "Games Played?";
        // 
        // textBox1
        // 
        textBox1.Location = new Point(415, 61);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(100, 23);
        textBox1.TabIndex = 4;
        // 
        // textBox2
        // 
        textBox2.Location = new Point(415, 112);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(100, 23);
        textBox2.TabIndex = 5;
        // 
        // AccountInfo
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(pictureBox1);
        Name = "AccountInfo";
        Text = "AccountInfo";
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
}