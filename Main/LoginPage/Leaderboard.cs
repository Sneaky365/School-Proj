using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Layer;
public partial class Leaderboard : Form
{
    public event Action onHomeReq;
    Dictionary<string, int> leaderboardData = new Dictionary<string, int>();
    public Leaderboard()
    {
        InitializeComponent();
        getUsersData();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        onHomeReq?.Invoke();
        this.Close();
    }

    private void Leaderboard_Activated(object sender, EventArgs e)
    {
        int yPosition = 20;
        int i = 1;
        foreach (var item in leaderboardData)
        {
            
            Label label = new Label
            {
                Text = $"{i}. {item.Key} : {item.Value}",

                Location = new Point(20, yPosition),
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true, // Automatically adjust size based on the text
                ForeColor = Color.White, // Text color
                BackColor = Color.FromArgb(90, 60, 60), // Background color (dark gray)
                TextAlign = ContentAlignment.MiddleCenter, // Align text in the center
                Padding = new Padding(10)
            };
            label.BorderStyle = BorderStyle.FixedSingle;

            
            
            panel1.Controls.Add(label);

            i++;
            yPosition += 50;
        }
    }
    private Dictionary<string, int> getUsersData()
    {
        string dbRelative = Path.Combine(getPath(), "Resources", "Users.accdb");
        string connectionS = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbRelative};";
        string queryS = @"SELECT TOP 5 USERNAME, HS FROM UserData ORDER BY HS DESC";

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
            }catch (Exception ex)
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
}
