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
        button1 = new Button();
        panel1 = new Panel();
        comboBox1 = new ComboBox();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(75, 76);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 0;
        button1.Text = "Home";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // panel1
        // 
        panel1.Location = new Point(243, 24);
        panel1.Name = "panel1";
        panel1.Size = new Size(303, 396);
        panel1.TabIndex = 1;
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Items.AddRange(new object[] { "Top 3", "Top 5", "Top 10" });
        comboBox1.Location = new Point(618, 54);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(121, 23);
        comboBox1.TabIndex = 0;
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        // 
        // Leaderboard
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(comboBox1);
        Controls.Add(panel1);
        Controls.Add(button1);
        Name = "Leaderboard";
        Text = "Leaderboard";
        Activated += Leaderboard_Activated;
        Load += Leaderboard_Load;
        ResumeLayout(false);
    }

    #endregion

    private Button button1;
    private Panel panel1;
    private ComboBox comboBox1;
}