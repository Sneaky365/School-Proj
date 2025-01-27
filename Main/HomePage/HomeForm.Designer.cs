namespace HomePage;

partial class HomeForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
        button1 = new Button();
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
        button1.Font = new Font("Comic Sans MS", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
        button1.ForeColor = Color.White;
        button1.Location = new Point(241, 254);
        button1.Name = "button1";
        button1.Size = new Size(319, 154);
        button1.TabIndex = 0;
        button1.Text = "Play";
        button1.UseVisualStyleBackColor = false;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.BackColor = Color.Transparent;
        button2.CausesValidation = false;
        button2.FlatAppearance.BorderSize = 0;
        button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
        button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
        button2.FlatStyle = FlatStyle.Flat;
        button2.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        button2.ForeColor = Color.White;
        button2.Location = new Point(48, 54);
        button2.Name = "button2";
        button2.Size = new Size(161, 115);
        button2.TabIndex = 1;
        button2.Text = "View Account Info";
        button2.UseVisualStyleBackColor = false;
        button2.Visible = false;
        button2.Click += button2_Click;
        // 
        // button3
        // 
        button3.BackColor = Color.Transparent;
        button3.FlatAppearance.BorderSize = 0;
        button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
        button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
        button3.FlatStyle = FlatStyle.Flat;
        button3.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        button3.ForeColor = Color.White;
        button3.Location = new Point(592, 65);
        button3.Name = "button3";
        button3.Size = new Size(145, 92);
        button3.TabIndex = 2;
        button3.Text = "Leaderboard";
        button3.UseVisualStyleBackColor = false;
        button3.Click += button3_Click;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.BackColor = Color.Transparent;
        label3.Font = new Font("Comic Sans MS", 48F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
        label3.ForeColor = Color.White;
        label3.Location = new Point(294, 9);
        label3.Name = "label3";
        label3.Size = new Size(207, 90);
        label3.TabIndex = 9;
        label3.Text = "Home";
        // 
        // HomeForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(800, 450);
        Controls.Add(label3);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        DoubleBuffered = true;
        Name = "HomeForm";
        Text = "Form1";
        Activated += HomeForm_Activated;
        Load += HomeForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private Button button2;
    private Button button3;
    private Label label3;
}
