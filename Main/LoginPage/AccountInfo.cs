using LoginPage;
using Microsoft.VisualBasic.ApplicationServices;
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
public partial class AccountInfo : Form, IDir
{
    public event Action OnLogout;
    public string projRoot;
    public AccountInfo()
    {
        InitializeComponent();
        projRoot = getPath(Directory.GetCurrentDirectory());
    }
    LoginForm loginForm;
    public event Action onHomeRequested;
    private void AccountInfo_Load(object sender, EventArgs e)
    {
        loginForm = new LoginForm();

        List<string> data = getCurrData();
        textBox1.Text = data[0];
        textBox2.Text = data[1];
        textBox3.Text = data[2];

    }

    private void groupBox1_Enter(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
        onHomeRequested?.Invoke();
        this.Close();
    }
    private List<string> getCurrData()
    {
        List<string> arr = new List<string>();
        string queryS = @"SELECT USERNAME, HS, ID FROM UserData WHERE ID=@id";
        
        string connectionS = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(projRoot, "Resources", "Users.accdb")};";
        string id = "";
        using (StreamReader sr = new StreamReader(Path.Combine(projRoot, "Resources", "currUser.txt")))
        {
            id = sr.ReadLine();
        };

        using (OleDbConnection connection = new OleDbConnection(connectionS))
        {
            connection.Open();
            using (OleDbCommand command = new OleDbCommand(queryS, connection))
            {
                
                try
                {
                    command.Parameters.AddWithValue("@id", id);
                    OleDbDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        
                        arr.Add(reader["ID"].ToString());
                        arr.Add(reader["USERNAME"].ToString());
                        arr.Add(reader["HS"].ToString());
                        

                        return arr;
                    }

                }
                catch (Exception ex)
                {
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                finally { connection.Close(); }
            }

        }

        return arr;
    }

    public void modifyTextFileUserData(string root, string operation = "")
    {
        string path = Path.Combine(root, "Resources", "currUser.txt");
        if (operation == "DELETE")
        {
            File.WriteAllText(path, String.Empty);
        }
        else
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                //sw.WriteLine(user.ID);
            }
        }
    }
    public string getPath(string currentDirectory, int i = 5)
    {
        for (int p = 0; p < i; p++)
        {
            currentDirectory = Directory.GetParent(currentDirectory).FullName;
        }
        return currentDirectory;
    }

    private void button2_Click(object sender, EventArgs e)
    {
        modifyTextFileUserData(projRoot, "DELETE");
        OnLogout?.Invoke();
        this.Close();
    }

    private void AccountInfo_Activated(object sender, EventArgs e)
    {

    }
}
