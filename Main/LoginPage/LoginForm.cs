using Data_Layer;
using System.Data.OleDb;

namespace LoginPage;
public partial class LoginForm : Form, IDir
{
    public UserClass user;
    public LoginForm()
    {
        InitializeComponent();
        textBox2.UseSystemPasswordChar = true;
    }
    public event Action OnLoginSuccess;
    public event Action OnRegisterRequested;
    public event Action OnHomeRequested;
    public string projectRoot;
    private void LoginForm_Load(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {

        string currentDirectory = Directory.GetCurrentDirectory();
        projectRoot = getPath(currentDirectory);

        string dbRelative = Path.Combine(projectRoot, "Resources", "Users.accdb");
        string dbAbsolute = Path.GetFullPath(dbRelative);

        string connectionS = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbRelative};";
        string queryS = @"SELECT USERNAME, [PASSWORD], ID, HS FROM UserData WHERE USERNAME = @username AND [PASSWORD] = @password";

        MessageBox.Show(dbRelative);
        try
        {
            using (OleDbConnection connection = new OleDbConnection(connectionS))
            {
                connection.Open();
                try
                {
                    OleDbCommand loginCmd = new OleDbCommand(queryS, connection);

                    loginCmd.Parameters.AddWithValue("@username", textBox1.Text);
                    loginCmd.Parameters.AddWithValue("@password", textBox2.Text);

                    OleDbDataReader reader = loginCmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        throw new Exception("Wrong username or password");
                    }
                    while (reader.Read())
                    {

                        user = new UserClass(reader["ID"].ToString(), reader["USERNAME"].ToString(), reader["PASSWORD"].ToString(), int.Parse(reader["HS"].ToString()));
                        modifyTextFileUserData(projectRoot);
                    }
                    OnLoginSuccess?.Invoke();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { connection.Close(); }

            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        OnRegisterRequested?.Invoke();
        this.Hide();

    }
    public string getPath(string currentDirectory, int i = 5)
    {
        for (int p = 0; p < i; p++)
        {
            currentDirectory = Directory.GetParent(currentDirectory).FullName;
        }
        return currentDirectory;
    }
    public void modifyTextFileUserData(string root, string operation = "")
    {
        string path = Path.Combine(root, "Resources", "currUser.txt");
        if (operation == "DELELE")
        {
            File.WriteAllText(path, String.Empty);
        }
        else
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(user.ID);
            }
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        OnHomeRequested?.Invoke();
        this.Close();
    }

    private async void button3_Click(object sender, EventArgs e)
    {
        await ToggleVisibility();
    }

    public async Task ToggleVisibility()
    {

        textBox2.UseSystemPasswordChar = false;
        button3.Text = "\uD83D\uDC41";
        await Task.Delay(900);
        textBox2.UseSystemPasswordChar = true;
        button3.Text = "\uD83D\uDD0D";

    }

    private void LoginForm_Activated(object sender, EventArgs e)
    {
        textBox2.UseSystemPasswordChar = true;
    }
}
