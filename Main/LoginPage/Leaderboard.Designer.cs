namespace Data_Layer;

partial class Leaderboard
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Leaderboard));
        button1 = new Button();
        panel1 = new Panel();
        comboBox1 = new ComboBox();
        label3 = new Label();
        SuspendLayout();
        // 
        // button1
        // 
        button1.BackColor = Color.Transparent;
        button1.BackgroundImageLayout = ImageLayout.Center;
        button1.FlatAppearance.BorderSize = 0;
        button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
        button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
        button1.FlatStyle = FlatStyle.Flat;
        button1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
        button1.ForeColor = Color.White;
        button1.Location = new Point(1, -2);
        button1.Name = "button1";
        button1.Size = new Size(78, 80);
        button1.TabIndex = 0;
        button1.Text = "↶";
        button1.TextAlign = ContentAlignment.TopLeft;
        button1.UseVisualStyleBackColor = false;
        button1.Click += button1_Click;
        // 
        // panel1
        // 
        panel1.AutoScroll = true;
        panel1.BackColor = Color.Transparent;
        panel1.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        panel1.ForeColor = Color.White;
        panel1.Location = new Point(48, 224);
        panel1.Name = "panel1";
        panel1.Size = new Size(297, 333);
        panel1.TabIndex = 1;
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Items.AddRange(new object[] { "Top 3", "Top 5", "Top 10" });
        comboBox1.Location = new Point(224, 40);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(121, 23);
        comboBox1.TabIndex = 0;
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.BackColor = Color.Transparent;
        label3.Font = new Font("Comic Sans MS", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
        label3.ForeColor = Color.White;
        label3.Location = new Point(27, 100);
        label3.Name = "label3";
        label3.Size = new Size(318, 68);
        label3.TabIndex = 9;
        label3.Text = "Leaderboard";
        // 
        // Leaderboard
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(389, 596);
        Controls.Add(label3);
        Controls.Add(comboBox1);
        Controls.Add(panel1);
        Controls.Add(button1);
        DoubleBuffered = true;
        Name = "Leaderboard";
        Text = "Leaderboard";
        Activated += Leaderboard_Activated;
        Load += Leaderboard_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private Panel panel1;
    private ComboBox comboBox1;
    private Label label3;
}