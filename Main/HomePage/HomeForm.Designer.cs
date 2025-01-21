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
        button1 = new Button();
        button2 = new Button();
        button3 = new Button();
        label3 = new Label();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(319, 258);
        button1.Name = "button1";
        button1.Size = new Size(98, 37);
        button1.TabIndex = 0;
        button1.Text = "Play";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.CausesValidation = false;
        button2.Location = new Point(77, 70);
        button2.Name = "button2";
        button2.Size = new Size(147, 65);
        button2.TabIndex = 1;
        button2.Text = "View Account Info";
        button2.UseVisualStyleBackColor = true;
        button2.Visible = false;
        button2.Click += button2_Click;
        // 
        // button3
        // 
        button3.Location = new Point(541, 80);
        button3.Name = "button3";
        button3.Size = new Size(104, 44);
        button3.TabIndex = 2;
        button3.Text = "Leaderboard";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Palatino Linotype", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
        label3.Location = new Point(299, 46);
        label3.Name = "label3";
        label3.Size = new Size(152, 63);
        label3.TabIndex = 9;
        label3.Text = "Home";
        // 
        // HomeForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(label3);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
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
