using Data_Layer;
using LoginPage;
using RegisterPage;
using Game;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing.Text;
using Accessibility;
using System.Collections.Generic;
namespace HomePage;

public partial class HomeForm : Form
{
    public string currentDirectory;
    public string connectionS;
    public UserClass user;
    public string currID;
    public HomeForm()
    {

        InitializeComponent();
        currentDirectory = getPath(Directory.GetCurrentDirectory());
        connectionS = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(currentDirectory, "Resources", "Users.accdb")}";
        currID = getID();
    }

    private bool handleReqsOnEmpty()
    {
        LoginForm loginForm = new LoginForm();
        RegisterForm registerForm = null;
        AccountInfo accountInfo = new AccountInfo();


        loginForm.OnLoginSuccess += () =>
        {
            this.Show();
        };

        loginForm.OnRegisterRequested += () =>
        {
            if (registerForm == null || registerForm.IsDisposed)
            {
                registerForm = new RegisterForm();
                registerForm.OnRegisterCompleted += () => this.Show();
                registerForm.OnReturningToHome += () =>
                {
                    this.Show();
                };
                registerForm.OnReturningToLogin += () =>
                {
                    loginForm.Show();
                };
            }
            registerForm.Show();
            this.Hide();
        };
        loginForm.FormClosed += (a, b) => this.Show();
        loginForm.OnHomeRequested += () => this.Show();
        loginForm.Show();
        return true;
    }
    private bool handleReqsOnLogined()
    {
        getUserData();
        GameSpace gs = new GameSpace();


        gs.Activated += (sender, b) => { };

        gs.Show();
        gs.onHomeRequested += (newHS) =>
        {
            if (newHS > user.HighestScore)
            {
                MessageBox.Show(newHS.ToString());
                user.HighestScore = newHS;
                updateUserData();

            }
            this.Show();
        };


        return true;

    }
    private void button1_Click(object sender, EventArgs e)
    {

        var d = button2.Visible ? handleReqsOnLogined() : handleReqsOnEmpty();
        this.Hide();


    }

    private void HomeForm_Load(object sender, EventArgs e)
    {

        CheckIfLogined();

    }
    private void CheckIfLogined()
    {
        string p = File.ReadAllText(Path.Combine(getPath(Directory.GetCurrentDirectory()), "Resources", "currUser.txt"));
        if (p.Length == 0)
        {
            button2.Visible = false;
        }
        else
        {
            button2.Visible = true;
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
        this.Hide();
        AccountInfo infoP = new AccountInfo();
        if (user == null) getUserData();
        updateUserData();


        infoP.Show();
        infoP.onHomeRequested += () => this.Show();
        infoP.OnLogout += () => this.Show();
    }

    private void HomeForm_Activated(object sender, EventArgs e)
    {

        CheckIfLogined();
        currID = getID();
    }

    private void updateUserData()
    {
        string queryS = @"UPDATE UserData SET HS=@hs WHERE ID=@id";

        try
        {
            using (OleDbConnection connection = new OleDbConnection(connectionS))
            {
                connection.Open();
                try
                {
                    using (OleDbCommand command = new OleDbCommand(queryS, connection))
                    {
                        command.Parameters.AddWithValue("@hs", user.HighestScore);//6455497a-27ee-4ab2-9eea-05c679446ba9
                        command.Parameters.AddWithValue("@id", currID);
                        int rowsAffected = command.ExecuteNonQuery();


                        MessageBox.Show(user.HighestScore.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    private void getUserData()
    {

        string queryS = @"SELECT ID, [PASSWORD], USERNAME, HS FROM UserData WHERE ID=@id";

        using (OleDbConnection connection = new OleDbConnection(connectionS))
        {
            connection.Open();
            using (OleDbCommand command = new OleDbCommand(queryS, connection))
            {
                command.Parameters.AddWithValue("@id", getID());
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    user = new UserClass(reader["ID"].ToString(), reader["USERNAME"].ToString(), reader["PASSWORD"].ToString(), int.Parse(reader["HS"].ToString()));
                }
            }
            connection.Close();

        }

    }
    private string getID()
    {
        using (StreamReader streamReader = new StreamReader(Path.Combine(currentDirectory, "Resources", "currUser.txt")))
        {
            return streamReader.ReadLine();//Err Handling?
        }
    }

    private void button3_Click(object sender, EventArgs e)
    {
        Leaderboard leaderboard = new Leaderboard();
        leaderboard.Show();
        leaderboard.onHomeReq += () =>
        {
            this.Show();
        };
    }
}
