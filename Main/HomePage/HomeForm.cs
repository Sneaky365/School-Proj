using Data_Layer;
using LoginPage;
using RegisterPage;
using System.Data.OleDb;
namespace HomePage;

public partial class HomeForm : Form
{
    public HomeForm()
    {
        
        InitializeComponent();
        

    }

    private void button1_Click(object sender, EventArgs e)
    {
        this.Hide();

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
        
        infoP.Show();
        infoP.onHomeRequested += () => this.Show();
        infoP.OnLogout += () => this.Show();
    }

    private void HomeForm_Activated(object sender, EventArgs e)
    {
        
        CheckIfLogined();
    }
}
