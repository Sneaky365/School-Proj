
using Data_Layer;
using LoginPage;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data.OleDb;

namespace RegisterPage;

public partial class RegisterForm : Form, IDir

{
    public UserClass user;
    public RegisterForm()
    {
        InitializeComponent();
        textBox2.UseSystemPasswordChar = true;
        
    }
    public event Action OnRegisterCompleted;
    public event Action OnReturningToLogin;
    public event Action OnReturningToHome;
    private void button1_Click(object sender, EventArgs e)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string projectRoot = getPath(currentDirectory);
        textBox1.Text = textBox1.Text.Trim();
        textBox2.Text = textBox2.Text.Trim();
        string queryS = @"INSERT INTO UserData ([PASSWORD], USERNAME, ID, HS) 
                            VALUES(@password, @username, @id, @hs)";
        string checkAvailability = $@"SELECT USERNAME FROM UserData WHERE USERNAME= @username";
        string dbRelative = Path.Combine(projectRoot, "Resources", "Users.accdb");

        string connectionS = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbRelative};";
        MessageBox.Show(connectionS);
        try
        {
            using (OleDbConnection connection = new OleDbConnection(connectionS))
            {
                connection.Open();
                try
                {
                    if (usernameExists(connection, checkAvailability))
                    {
                        throw new Exception("Username already exists!");
                    }
                    OleDbCommand registerCmd = new OleDbCommand(queryS, connection);
                    string userID = Guid.NewGuid().ToString();
                    registerCmd.Parameters.AddWithValue("@password", textBox2.Text);
                    registerCmd.Parameters.AddWithValue("@username", textBox1.Text);
                    registerCmd.Parameters.AddWithValue("@id", userID);
                    registerCmd.Parameters.AddWithValue("@hs", 0);

                    registerCmd.ExecuteNonQuery();

                    user = new UserClass(userID, textBox1.Text, textBox2.Text, 0);
                    modifyTextFileUserData(Path.Combine(projectRoot, "Resources", "currUser.txt"));
                    OnRegisterCompleted?.Invoke();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        catch (Exception ex)
        {

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
    public void modifyTextFileUserData(string path, string operation = "")
    {
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

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        textBox1.Text = "";
        textBox2.Text = "";
        OnReturningToLogin?.Invoke();
        this.Close();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        OnReturningToHome?.Invoke();
        this.Close();
    }
    private bool usernameExists(OleDbConnection connection, string checkAvailability)
    {
        OleDbCommand avaibilityCmd = new OleDbCommand(checkAvailability, connection);
        avaibilityCmd.Parameters.AddWithValue("@username", textBox1.Text);
        OleDbDataReader avaibilityReader = avaibilityCmd.ExecuteReader();
        if (avaibilityReader.HasRows)
        {
            return true;
        }
        return false;
    }

    private void RegisterForm_Load(object sender, EventArgs e)
    {

    }

    private async void button3_Click(object sender, EventArgs e)
    {
        
         ToggleVisibility();
        this.Focus();

    }
    public async Task ToggleVisibility()
    {
        
        textBox2.UseSystemPasswordChar = false;
        button3.Text = "\uD83D\uDC41";
        await Task.Delay(2000);
        textBox2.UseSystemPasswordChar = true;
        button3.Text = "\uD83D\uDD0D";
        

    }

    private void RegisterForm_Activated(object sender, EventArgs e)
    {
        textBox2.UseSystemPasswordChar = true;
    }
}
