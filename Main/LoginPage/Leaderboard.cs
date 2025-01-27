using System.Data;
using System.Data.OleDb;
using System.Drawing.Drawing2D;

namespace Data_Layer;
public partial class Leaderboard : Form
{
    public event Action onHomeReq;
    Dictionary<string, int> leaderboardData = new Dictionary<string, int>();
    public int numberOfPeople;
    public Leaderboard()
    {
        InitializeComponent();
        getUsersData();
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
            comboBox1.SelectionStart = 0;

            comboBox1.Font = new Font("Segoe UI", 14, FontStyle.Regular);
            comboBox1.ForeColor = Color.White;
            comboBox1.BackColor = Color.FromArgb(50, 50, 70);
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.DrawItem += (s, e) =>
            {
                e.DrawBackground();
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                
                Color backColor = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                    ? Color.FromArgb(70, 70, 100) 
                    : Color.FromArgb(50, 50, 70); 

                Color textColor = Color.White;

               
                using (SolidBrush brush = new SolidBrush(backColor))
                {
                    g.FillRectangle(brush, e.Bounds);
                }

               
                TextRenderer.DrawText(
                    g,
                    comboBox1.Items[e.Index].ToString(),
                    comboBox1.Font,
                    e.Bounds,
                    textColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left
                );

                e.DrawFocusRectangle(); 
            };

            
            comboBox1.DropDownWidth = comboBox1.Width - 2;
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        onHomeReq?.Invoke();
        this.Close();
    }

    private void Leaderboard_Activated(object sender, EventArgs e)
    {
        panel1.Controls.Clear();
        int i = 1; // Initial rank index
        int yPosition = 20; // Initial y-coordinate for label placement

        foreach (var item in leaderboardData)
        {
            if (i > numberOfPeople)
            {
                break;
            }

            Label label = new Label
            {
                Text = $"{i}. {item.Key} : {item.Value}",
                Location = new Point(20, yPosition),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = false,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(50, 50, 70), 
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 15, 0), 
                Size = new Size(panel1.Width - 40, 50), 
            };

           
            label.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                
                Rectangle rect = new Rectangle(0, 0, label.Width - 1, label.Height - 1);
                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = 15; 
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
                    path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
                    path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
                    path.CloseAllFigures();

                    using (SolidBrush brush = new SolidBrush(label.BackColor)) 
                    {
                        e.Graphics.FillPath(brush, path);
                    }

                    using (Pen pen = new Pen(Color.White, 2)) 
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }

                
                TextRenderer.DrawText(
                    e.Graphics,
                    label.Text,
                    label.Font,
                    rect,
                    label.ForeColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left
                );
            };

            
            label.MouseEnter += (s, e) =>
            {
                label.BackColor = Color.FromArgb(70, 70, 100); 
                label.Invalidate();
            };

            label.MouseLeave += (s, e) =>
            {
                label.BackColor = Color.FromArgb(50, 50, 70); 
                label.Invalidate(); 
            };

            panel1.Controls.Add(label);

            i++;
            yPosition += 60;
        }

    }
    private Dictionary<string, int> getUsersData(int i = 5)
    {
        string dbRelative = Path.Combine(getPath(), "Resources", "Users.accdb");
        string connectionS = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbRelative};";
        string queryS = @"SELECT TOP 10 USERNAME, HS FROM UserData ORDER BY HS DESC";

        using (OleDbConnection connection = new OleDbConnection(connectionS))
        {
            connection.Open();
            try
            {
                using (OleDbCommand command = connection.CreateCommand())
                {
                    DataSet dataset = new DataSet();
                    command.CommandText = queryS;
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        leaderboardData.Add(reader["USERNAME"].ToString(), int.Parse(reader["HS"].ToString()));

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        return leaderboardData;
    }
    private string getPath(int i = 5)
    {
        string path = Directory.GetCurrentDirectory();
        for (int p = 0; p < i; p++)
        {
            path = Directory.GetParent(path).FullName;
        }
        return path;
    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void Leaderboard_Load(object sender, EventArgs e)
    {

    }

    private void sdaToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (comboBox1.SelectedIndex)
        {
            case 0:
                numberOfPeople = 3;
                this.Refresh();
                Leaderboard_Activated(this, e);
                break;
            case 1:
                numberOfPeople = 5;
                this.Refresh();
                Leaderboard_Activated(this, e);
                break;
            case 2:
                numberOfPeople = 10;
                this.Refresh();
                Leaderboard_Activated(this, e);
                break;
        }
    }
}
